using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AI_SlimeRouge : MonoBehaviour
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
            //SLIME ROUGE : FEU/AIR       

            //CHOIX 1 : élément
            System.Random aleatoire = new System.Random();
            valeurAleatoire = aleatoire.Next(100);

            //Bouclier Terre : 75% Air, 25% Feu 
            if (PlayerStats.shieldElement.Equals("Terre") && valeurAleatoire <= 75)
            {
                element = "Air";
            }
            if (PlayerStats.shieldElement.Equals("Terre") && valeurAleatoire > 75)
            {
                element = "Feu";
            }

            //Bouclier Electricite : 75% Feu, 25% Air
            if (PlayerStats.shieldElement.Equals("Electricite") && valeurAleatoire <= 75)
            {
                element = "Feu";
            }
            if (PlayerStats.shieldElement.Equals("Electricite") && valeurAleatoire > 75)
            {
                element = "Air";
            }

            //Bouclier Autre : 60%/40%
            if (!PlayerStats.shieldElement.Equals("Electricite") && !PlayerStats.shieldElement.Equals("Terre") && valeurAleatoire <= 60)
            {
                element = "Feu";
            }
            if (!PlayerStats.shieldElement.Equals("Electricite") && !PlayerStats.shieldElement.Equals("Terre") && valeurAleatoire > 60)
            {
                element = "Air";
            }

            //CHOIX 2 : Sort
            valeurAleatoire = aleatoire.Next(100);
            if (element.Equals("Feu") && valeurAleatoire <= 75) //Cas Feu
            {
                choix = "urbex";
            }
            if (element.Equals("Feu") && valeurAleatoire > 75)
            {
                choix = "unifulopa";
            }
            if (element.Equals("Air") && valeurAleatoire <= 75) //Cas Air
            {
                choix = "estek";
            }
            if (element.Equals("Air") && valeurAleatoire > 75)
            {
                choix = "eminitasi";
            }

            //SLIME ROUGE : FEU/AIR
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
            mAnimator.SetBool("Attacking", true);
            damage = this.GetComponent<XmlManager>().SpellDatabase.SpellBook.Find(SpellEntry => SpellEntry.spellName == choix).value;
            GameObject Joueur= GameObject.Find("Player");
            Joueur.GetComponent<PlayerStats>().DamagePlayer(damage, element);
            mAnimator.SetBool("Spelling", false);
        }else
        {
            mAnimator.SetBool("Attacking", false);
            mAnimator.SetBool("Spelling", false);
        }
        boule = true;
    }
}