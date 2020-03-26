﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;
using TMPro;

public class ImprovedSpellInput : MonoBehaviour
{
    public GameObject popUpTextResist;
    public GameObject popUpText;
    public Canvas newSpellBlinker;
    public Projector projector;
    public InputField inputField;
    public static bool pAttack;
    public string spell;
    public string choix;
    public bool choixOffDef;
    //Affichage de sort et Efficace/Resistant
    public bool animSortLance;
    private GameObject clone;
    public GameObject Gemme;
    private bool affichageEff;
    private bool affichageRes;

    private Animator mAnimator;
    public int tempsSansAppuyé = 0;
    public GameObject spellsPanel;
    public TextMeshProUGUI spellsList;
    public Image shieldSpriteImage;
    private SpellDatabase spellBook = new SpellDatabase();
    List<SpellStorageEntry> spellListStorage = new List<SpellStorageEntry> { };
    private string spellList = "Sorts du grimoire :\n";
    bool isCapsLockOn;
    private GameObject monstreSelectionne;
    [DllImport("user32.dll")]
    public static extern short GetKeyState(int keyCode);
    // Start is called before the first frame update
    void Start()
    {

        PopUpTextController.Initialize();

        //Initialisation du spellbook
        mAnimator = GetComponent<Animator>();
        foreach (SpellEntry spellEntry in spellBook.SpellBook)
        {
            var sName = spellEntry.spellName;
            var hColor = XmlManager.ins.ElementDatabase.Elementdb.Find(x => x.elementName.Equals(spellEntry.element)).hexColor;
            if (spellEntry.spellName.ToLower().Equals(spellEntry.spellName)) //If spell is lowercase
            {
                spellListStorage.Add(new SpellStorageEntry(spell.ToLower(), spellEntry.value, -1));
            }
            else
            {
                spellListStorage.Add(new SpellStorageEntry(spell.ToLower(), -1, spellEntry.value));
            }
            spellListStorage.Sort(delegate(SpellStorageEntry s1, SpellStorageEntry s2) {return s1.nom.CompareTo(s2.nom);});
            spellList += "<color=" + hColor + ">" + sName + "</color> \n";
        }
        spellsList.text = spellList;
        isCapsLockOn = (((ushort)GetKeyState(0x14)) & 0xffff) != 0;//init stat

        //Transparence du sprite du bouclier
        var tempColor = shieldSpriteImage.color;
        tempColor.a = 0f;
        shieldSpriteImage.color = tempColor;

        newSpellBlinker.enabled = false; //Eteint le symbole qui clignotte
    }



