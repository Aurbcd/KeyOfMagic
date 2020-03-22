using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_SlimeEnArmure : MonoBehaviour
{
    private int valeurAleatoire;
    public float distanceToPlayer;
    private Animator mAnimator;
    private static string element;
    public string choix;
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
        //SLIME EN ARMURE : EAU/ELECTRICITE

        //CHOIX 1 : élément
        System.Random aleatoire = new System.Random();
        valeurAleatoire = aleatoire.Next(100);

        //Bouclier Feu : 75% Eau, 25% Electricite 
        if (PlayerStats.shieldElement.Equals("Feu") && valeurAleatoire <= 75)
        {
            element = "Eau";
        }
        if (PlayerStats.shieldElement.Equals("Feu") && valeurAleatoire > 75)
        {
            element = "Electricite";
        }

        //Bouclier Eau : 75% Electricite, 25% Air
        if (PlayerStats.shieldElement.Equals("Eau") && valeurAleatoire <= 75)
        {
            element = "Electricite";
        }
        if (PlayerStats.shieldElement.Equals("Eau") && valeurAleatoire > 75)
        {
            element = "Eau";
        }

        //Bouclier Autre : 60%/40%
        if (!PlayerStats.shieldElement.Equals("Feu") && !PlayerStats.shieldElement.Equals("Electricite") && valeurAleatoire <= 60)
        {
            element = "Eau";
        }
        if (!PlayerStats.shieldElement.Equals("Feu") && !PlayerStats.shieldElement.Equals("Electricite") && valeurAleatoire > 60)
        {
            element = "Electricite";
        }

        //CHOIX 2 : Sort
        valeurAleatoire = aleatoire.Next(100);
        if (element.Equals("Eau") && valeurAleatoire <= 60) //Cas Feu
        {
            choix = "amoi";
        }
        if (element.Equals("Eau") && valeurAleatoire > 40)
        {
            choix = "atosophila";
        }
        if (element.Equals("Electricite") && valeurAleatoire <= 60) //Cas Air
        {
            choix = "inuji";
        }
        if (element.Equals("Electricite") && valeurAleatoire > 40)
        {
            choix = "istaliplo";
        }

        //SLIME EN ARMURE : EAU/ELECTRICITE
    }

    IEnumerator HeAttac()
    {
        boule = false;
        yield return new WaitForSeconds(2);
        choixSpell();
        string affichage = "";
        mAnimator.SetBool("Spelling", true);
        for (int i = 0; i < choix.Length; i++)
        {
            yield return new WaitForSeconds(1 * PlayerStats.Difficulte);
            affichage += choix[i];
            Debug.Log(affichage);
        }
        mAnimator.SetBool("Attacking", true);
        mAnimator.SetBool("Spelling", false);
        boule = true;
    }
}
