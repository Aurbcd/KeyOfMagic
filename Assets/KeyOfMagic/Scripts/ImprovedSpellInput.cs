using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ImprovedSpellInput : MonoBehaviour
{
    public InputField inputField;
    public string spell;
    public int tempsSansAppuyé = 0;
    public GameObject spellsPanel;
    public GameObject spellsText;

    // Start is called before the first frame update
    void Start()
    {
        StreamReader sr = new StreamReader("spells.txt");
        string line = sr.ReadLine();
        string spells = "";
        while (line != null)
        {
            spells += line + "\n";
            line = sr.ReadLine();
        }
        sr.Close();

        spellsText.GetComponent<Text>().text = spells;

     //   inputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });  //Invoque la méthode ValueChangeCheck lorsque la valeur est changée 

        inputField.customCaretColor = true;


    }



    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ClickToMove>().selectionne)
        {
            inputField.ActivateInputField();
            spell = inputField.text;
            Text text = inputField.transform.Find("Text").GetComponent<Text>();

            if (string.Compare(spell,"") != 0)
            {
                if (spell[0].Equals('a') || spell[0].Equals('A'))
                {
                    text.color = new Color32(0, 28, 240, 255);
                }
                else
                {
                    text.color = new Color32(0, 0, 0, 255);
                }

            }

            if (Estunsort(spell))
            {

                if (string.Compare(spell,"amoi") == 0) // SORT
                {
                    GameObject[] ListeMonstre = GameObject.FindGameObjectsWithTag("Ennemy");
                    foreach (GameObject monstre in ListeMonstre)
                    {
                        if (monstre.GetComponent<MonsterMouvSelection>().distanceToPlayer <= 20)
                        {
                            if (monstre.GetComponent<MonsterMouvSelection>().estSelectionne)
                            {
                                //METTRE LES EFFETS DU SORT
                                monstre.GetComponent<MonsterStatText>().PV -= 10;
                                //METTRE LES EFFETS DU SORT
                                spell = "";
                            }
                        }
                    }
                }

                if (string.Compare(spell, "AMOI") == 0) // SORT
                {
                    //METTRE LES EFFETS DU SORT
                    GetComponent<PlayerStats>().shieldElement = "Eau";
                    GetComponent<PlayerStats>().playerShieldPoints = 100;
                    GetComponent<PlayerStats>().playerMaxShieldPoints = 100;
                    //METTRE LES EFFETS DU SORT
                    spell = "";
                }

                inputField.text = "";
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
            inputField.DeactivateInputField();
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

    public static bool Estunsort(string spell)
    {
        StreamReader sr = new StreamReader("spells.txt");


        string line = sr.ReadLine();


        while (line != null)
        {
            if (line == spell)
            {
                sr.Close();
                return true;
            }
            line = sr.ReadLine();

        }
        sr.Close();
        return false;
    }

/*     public void ValueChangeCheck()
    {
        Debug.Log("Value Changed");
    } */
}
