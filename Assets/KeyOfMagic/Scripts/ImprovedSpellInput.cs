using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;

public class ImprovedSpellInput : MonoBehaviour
{
    public Canvas newSpellBlinker;
    public Projector projector;
    public InputField inputField;
    public string spell;
    public int tempsSansAppuyé = 0;
    public GameObject spellsPanel;
    public Text spellsList;
    public Image shieldSpriteImage;
    private SpellDatabase spellBook = new SpellDatabase();
    List<string> spellListStorage = new List<string> { };
    private string spellList = "Known spells :\n";
    bool isCapsLockOn;
    private Animator mAnimator;
    [DllImport("user32.dll")]
    public static extern short GetKeyState(int keyCode);
    // Start is called before the first frame update
    void Start()
    {
        //Initialisation du spellbook

        foreach (SpellEntry spellEntry in spellBook.SpellBook)
        {
            var sName = spellEntry.spellName;
            var hColor = XmlManager.ins.ElementDatabase.Elementdb.Find(x => x.elementName.Equals(spellEntry.element)).hexColor;
            spellListStorage.Add(sName);
            spellListStorage.Sort();
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
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            isCapsLockOn = !isCapsLockOn;
        }

        projector.material.SetColor("_Color", new Color32(255, 255, 255, 255));

        if (GetComponent<ClickToMove>().selectionne)
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
                else if (spell[0].Equals('e') || spell[0].Equals('e'))
                {
                    text.color = new Color32(75, 4, 88, 255); //MAUVE AIR
                    projector.material.SetColor("_Color", text.color);
                }
                else if (spell[0].Equals('o') || spell[0].Equals('O'))
                {
                    text.color = new Color32(78, 52, 46, 255); //MARRON TERRE
                    projector.material.SetColor("_Color", text.color);
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
               
                //Mise à jour du spellbook du joueur;
                if (!(spellBook.SpellBook.Exists(x => x.spellName.Equals(spell.ToLower())))) //Ne cherche que parmis les sorts offensifs
                {
                    newSpellBlinker.enabled = true; //Allume le symbole qui clignotte
                    spellBook.SpellBook.Add(XmlManager.ins.SpellDatabase.SpellBook.Find(x => x.spellName.Equals(spell.ToLower()))); //Ajoute la version offensive du sort au spellbook
                    spellListStorage.Add(spell.ToLower());
                    spellListStorage.Sort();
                    spellList = "Known spells :\n";
                    foreach (string s in spellListStorage)
                    {
                        spellList += "<color=" + XmlManager.ins.ElementDatabase.Elementdb.Find(x => x.elementName.Equals(XmlManager.ins.SpellDatabase.SpellBook.Find(y => y.spellName.Equals(s)).element)).hexColor + ">" + s.ToLower() + "</color>\n";
                    }   
                    spellsList.text = spellList;
                }
                if (spellEntry.offensive) //SI le sort est offensif
                {
                    ClickToMove.pAttack = true;
                    GameObject[] ListeMonstre = GameObject.FindGameObjectsWithTag("Ennemy");
                    foreach (GameObject monstre in ListeMonstre)
                    {
                        if (monstre.GetComponent<MonsterMouvSelection>().distanceToPlayer <= 20)
                        {
                            if (monstre.GetComponent<MonsterMouvSelection>().estSelectionne)
                            {

                                if (monstre.GetComponent<MonsterStatText>().weakness.Equals(spellEntry.element)) //Si le monstre est faible contre l'élément du sort
                                {
                                    monstre.GetComponent<MonsterStatText>().PV -= (int)(1.5 * spellEntry.value);
                                    Debug.Log((int)(1.5 * spellEntry.value));
                                }
                                else if (monstre.GetComponent<MonsterStatText>().resistance.Equals(spellEntry.element)) //Si le monstre est résistant contre l'élément du sort
                                {
                                    monstre.GetComponent<MonsterStatText>().PV -= (int)(0.5 * spellEntry.value);
                                    Debug.Log((int)(0.5 * spellEntry.value));
                                }
                                else //Si le monstre est neutre contre l'élément du sort
                                {
                                    monstre.GetComponent<MonsterStatText>().PV -= spellEntry.value;
                                    Debug.Log(spellEntry.value);
                                }

                                spell = "";
                                inputField.text = "";
                            }
                        }
                    }
                }

                else //Si le sort est défensif
                {
                    GameObject[] ListeMonstre = GameObject.FindGameObjectsWithTag("Ennemy");
                    foreach (GameObject monstre in ListeMonstre)
                    {
                        if (monstre.GetComponent<MonsterMouvSelection>().distanceToPlayer <= 20)
                        {
                            if (monstre.GetComponent<MonsterMouvSelection>().estSelectionne)
                            {
                                PlayerStats.shieldElement = spellEntry.element;
                                PlayerStats.playerShieldPoints = spellEntry.value;
                                GetComponent<PlayerStats>().playerMaxShieldPoints = spellEntry.value;
                                spell = "";
                                inputField.text = "";
                            }
                        }
                    }
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
        }
        else if (Input.GetKeyUp("tab"))
        {
            spellsPanel.SetActive(false);
        }
    }
/*     public void ValueChangeCheck()
    {
        Debug.Log("Value Changed");
    } */
}
