using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AI_GolemBoss : MonoBehaviour
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
        choixElement();
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

    void choixElement() //En fonction du pourcentage de vie restante
    {
        int vie_actuelle = GetComponent<MonsterStatText>().PV;
        int vie_max = GetComponent<MonsterStatText>().PVMax;
        int pourcentage = (int) ((vie_actuelle/vie_max)*100);
        if (pourcentage >= 80 )
        {
            GetComponent<MonsterStatText>().element = "Terre";
        }
        else if (pourcentage < 80 && pourcentage >= 60)
        {
            GetComponent<MonsterStatText>().element = "Electricite";
        }
        else if (pourcentage < 60 && pourcentage >= 40)
        {
            GetComponent<MonsterStatText>().element = "Eau";
        }
        else if (pourcentage < 40 && pourcentage >= 20)
        {
            GetComponent<MonsterStatText>().element = "Feu";
        }
        else if (pourcentage < 20)
        {
            GetComponent<MonsterStatText>().element = "Air";
        }
        GetComponent<MonsterStatText>().weakness = GetComponent<XmlManager>().ElementDatabase.Elementdb.Find(elementEntry => elementEntry.elementName == GetComponent<MonsterStatText>().element).weakness;
        GetComponent<MonsterStatText>().resistance = GetComponent<XmlManager>().ElementDatabase.Elementdb.Find(elementEntry => elementEntry.elementName == GetComponent<MonsterStatText>().element).resistance;
    }

    void choixSpell()
    {
        //GOLEM BOSS IL A TOUS LES ELEMENTS

        System.Random aleatoire = new System.Random();
        valeurAleatoire = aleatoire.Next(100);
        element =  GetComponent<MonsterStatText>().element;
        Debug.Log(element);

        //75% de lancer l'élément != Terre

        if (element.Equals("Feu") )
        {
            if (valeurAleatoire <= 75) //Feu
            {
                valeurAleatoire = aleatoire.Next(100);
                if (valeurAleatoire <= 75) //Petit sort
                {
                   choix = "ustus"; 
                }
                else //Gros sort
                {
                    choix = "ugniramil";
                }
            }
            else //Terre
            {
                valeurAleatoire = aleatoire.Next(100);
                if (valeurAleatoire <= 50) //Petit sort
                {
                    choix = "otera";
                }
                else //Gros sort
                {
                    choix = "opinalica";
                }
            }
        }

        
        if (element.Equals("Air"))
        {
            if (valeurAleatoire <= 75) //Air
            {
                valeurAleatoire = aleatoire.Next(100);
                if (valeurAleatoire <= 75) //Petit sort
                {
                    choix = "estek";
                }
                else //Gros sort
                {
                    choix = "eminitasi";
                }
            }
            else //Terre
            {
                valeurAleatoire = aleatoire.Next(100);
                if (valeurAleatoire <= 50) //Petit sort
                {
                    choix = "otera";
                }
                else //Gros sort
                {
                    choix = "opinalica";
                }
            }
        }

        if (element.Equals("Electricite"))
        {
            if (valeurAleatoire <= 75) //Electricite
            {
                valeurAleatoire = aleatoire.Next(100);
                if (valeurAleatoire <= 75) //Petit sort
                {
                    choix = "inuji";
                }
                else //Gros sort
                {
                    choix = "istaliplo";
                }
            }
            else //Terre
            {
                valeurAleatoire = aleatoire.Next(100);
                if (valeurAleatoire <= 50) //Petit sort
                {
                    choix = "otera";
                }
                else //Gros sort
                {
                    choix = "opinalica";
                }
            }
        }

        if (element.Equals("Eau"))
        {
            if (valeurAleatoire <= 75) //Eau
            {
                valeurAleatoire = aleatoire.Next(100);
                if (valeurAleatoire <= 75) //Petit sort
                {
                    choix = "awali";
                }
                else //Gros sort
                {
                    choix = "aliquamira";
                }
            }
            else //Terre
            {
                valeurAleatoire = aleatoire.Next(100);
                if (valeurAleatoire <= 50) //Petit sort
                {
                    choix = "otera";
                }
                else //Gros sort
                {
                    choix = "opinalica";
                }
            }
        }

        if (element.Equals("Terre"))
        {
            Debug.Log("coucou");
            Debug.Log(valeurAleatoire);

            if (valeurAleatoire <= 50) //Terre
            {
                valeurAleatoire = aleatoire.Next(100);
                if (valeurAleatoire <= 50) //Petit sort
                {
                    choix = "oreca";
                }
                else //Gros sort
                {
                    choix = "omisteria";
                }
            }
            else //Terre
            {
                valeurAleatoire = aleatoire.Next(100);
                if (valeurAleatoire <= 50) //Petit sort
                {
                    choix = "otera";
                }
                else //Gros sort
                {
                    choix = "opinalica";
                }
            }

            Debug.Log(choix);
        }

    }

    IEnumerator HeAttac()
    {
        boule = false;
        choixElement();
        choixSpell();
        Debug.Log("2 : " + choix);
        affichage = "";
        mAnimator.SetBool("Spelling", true);
        aBougé = false;
        for (int i = 0; i < choix.Length; i++)
        {
            yield return new WaitForSeconds(1 / PlayerStats.Difficulte);
            Debug.Log(i);
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
            clone = Instantiate(sortAnim, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
            clone.tag = "ADetruireMonstre";
            GameObject Joueur = GameObject.Find("Player");
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