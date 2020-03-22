using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_SlimeEnArmure : MonoBehaviour
{
    private int valeurAleatoire;
    public float distanceToPlayer;
    private Animator mAnimator;
    public string element; //Used for display color
    public string choix;
    private bool boule;
    private string hexcolor;
    public Text displayText;

    private int damage;

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
            if (affichage != null)
            {
                Debug.Log(hexcolor);
                displayText.text = "<color=" + hexcolor + ">" + affichage + "</color>";
            }
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
        affichage = "";
        mAnimator.SetBool("Spelling", true);
        for (int i = 0; i < choix.Length; i++)
        {
            yield return new WaitForSeconds(1 * PlayerStats.Difficulte);
            affichage += choix[i];
        }
        mAnimator.SetBool("Attacking", true);
        damage = this.GetComponent<XmlManager>().SpellDatabase.SpellBook.Find(SpellEntry => SpellEntry.spellName == choix).value;
        GameObject Joueur = GameObject.Find("Player");
        Joueur.GetComponent<PlayerStats>().DamagePlayer(damage, element);
        mAnimator.SetBool("Spelling", false);
        boule = true;
    }
}
