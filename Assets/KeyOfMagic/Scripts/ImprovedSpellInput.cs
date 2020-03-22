using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;

public class ImprovedSpellInput : MonoBehaviour
{
    public InputField inputField;
    public string spell;
    public int tempsSansAppuyé = 0;
    public GameObject spellsPanel;
    public Text spellsList;
    public Image shieldSpriteImage;
    bool isCapsLockOn;
    [DllImport("user32.dll")]
    public static extern short GetKeyState(int keyCode);
    // Start is called before the first frame update
    void Start()
    {
        string spellList = "Spell List :\n";
        foreach (SpellEntry spellEntry in XmlManager.ins.SpellDatabase.SpellBook)
        {
            if (spellEntry.element.Equals("Eau"))
            {
                spellList += "<color=#1c21ee>" + spellEntry.spellName + "</color>\n";
            }
            if (spellEntry.element.Equals("Feu"))
            {
                spellList += "<color=#f34012>" + spellEntry.spellName + "</color>\n";
            }
            if (spellEntry.element.Equals("Air"))
            {
                spellList += "<color=#4b0458>" + spellEntry.spellName + "</color>\n";
            }
            if (spellEntry.element.Equals("Terre"))
            {
                spellList += "<color=#4e342e>" + spellEntry.spellName + "</color>\n";
            }
            if (spellEntry.element.Equals("Electricite"))
            {
                spellList += "<color=#ffea00>" + spellEntry.spellName + "</color>\n";
            }

        }
        Debug.Log(spellList);
        spellsList.text = spellList;

        //   inputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });  //Invoque la méthode ValueChangeCheck lorsque la valeur est changée 

        isCapsLockOn = (((ushort)GetKeyState(0x14)) & 0xffff) != 0;//init stat
        var tempColor = shieldSpriteImage.color;
        tempColor.a = 0f;
        shieldSpriteImage.color = tempColor;

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            isCapsLockOn = !isCapsLockOn;
        }
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
                }
                else if (spell[0].Equals('u') || spell[0].Equals('U'))
                {
                    text.color = new Color32(243, 64, 18, 255); //ROUGE FEU
                }
                else if (spell[0].Equals('e') || spell[0].Equals('e'))
                {
                    text.color = new Color32(75, 4, 88, 255); //MAUVE AIR
                }
                else if (spell[0].Equals('o') || spell[0].Equals('O'))
                {
                    text.color = new Color32(78, 52, 46, 255); //MARRON TERRE
                }
                else if (spell[0].Equals('i') || spell[0].Equals('I'))
                {
                    text.color = new Color32(255, 234, 0, 255); //JAUNE ELEC
                }
                else
                {
                    text.color = new Color32(0, 0, 0, 255);
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


            foreach (SpellEntry spellEntry in XmlManager.ins.SpellDatabase.SpellBook)
            {
                if (spell.Equals(spellEntry.spellName))
                {
                    if (spellEntry.offensive) //SI le sort est offensif
                    {
                        GameObject[] ListeMonstre = GameObject.FindGameObjectsWithTag("Ennemy");
                        foreach (GameObject monstre in ListeMonstre)
                        {
                            if (monstre.GetComponent<MonsterMouvSelection>().distanceToPlayer <= 20)
                            {
                                if (monstre.GetComponent<MonsterMouvSelection>().estSelectionne)
                                {

                                    if (monstre.GetComponent<MonsterStatText>().weakness.Equals(spellEntry.element)) //Si le monstre est faible contre l'élément du sort
                                    {
                                        monstre.GetComponent<MonsterStatText>().PV -= (int) (1.5*spellEntry.value);
                                        Debug.Log(monstre.GetComponent<MonsterStatText>().weakness.Equals(spellEntry.element));
                                        Debug.Log((int)(1.5 * spellEntry.value));
                                    }
                                    else if (monstre.GetComponent<MonsterStatText>().resistance.Equals(spellEntry.element)) //Si le monstre est résistant contre l'élément du sort
                                    {
                                        monstre.GetComponent<MonsterStatText>().PV -= (int) (0.5 * spellEntry.value);
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
                        //METTRE LES EFFETS DU SORT
                        GetComponent<PlayerStats>().shieldElement = spellEntry.element;
                        GetComponent<PlayerStats>().playerShieldPoints = spellEntry.value;
                        GetComponent<PlayerStats>().playerMaxShieldPoints = spellEntry.value;
                        //METTRE LES EFFETS DU SORT
                        spell = "";
                        inputField.text = "";
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
