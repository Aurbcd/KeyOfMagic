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

    public string affichage;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        boule = true;
        displayText.text = "";
    }
    private void Update()
    {   
        distanceToPlayer = (GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude;
        if (distanceToPlayer < 15 && gameObject.GetComponent<MonsterStatText>().PV >= 0 && boule)
        {
            StartCoroutine(HeAttac());
        }

        if (this.GetComponent<XmlManager>().ElementDatabase.Elementdb.Find(elementEntry => elementEntry.elementName == element) != null)
        {
            hexcolor = this.GetComponent<XmlManager>().ElementDatabase.Elementdb.Find(elementEntry => elementEntry.elementName == element).hexColor;
            Debug.Log(hexcolor);
            if (affichage != null)
            {
                displayText.text = "<color=" + hexcolor + ">" + affichage + "</color>";
                Debug.Log("<color=" + hexcolor + ">" + affichage + "</color>");
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
        Debug.Log("Bonjour");
        yield return new WaitForSeconds(2);
        choixSpell();
        Debug.Log("Frero j'ai choisi");
        Debug.Log(choix);
        affichage = "";
        mAnimator.SetBool("Spelling", true);
        for (int i = 0; i < choix.Length; i++)
        {
            yield return new WaitForSeconds(1 * PlayerStats.Difficulte);
            affichage += choix[i];
            Debug.Log(affichage);
        }
        mAnimator.SetBool("Attacking", true);
        mAnimator.SetBool("Spelling", false);
        //RECHERCHE SORT ARTHUR BOOOOOOOOYER
        Debug.Log("Au revoir");
        boule = true;
    }
}