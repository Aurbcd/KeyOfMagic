using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Saisiespell : MonoBehaviour
{

    public string spell;
    List<string> list = new List<string> {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
"q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    public int tempsSansAppuyé = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    public static Object FindObjectFromInstanceID(int iid)
    {
        return (Object)typeof(UnityEngine.Object)
                .GetMethod("FindObjectFromInstanceID", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                .Invoke(null, new object[] { iid });

    }
    // Update is called once per frame
    void Update()
    {
        foreach (string vKey in list)
        {
            if (spell != "")
            {
                //GUI.TextField(new Rect(10, 10, 200, 20), spell, 25);
            }
            if (Input.GetKey(vKey) & (list.Contains(vKey.ToString())))
            {
                spell += vKey;
                Debug.Log(spell);
                System.Threading.Thread.Sleep(150);
                if (Estunsort(spell))
                {                  
                    if (spell == "amoi") // SORT
                    {
                        GameObject[] ListeMonstre = GameObject.FindGameObjectsWithTag("Ennemy");
                        foreach (GameObject monstre in ListeMonstre)
                        {
                            if (monstre.GetComponent<MonsterMouvSelection>().distanceToPlayer < 20)
                            {
                                if (monstre.GetComponent<MonsterMouvSelection>().estSelectionne)
                                {
                                    //METTRE LES EFFETS DU SORT
                                    monstre.GetComponent<MonsterStatText>().PV -= 10;
                                    //METTRE LES EFFETS DU SORT
                                }
                            }
                        }
                    }

                    if (spell == "AMOI") // SORT
                    {
                        GetComponent<PlayerStats>().ShieldElement = "Eau";
                        GetComponent<PlayerStats>().playerShieldPoints += 100; 
                    }

                    spell = "";
                    Debug.Log("c'est un spell connu");
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

        if (tempsSansAppuyé == 120 && spell!="") //Reset sort au bout de 3 secondes
        {
            tempsSansAppuyé = 0;
            spell = "";
            Debug.Log("Saisie de sort reset");
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
