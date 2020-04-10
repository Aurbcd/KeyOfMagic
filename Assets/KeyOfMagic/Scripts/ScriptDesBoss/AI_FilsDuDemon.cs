using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AI_FilsDuDemon : MonoBehaviour
{
    private int compteurSort = 0;
    private float pourcentage;
    private bool phaseUne = true;
    private bool phaseDeux = false;
    private bool phaseTrois = false;
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
    private ParticleSystem PS;
    //SON
    public static AudioClip filsDuDemonGroan1;
    public static AudioClip filsDuDemonGroan2;


    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        choixElement();
        boule = true;
        displayText.text = "";
        LastPos = curPos;
        aBougé = false;
        PS = this.gameObject.transform.GetComponentInChildren<ParticleSystem>();
        PS.Stop();
        filsDuDemonGroan1 = Resources.Load<AudioClip>("MonsterHit1");
        filsDuDemonGroan2 = Resources.Load<AudioClip>("MonsterHit2");
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
            int vie_actuelle = GetComponent<MonsterStatText>().PV;
            int vie_max = GetComponent<MonsterStatText>().PVMax;
            int pourcentage = (int)(((float)vie_actuelle / (float)vie_max) * 100f);
            if (pourcentage <= 70 && phaseUne && compteurSort <= 10) //Entrée dans la phase 1
            {
                PS.Play();
                StartCoroutine(HeAttacFaster());
                if (compteurSort == 10)
                {
                    PS.Stop();
                    phaseUne = false; //Sortie de la phase 1
                    phaseDeux = true; 
                    compteurSort = 0;
                    Debug.Log("Fin phase 1");
                }
            }
            else if (pourcentage <= 50 && phaseDeux && compteurSort <= 10) //Entrée dans la phase 2
            {
                PS.Play();
                StartCoroutine(HeAttacFaster());
                if (compteurSort == 10)
                {
                    PS.Stop();
                    phaseDeux = false; //Sortie de la phase 2
                    phaseTrois = true;
                    compteurSort = 0;
                    Debug.Log("Fin phase 2");
                }
            }
            else if (pourcentage <= 20 && phaseTrois && compteurSort <= 10) //Entrée dans la phase 3
            {
                PS.Play();
                StartCoroutine(HeAttacFaster());
                if (compteurSort == 10)
                {
                    PS.Stop();
                    phaseTrois = false; //Sortie de la phase 3
                    compteurSort = 0;
                    Debug.Log("Fin phase 3");
                }
            }
            else //Sinon attaque normale
            {
            StartCoroutine(HeAttac());
            }
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

    void choixElement() //Vraiment aléatoire
    {
        System.Random aleatoire = new System.Random();
        int pourcentage = aleatoire.Next(100);
        if (pourcentage >= 80 )
        {
            element = "Terre";
        }
        if (pourcentage < 80 && pourcentage >= 60)
        {
            element = "Electricite";
        }
        if (pourcentage < 60 && pourcentage >= 40)
        {
            element = "Eau";
        }
        if (pourcentage < 40 && pourcentage >= 20)
        {
            element = "Feu";
        }
        if (pourcentage < 20)
        {
            element = "Air";
        }

    }

    void groan()
    {
        System.Random aleatoire = new System.Random();
        int pourcentage = aleatoire.Next(100);
        if (pourcentage < 50)
        {
            GetComponent<AudioSource>().PlayOneShot(filsDuDemonGroan1);
        }
        else
            GetComponent<AudioSource>().PlayOneShot(filsDuDemonGroan2);
    }

    void choixSpell()
    {
        //BOSS IL A TOUS LES ELEMENTS

        System.Random aleatoire = new System.Random();
        valeurAleatoire = aleatoire.Next(100);

        //75% de lancer l'élément != Terre

        if (element.Equals("Feu") )
        {
                valeurAleatoire = aleatoire.Next(100);
                if (valeurAleatoire <= 50) //Petit sort
                {
                   choix = "ustus"; 
                }
                else //Gros sort
                {
                    choix = "ugniramil";
                }
        }

        
        if (element.Equals("Air"))
        {
                valeurAleatoire = aleatoire.Next(100);
                if (valeurAleatoire <= 50) //Petit sort
                {
                    choix = "estek";
                }
                else //Gros sort
                {
                    choix = "eminitasi";
                }
        }

        if (element.Equals("Electricite"))
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

        if (element.Equals("Eau"))
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

        if (element.Equals("Terre"))
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
    }

    IEnumerator HeAttacFaster()
    {
        Debug.Log("Phase");
        boule = false;
        choixElement();
        choixSpell();
        affichage = "";
        mAnimator.SetBool("Spelling", true);
        aBougé = false;
        for (int i = 0; i < choix.Length; i++)
        {
            yield return new WaitForSeconds(1 / (PlayerStats.Difficulte + 2));
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
            compteurSort++;
        }
        else
        {
            mAnimator.SetBool("Attacking", false);
            mAnimator.SetBool("Spelling", false);
        }
        boule = true;
    }

    IEnumerator HeAttac()
    {
        boule = false;
        choixElement();
        choixSpell();
        affichage = "";
        mAnimator.SetBool("Spelling", true);
        aBougé = false;
        for (int i = 0; i < choix.Length; i++)
        {
            yield return new WaitForSeconds(1 / (PlayerStats.Difficulte));
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
            compteurSort++;
        }
        else
        {
            mAnimator.SetBool("Attacking", false);
            mAnimator.SetBool("Spelling", false);
        }
        boule = true;
    }
}