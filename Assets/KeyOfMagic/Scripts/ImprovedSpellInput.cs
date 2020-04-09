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
    public GameObject GemmeA;
    public GameObject GemmeD;
    private bool affichageEff;
    private bool affichageRes;
    private GameObject sortAnim;
    public List<GameObject> VisuelSorts;
    public Material[] MatBaguette;
    Renderer rendBag;

    //Mécanique d'objet sur l'hésitation
    public static int tempsReset;

    private Animator mAnimator;
    public int tempsSansAppuyé = 0;
    public GameObject spellsPanel;
    public TextMeshProUGUI spellsList;
    public Image shieldSpriteImage;
    private SpellDatabase spellBook;
    public List<SpellStorageEntry> spellListStorage = new List<SpellStorageEntry> { };
    private string spellList = "Sorts du grimoire :\n";
    bool isCapsLockOn;
    private GameObject monstreSelectionne;
    [DllImport("user32.dll")]
    public static extern short GetKeyState(int keyCode);
    // Start is called before the first frame update
    void Start()
    {
        tempsReset = 120;
        PopUpTextController.Initialize();
        rendBag = gameObject.transform.GetChild(3).transform.GetChild(2).GetComponent<Renderer>();
        //Initialisation du spellbook
        mAnimator = GetComponent<Animator>();
        spellBook = XmlManager.ins.PlayerSpellDatabase;
        foreach (SpellEntry spellEntry in spellBook.SpellBook)
        {
            bool present = false;
            //Ajout à la spellListStorage
                    Debug.Log("coucou");
            foreach (SpellStorageEntry sse in spellListStorage)
            {
                if (sse.nom.Equals(spellEntry.spellName.ToLower()))
                {
                    present = true;
                }
            }
                if (!present)
                {
                    spellListStorage.Add(new SpellStorageEntry(spellEntry.spellName.ToLower(), -1, -1));
                }
                spellListStorage.Sort(delegate (SpellStorageEntry s1, SpellStorageEntry s2) { return s1.nom.CompareTo(s2.nom); });
        }
            spellList = "Sorts du grimoire :\n";
            foreach (SpellStorageEntry nsse in spellListStorage)
            {
                spellList += "<sprite=0> " + "<color=" + XmlManager.ins.ElementDatabase.Elementdb.Find(x => x.elementName.Equals(XmlManager.ins.SpellDatabase.SpellBook.Find(y => y.spellName.Equals(nsse.nom)).element)).hexColor + ">" + nsse.nom.ToLower() + "</color>     <sprite=3>  " + "<sprite=2>" + "  |    <sprite=1>  " + "<sprite=2>" + "  \n";
            }
            spellsList.text = spellList;
        isCapsLockOn = (((ushort)GetKeyState(0x14)) & 0xffff) != 0;//init stat

        //Transparence du sprite du bouclier
        var tempColor = shieldSpriteImage.color;
        tempColor.a = 0f;
        shieldSpriteImage.color = tempColor;

        newSpellBlinker.enabled = false; //Eteint le symbole qui clignotte
}

    public void Hit()
    {
        GameObject[] ListeMonstre = GameObject.FindGameObjectsWithTag("Ennemy");
        foreach (GameObject monstre in ListeMonstre)
        {
            if (monstre.GetComponent<MonsterMouvSelection>().distanceToPlayer <= 22)
            {
                if (monstre.GetComponent<MonsterMouvSelection>().estSelectionne)
                {
                    monstre.GetComponent<Animator>().SetTrigger("Hit");
                }
            }
        }
    }
    public void SpellAff()
    {
        sortAnim = VisuelSorts.Find(x => x.ToString().Equals("O" + choix + "Anim" + " (UnityEngine.GameObject)"));
        if (!animSortLance)
        {
            clone = Instantiate(sortAnim, GemmeA.transform.position, Quaternion.identity);
            clone.transform.position = GemmeA.transform.position;
            clone.tag = "ADetruire";
            animSortLance = true;
        }
    }
    public void DefAff()
    {
        sortAnim = VisuelSorts.Find(x => x.ToString().Equals("D" + choix + "Anim" + " (UnityEngine.GameObject)"));
        if (!animSortLance)
        {
            clone = Instantiate(sortAnim, GemmeD.transform.position, Quaternion.identity);
            clone.tag = "ADetruire";
            animSortLance = true;
        }
        animSortLance = false;
    }
    public void AffEffRest()
    {
        if (affichageEff) //Si le monstre est faible contre l'élément du sort
        {
            //Calcul du décalage de l'affichage des popuptexts
            int hauteur = (int)monstreSelectionne.GetComponent<BoxCollider>().size.y;
            Vector3 decallage = new Vector3(0f, 0f, 0f);
            if (hauteur > 4)
            {
                decallage.y += (float)hauteur - 3;
            }
            GameObject instance = Instantiate(popUpText, monstreSelectionne.transform.position, Quaternion.identity);
            for (int i = 0; i < monstreSelectionne.transform.childCount - 1; i++)
            {
                if (monstreSelectionne.transform.GetChild(i).transform.name == "UICanvas")
                {
                    instance.transform.SetParent(monstreSelectionne.transform.GetChild(i).transform, false);
                    instance.transform.position = monstreSelectionne.transform.position + decallage;
                    affichageEff = false;
                }
            }
        }

        if (affichageRes) //Si le monstre est resistant contre l'élément du sort
        {
            GameObject instance = Instantiate(popUpTextResist, monstreSelectionne.transform.position, Quaternion.identity);
            //Calcul du décalage de l'affichage des popuptexts
            int hauteur = (int)monstreSelectionne.GetComponent<BoxCollider>().size.y;
            Vector3 decallage = new Vector3(0f, 0f, 0f);
            if (hauteur > 4)
            {
                decallage.y += (float)hauteur - 3;
            }
            for (int i = 0; i < monstreSelectionne.transform.childCount - 1; i++)
            {
                if (monstreSelectionne.transform.GetChild(i).transform.name == "UICanvas")
                {
                    instance.transform.SetParent(monstreSelectionne.transform.GetChild(i).transform, false);
                    instance.transform.position = monstreSelectionne.transform.position + decallage;
                    affichageRes = false;
                }
            }
        }
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

        if (ClickToMove.selectionne && monstreSelectionne != null && monstreSelectionne.GetComponent<MonsterMouvSelection>().distanceToPlayer <= 20 && !PlayerStats.IsDead)
        {
            inputField.ActivateInputField();
            spell = inputField.text;
            Text text = inputField.transform.Find("Text").GetComponent<Text>();

            if (string.Compare(spell,"") != 0)
            {
                if (spell[0].Equals('a') || spell[0].Equals('A'))
                {
                    text.color = new Color32(28, 33, 238, 255); //BLEU EAU
                    rendBag.sharedMaterial = MatBaguette[0];
                    projector.material.SetColor("_Color", new Color32(0, 82, 255, 255));
                }
                else if (spell[0].Equals('u') || spell[0].Equals('U'))
                {
                    text.color = new Color32(243, 64, 18, 255); //ROUGE FEU
                    rendBag.sharedMaterial = MatBaguette[1];
                    projector.material.SetColor("_Color", text.color);
                }
                else if (spell[0].Equals('e') || spell[0].Equals('E'))
                {
                    text.color = new Color32(75, 4, 88, 255); //MAUVE AIR
                    rendBag.sharedMaterial = MatBaguette[3];
                    projector.material.SetColor("_Color", text.color);
                }
                else if (spell[0].Equals('o') || spell[0].Equals('O'))
                {
                    text.color = new Color32(2, 87, 13,255); //VERT TERRE
                    rendBag.sharedMaterial = MatBaguette[2];
                    projector.material.SetColor("_Color", new Color32(5, 252, 17, 255));
                }
                else if (spell[0].Equals('i') || spell[0].Equals('I'))
                {
                    text.color = new Color32(255, 234, 0, 255); //JAUNE ELEC
                    rendBag.sharedMaterial = MatBaguette[4];
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
                if (!(spellBook.SpellBook.Exists(x => x.spellName.Equals(spell)))) //Vérifie que ce sort n'appartient pas au spellbook
                {
                    newSpellBlinker.enabled = true; //Allume le symbole qui clignotte
                    spellBook.SpellBook.Add(XmlManager.ins.SpellDatabase.SpellBook.Find(x => x.spellName.Equals(spell))); //Ajout au sort au spellbook
                    bool present = false;
                    //Ajout à la spellListStorage
                    foreach (SpellStorageEntry sse in spellListStorage)
                    {
                        if (sse.nom.Equals(spell.ToLower()))
                        {
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
                else
                {
                    foreach (SpellStorageEntry sse in spellListStorage)
                    {
                        if (sse.nom.Equals(spell.ToLower()) && (sse.valAtk == -1 || sse.valDef == -1))
                        {
                            newSpellBlinker.enabled = true; //Allume le symbole qui clignotte
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
                if (spellEntry.offensive) //SI le sort est offensif
                {
                    mAnimator.Play("RedoA", 0, 1);
                    if (monstreSelectionne.GetComponent<MonsterStatText>().weakness.Equals(spellEntry.element)) //Si le monstre est faible contre l'élément du sort
                    {
                        affichageEff = true;
                        monstreSelectionne.GetComponent<MonsterStatText>().PV -= (int)((1.5 * spellEntry.value)*PlayerStats.DamageMultiplier);
                        PlayerStats.playerHealthPoints += (int)((1.5 * spellEntry.value) * PlayerStats.DamageMultiplier * PlayerStats.volDeVie);
                        Debug.Log((int)(1.5 * spellEntry.value));
                    }
                    else if (monstreSelectionne.GetComponent<MonsterStatText>().resistance.Equals(spellEntry.element)) //Si le monstre est résistant contre l'élément du sort
                    {
                        monstreSelectionne.GetComponent<MonsterStatText>().PV -= (int)((0.5 * spellEntry.value) * PlayerStats.DamageMultiplier);
                        PlayerStats.playerHealthPoints += (int)((0.5 * spellEntry.value) * PlayerStats.DamageMultiplier * PlayerStats.volDeVie);
                        Debug.Log((int)(0.5 * spellEntry.value));
                        affichageRes = true;
                    }
                    else //Si le monstre est neutre contre l'élément du sort
                    {
                        monstreSelectionne.GetComponent<MonsterStatText>().PV -= (int)(spellEntry.value * PlayerStats.DamageMultiplier);
                        PlayerStats.playerHealthPoints += (int)(spellEntry.value * PlayerStats.DamageMultiplier * PlayerStats.volDeVie);
                        Debug.Log(spellEntry.value);
                    }

                    spell = "";
                    inputField.text = "";
                }

                else //Si le sort est défensif
                {
                    mAnimator.Play("RedoD", 0, 1);
                    PlayerStats.shieldElement = spellEntry.element;
                    GetComponent<PlayerStats>().playerMaxShieldPoints = (int)(spellEntry.value * PlayerStats.shieldMultiplier);
                    PlayerStats.playerShieldPoints =(int)(spellEntry.value * PlayerStats.shieldMultiplier);
                    spell = "";
                    inputField.text = "";
                }
            }

            //FIN
            animSortLance = false;
            if (!Input.anyKey)
            {
                tempsSansAppuyé = tempsSansAppuyé + 1; //CompteurJoueurN'appuiePas
            }
            else
            {
                tempsSansAppuyé = 0;
            }

            if (tempsSansAppuyé >= tempsReset && spell != "") //Reset sort au bout de 3 secondes
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
    if (!ClickToMove.selectionne)
    {
        GameObject[] aDetruire = GameObject.FindGameObjectsWithTag("ADetruire");
        foreach (GameObject s in aDetruire)
            Destroy(s);
    }
        if (PlayerStats.IsDead)
        {
            inputField.text = "";
        }
}



    [System.Serializable]
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
