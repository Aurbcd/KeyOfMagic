using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AI_Diablotin : MonoBehaviour
{
    private int valeurAleatoire;
    public float distanceToPlayer;
    private Animator mAnimator;
    public string element; //Used for display color
    public string choix;
    private bool boule;
    private string hexcolor;
    public Text displayText;
    public Vector3 curPos;
    public Vector3 LastPos;
    private int damage;
    public bool aBougé;
    public string affichage;
    private GameObject clone;
    private GameObject sortAnim;
    public List<GameObject> VisuelSorts;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        boule = true;
        displayText.text = "";
        LastPos = curPos;
        aBougé = false;
    }
    private void Update()
    {
        curPos = transform.position;
        if (curPos != LastPos)
        {
            aBougé = true;
            displayText.text = "";
        }
        distanceToPlayer = (GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude;
        if (distanceToPlayer < 15 && gameObject.GetComponent<MonsterStatText>().PV >= 0 && boule)
        {
            StartCoroutine(HeAttac());
        }
        LastPos = curPos;
        if (this.GetComponent<XmlManager>().ElementDatabase.Elementdb.Find(elementEntry => elementEntry.elementName == element) != null && distanceToPlayer < 15)
        {
            hexcolor = this.GetComponent<XmlManager>().ElementDatabase.Elementdb.Find(elementEntry => elementEntry.elementName == element).hexColor;
            if (affichage != null)
            {
                displayText.text = "<color=" + hexcolor + ">" + affichage + "</color>";
            }
        }
    }

    void choixSpell()
    {
            //SLIME DIABLOTIN : TERRE/FEU       

            //CHOIX 1 : élément
            System.Random aleatoire = new System.Random();
            valeurAleatoire = aleatoire.Next(100);

            //Bouclier Electricite : 75% Terre, 25% Feu 
            if (PlayerStats.shieldElement.Equals("Electricite") && valeurAleatoire <= 75)
            {
                element = "Terre";
            }
            if (PlayerStats.shieldElement.Equals("Electricite") && valeurAleatoire > 75)
            {
                element = "Feu";
            }

            //Bouclier Air : 75% Feu, 25% Terre
            if (PlayerStats.shieldElement.Equals("Air") && valeurAleatoire <= 75)
            {
                element = "Feu";
            }
            if (PlayerStats.shieldElement.Equals("Air") && valeurAleatoire > 75)
            {
                element = "Terre";
            }

            //Bouclier Autre : 60%/40%
            if (!PlayerStats.shieldElement.Equals("Electricite") && !PlayerStats.shieldElement.Equals("Air") && valeurAleatoire <= 60)
            {
                element = "Feu";
            }
            if (!PlayerStats.shieldElement.Equals("Electricite") && !PlayerStats.shieldElement.Equals("Air") && valeurAleatoire > 60)
            {
                element = "Terre";
            }

            //CHOIX 2 : Sort
            valeurAleatoire = aleatoire.Next(100);
            if (element.Equals("Feu") && valeurAleatoire <= 40) //Cas Feu
            {
                choix = "urbex";
            }
            if (element.Equals("Feu") && valeurAleatoire > 60)
            {
                choix = "unifulopa";
            }
            if (element.Equals("Terre") && valeurAleatoire <= 40) //Cas Terre
            {
                choix = "otera";
            }
            if (element.Equals("Terre") && valeurAleatoire > 60)
            {
                choix = "opinalica";
            }

            //SLIME DIABLOTIN : TERRE/FEU  
    }

    IEnumerator HeAttac()
    {
        boule = false;
        choixSpell();
        affichage = "";
        mAnimator.SetBool("Spelling", true);
        aBougé = false;
        for (int i = 0; i < choix.Length; i++)
        {
            yield return new WaitForSeconds(1 / PlayerStats.Difficulte);
            affichage += choix[i];
            if (aBougé || GetComponent<MonsterMouvSelection>().IsDead)
            {
                affichage = "";
                break;
            }
        }
        if (distanceToPlayer < 15 && !aBougé && !GetComponent<MonsterMouvSelection>().IsDead)
        {
            sortAnim = VisuelSorts.Find(x => x.ToString().Equals("Sort" + element + " (UnityEngine.GameObject)"));
            mAnimator.SetBool("Attacking", true);
            yield return new WaitForSeconds(0.25f);
            damage = this.GetComponent<XmlManager>().SpellDatabase.SpellBook.Find(SpellEntry => SpellEntry.spellName == choix).value;
            clone = Instantiate(sortAnim, transform.position + new Vector3(0f,2f,0f), Quaternion.identity);
            clone.tag = "ADetruireMonstre";
            GameObject Joueur= GameObject.Find("Player");
            Joueur.GetComponent<PlayerStats>().DamagePlayer(damage, element);
            yield return new WaitForSeconds(0.25f);
            mAnimator.SetBool("Attacking", false);
            mAnimator.SetBool("Spelling", false);
            Destroy(clone);
        }
        else
        {
            mAnimator.SetBool("Attacking", false);
            mAnimator.SetBool("Spelling", false);
        }
        boule = true;
    }
}