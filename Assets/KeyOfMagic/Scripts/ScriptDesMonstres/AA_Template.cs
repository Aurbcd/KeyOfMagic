using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AA_Template : MonoBehaviour
{
    private int valeurAleatoire;
    public float distanceToPlayer;
    private Animator mAnimator;
    public string choix;
    private string element;
    private bool boule;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        boule = true;
    }
    private void Update()
    {
        distanceToPlayer = (GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude;
        if (distanceToPlayer < 15 && gameObject.GetComponent<MonsterStatText>().PV >= 0 && boule)
        {
            StartCoroutine(HeAttac());
        }
    }

    void choixSpell()
    {
        mAnimator.SetBool("Attacking", true);

        //MODIFIER CODE ICI :   

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
            choix = "extek";
        }
        if (element.Equals("Air") && valeurAleatoire > 75)
        {
            choix = "eminitasi";
        }

        //MODIFIER CODE ICI
    }

    IEnumerator HeAttac()
    {
        boule = false;
        Debug.Log("Bonjour");
        yield return new WaitForSeconds(2);
        choixSpell();
        Debug.Log("Frero j'ai choisi");
        Debug.Log(choix);
        string affichage = "";
        for (int i = 0; i < choix.Length; i++)
        {
            yield return new WaitForSeconds(1 * PlayerStats.Difficulte);
            affichage += choix[i];
            Debug.Log(affichage);
        }
        //RECHERCHE SORT ARTHUR BOOOOOOOOYER
        Debug.Log("Au revoir");
        boule = true;
    }
}