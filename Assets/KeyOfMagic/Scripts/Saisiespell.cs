using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Saisiespell : MonoBehaviour
{

    public string spell;
    List<string> list = new List<string> {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
"q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
    public int tempsSansAppuyé = 0;
    public GameObject spellsPanel;
    public GameObject spellsText;
    public static extern short EtatDeCaps(int keyCode);
    bool CapsOn = false;

    // Start is called before the first frame update
    void Start()
    {
        CapsOn = (((ushort)EtatDeCaps(0x14)) & 0xffff) != 0;

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
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            CapsOn = !CapsOn;
        }
        if (GetComponent<ClickToMove>().selectionne)
        {

            foreach (string vKey in list)
            {
                //if (spell != "")
                //{
                //GUI.TextField(new Rect(10, 10, 200, 20), spell, 25);
                //}
                if (Input.GetKey(vKey) & list.Contains(vKey.ToString()) & !Input.GetKey(KeyCode.LeftShift) & !CapsOn)
                {
                    spell += vKey;
                    Debug.Log(spell);
                    System.Threading.Thread.Sleep(150);
                }
                if (Input.GetKey(vKey) & list.Contains(vKey.ToString()) & (Input.GetKey(KeyCode.LeftShift) || CapsOn))
                {
                    spell += vKey.ToUpper();
                    Debug.Log(spell);
                    System.Threading.Thread.Sleep(150);
                }
                if (Estunsort(spell))
                {
                    if (spell == "amoi") // SORT
                    {
                        Debug.Log("oui");
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

                    if (spell == "AMOI") // SORT
                    {
                        //METTRE LES EFFETS DU SORT
                        PlayerStats.shieldElement = "Eau";
                        PlayerStats.playerShieldPoints = 100;
                        GetComponent<PlayerStats>().playerMaxShieldPoints = 100;
                        //METTRE LES EFFETS DU SORT
                        spell = "";
                    }
                }
            }

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
                Debug.Log("Saisie de sort reset");
            }
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
}