    // Update is called once per frame
    void Update()
    {
        GameObject[] ListeMonstre = GameObject.FindGameObjectsWithTag("Ennemy");
        foreach (GameObject monstre in ListeMonstre)
        {
            if (monstre.GetComponent<MonsterMouvSelection>().distanceToPlayer <= 22)
            {
                if (monstre.GetComponent<MonsterMouvSelection>().estSelectionne)
                {
                    monstreSelectionne = monstre;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            isCapsLockOn = !isCapsLockOn;
        }

        projector.material.SetColor("_Color", new Color32(255, 255, 255, 255));

        if (ClickToMove.selectionne && monstreSelectionne != null && monstreSelectionne.GetComponent<MonsterMouvSelection>().distanceToPlayer <= 20)
        {
            inputField.ActivateInputField();
            spell = inputField.text;
            Text text = inputField.transform.Find("Text").GetComponent<Text>();

            if (string.Compare(spell,"") != 0)
            {
                if (spell[0].Equals('a') || spell[0].Equals('A'))
                {
                    text.color = new Color32(28, 33, 238, 255); //BLEU EAU
                    projector.material.SetColor("_Color", new Color32(0, 82, 255, 255));
                }
                else if (spell[0].Equals('u') || spell[0].Equals('U'))
                {
                    text.color = new Color32(243, 64, 18, 255); //ROUGE FEU
                    projector.material.SetColor("_Color", text.color);
                }
                else if (spell[0].Equals('e') || spell[0].Equals('E'))
                {
                    text.color = new Color32(75, 4, 88, 255); //MAUVE AIR
                    projector.material.SetColor("_Color", text.color);
                }
                else if (spell[0].Equals('o') || spell[0].Equals('O'))
                {
                    text.color = new Color32(2, 87, 13,255); //MARRON TERRE
                    projector.material.SetColor("_Color", new Color32(5, 252, 17, 255));
                }
                else if (spell[0].Equals('i') || spell[0].Equals('I'))
                {
                    text.color = new Color32(255, 234, 0, 255); //JAUNE ELEC
                    projector.material.SetColor("_Color", text.color);
                }
                else
                {
                    text.color = new Color32(0, 0, 0, 255);
                    
                    projector.material.SetColor("_Color", new Color32(255, 255, 255, 255));
                }

            }

            //Affichage de l'indicateur de majuscule
            if ( (Input.GetKey("left shift") && !isCapsLockOn) || (Input.GetKey("right shift") && !isCapsLockOn) || isCapsLockOn )
            {
                var tempColor = shieldSpriteImage.color;
                tempColor.a = 1f;
                shieldSpriteImage.color = tempColor;
            }
            else if(!Input.GetKey("left shift") && !isCapsLockOn && !Input.GetKey("right shift"))
            {
                var tempColor = shieldSpriteImage.color;
                tempColor.a = 0f;
                shieldSpriteImage.color = tempColor;
            }

            SpellEntry spellEntry = XmlManager.ins.SpellDatabase.SpellBook.Find(x => x.spellName.Equals(spell));
            if (spellEntry != null) //Test pour savoir si le sort est valide
            {
                choix = spellEntry.spellName;
                choixOffDef = spellEntry.offensive;
                pAttack = true;
                //Mise à jour du spellbook du joueur;
                if (!(spellBook.SpellBook.Exists(x => x.spellName.Equals(spell)))) //Ne cherche que parmis les sorts offensifs
                {
                    newSpellBlinker.enabled = true; //Allume le symbole qui clignotte
                    spellBook.SpellBook.Add(XmlManager.ins.SpellDatabase.SpellBook.Find(x => x.spellName.Equals(spell))); //Ajout au sort au spellbook
                    bool present = false;
                    //Ajout à la spellListStorage
                        int i = 0;
                    foreach (SpellStorageEntry sse in spellListStorage)
                    {
                        Debug.Log("bonjour");
                        i++;
                        if (sse.nom.Equals(spell.ToLower()))
                        {
                            Debug.Log("Sort présent");
                            present = true;
                            if (spell.ToLower().Equals(spell))
                            {
                                sse.valAtk = spellEntry.value;
                            }
                            else
                            {
                                sse.valDef = spellEntry.value;
                            }
                            sse.nouveau = true;
                        }
                    }
                    if (!present)
                    {
                        Debug.Log("Nouveau sort");
                        if (spell.ToLower().Equals(spell))
                        {
                            spellListStorage.Add(new SpellStorageEntry(spell.ToLower(),spellEntry.value,-1));
                        }
                        else
                        {
                            spellListStorage.Add(new SpellStorageEntry(spell.ToLower(),-1,spellEntry.value));
                        }
                    }
                    spellListStorage.Sort(delegate(SpellStorageEntry s1, SpellStorageEntry s2) {return s1.nom.CompareTo(s2.nom);});
                    spellList = "Sorts du grimoire :\n";
                    foreach (SpellStorageEntry sse in spellListStorage)
                    {
                        string nouvmark = "";
                        string valAtk= "<sprite=2>";
                        string valDef ="<sprite=2>";
                        if (sse.nouveau)
                        {
                            nouvmark = "<sprite=0> ";
                        }
                        if (sse.valAtk >= 0)
                        {
                            valAtk = sse.valAtk.ToString();
                        }
                        if (sse.valDef >= 0)
                        {
                            valDef = sse.valDef.ToString();
                        }

                        spellList += nouvmark + "<color=" + XmlManager.ins.ElementDatabase.Elementdb.Find(x => x.elementName.Equals(XmlManager.ins.SpellDatabase.SpellBook.Find(y => y.spellName.Equals(sse.nom)).element)).hexColor + ">" + sse.nom.ToLower() + "</color>     <sprite=3>  " + valAtk + "  |    <sprite=1>  " + valDef + "  \n";
                    }   
                    spellsList.text = spellList;
                    
                }
                if (spellEntry.offensive) //SI le sort est offensif
                {
                    if (monstreSelectionne.GetComponent<MonsterStatText>().weakness.Equals(spellEntry.element)) //Si le monstre est faible contre l'élément du sort
                    {
                        affichageEff = true;
                        monstreSelectionne.GetComponent<MonsterStatText>().PV -= (int)(1.5 * spellEntry.value);
                        Debug.Log((int)(1.5 * spellEntry.value));
                    }
                    else if (monstreSelectionne.GetComponent<MonsterStatText>().resistance.Equals(spellEntry.element)) //Si le monstre est résistant contre l'élément du sort
                    {
                        monstreSelectionne.GetComponent<MonsterStatText>().PV -= (int)(0.5 * spellEntry.value);
                        Debug.Log((int)(0.5 * spellEntry.value));
                        affichageRes = true;
                    }
                    else //Si le monstre est neutre contre l'élément du sort
                    {
                        monstreSelectionne.GetComponent<MonsterStatText>().PV -= spellEntry.value;
                        Debug.Log(spellEntry.value);
                    }

                    spell = "";
                    inputField.text = "";
                }

                else //Si le sort est défensif
                {
                    PlayerStats.shieldElement = spellEntry.element;
                    PlayerStats.playerShieldPoints = spellEntry.value;
                    GetComponent<PlayerStats>().playerMaxShieldPoints = spellEntry.value;
                    spell = "";
                    inputField.text = "";
                }
            }

            //FIN

            if (!Input.anyKey)
            {
                tempsSansAppuyé = tempsSansAppuyé + 1; //CompteurJoueurN'appuiePas
            }
            else
            {
                tempsSansAppuyé = 0;
            }

            if (tempsSansAppuyé >= 120 && spell != "") //Reset sort au bout de 3 secondes
            {
                tempsSansAppuyé = 0;
                spell = "";
                inputField.text = "";
                Debug.Log("Saisie de sort reset");
            }


        }
        else
        {
            inputField.DeactivateInputField(); //On ne peut plus taper de sorts
            var tempColor = shieldSpriteImage.color;
            tempColor.a = 0f;
            shieldSpriteImage.color = tempColor;
        }

        if (Input.GetKeyDown("tab"))
        {
            spellsPanel.SetActive(true);
            newSpellBlinker.enabled = false; //Eteint le symbole qui clignotte
            foreach (SpellStorageEntry sse in spellListStorage)
            {
                sse.nouveau = false;
            }
        }
        else if (Input.GetKeyUp("tab"))
        {
            spellsPanel.SetActive(false);
            spellList = "Sorts du grimoire :\n";
            foreach (SpellStorageEntry sse in spellListStorage)
            {
                string nouvmark = "";
                string valAtk = "<sprite=2>";
                string valDef = "<sprite=2>";
                if (sse.nouveau)
                {
                    nouvmark = "<sprite=0> ";
                }
                if (sse.valAtk >= 0)
                {
                    valAtk = sse.valAtk.ToString();
                }
                if (sse.valDef >= 0)
                {
                    valDef = sse.valDef.ToString();
                }

                spellList += nouvmark + "<color=" + XmlManager.ins.ElementDatabase.Elementdb.Find(x => x.elementName.Equals(XmlManager.ins.SpellDatabase.SpellBook.Find(y => y.spellName.Equals(sse.nom)).element)).hexColor + ">" + sse.nom.ToLower() + "</color>     <sprite=3>  " + valAtk + "  |    <sprite=1>  " + valDef + "  \n";
            }
            spellsList.text = spellList;
        }
        StartCoroutine(WaitForAnimation());
    }



    private IEnumerator WaitForAnimation()
    {
        if (pAttack && choixOffDef)
        {
            GameObject sortAnim = GameObject.Find("O" + choix + "Anim");
            mAnimator.SetTrigger("Attack1Trigger");
            yield return new WaitForSeconds(0.5f);
            if (!animSortLance)
            {
                clone = Instantiate(sortAnim, Gemme.transform.position, Quaternion.identity);
                clone.tag = "ADetruire";
                animSortLance = true;
            }
            yield return new WaitForSeconds(0.1f);
            if(affichageEff) //Si le monstre est faible contre l'élément du sort
            {
                GameObject instance = Instantiate(popUpText, monstreSelectionne.transform.position, Quaternion.identity);
                for (int i = 0; i < monstreSelectionne.transform.childCount - 1; i++)
                {
                    if (monstreSelectionne.transform.GetChild(i).transform.name == "UICanvas")
                    {
                        instance.transform.SetParent(monstreSelectionne.transform.GetChild(i).transform, false);
                        instance.transform.position = monstreSelectionne.transform.position;
                        affichageEff = false;
                    }
                }
            }
            if (affichageRes) //Si le monstre est resistant contre l'élément du sort
            {
                GameObject instance = Instantiate(popUpTextResist, monstreSelectionne.transform.position, Quaternion.identity);
                for (int i = 0; i < monstreSelectionne.transform.childCount - 1; i++)
                {
                    if (monstreSelectionne.transform.GetChild(i).transform.name == "UICanvas")
                    {
                        instance.transform.SetParent(monstreSelectionne.transform.GetChild(i).transform, false);
                        instance.transform.position = monstreSelectionne.transform.position;
                        affichageRes = false;
                    }
                }
            }
            yield return new WaitForSeconds(0.2f);
            pAttack = false;
            Destroy(clone);
            yield return new WaitForSeconds(0.5f);
            animSortLance = false;
        }
        if (pAttack && !choixOffDef)
        {
            GameObject sortAnim = GameObject.Find("D" + choix + "Anim");
            mAnimator.SetTrigger("Attack1Trigger");
            yield return new WaitForSeconds(0.5f);
            if (!animSortLance)
            {
                clone = Instantiate(sortAnim, Gemme.transform.position, Quaternion.identity);
                clone.tag = "ADetruire";
                animSortLance = true;
            }
            yield return new WaitForSeconds(0.5f);
            pAttack = false;
            Destroy(clone);
            yield return new WaitForSeconds(0.5f);
            animSortLance = false;
        }
        if (!ClickToMove.selectionne)
        {
            Debug.Log("oui");
            GameObject[] aDetruire = GameObject.FindGameObjectsWithTag("ADetruire");
            foreach (GameObject s in aDetruire)
               Destroy(s);
        }
    }

    public class SpellStorageEntry{
        public string nom;
        public int valAtk;
        public int valDef;
        public bool nouveau;

        public SpellStorageEntry(string nom, int atk, int def){
            this.nom = nom;
            this.valAtk = atk;
            this.valDef = def;
            this.nouveau = true;
        }

        public override string ToString(){
            return this.nom;
        }
    }
    
}
