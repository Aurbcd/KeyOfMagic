using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Saisiespell : MonoBehaviour
{

    public string spell;
    bool lancerspell;
    List<string> list = new List<string> {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
"q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

    // Start is called before the first frame update
    void Start()
    {
        bool lancerspell = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("tab")){
            lancerspell=!lancerspell;
            Debug.Log("lancer spell = " + lancerspell);
            System.Threading.Thread.Sleep(200);
        }
        if (Input.GetKey("space"))
        {
            spell = "";
            Debug.Log("mot reset");
            System.Threading.Thread.Sleep(200);
        }
        if (lancerspell)
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
                    System.Threading.Thread.Sleep(200);
                    if (Estunsort(spell))
                    {
                        spell = "";
                        Debug.Log("c'est un spell connu");
                    }
                }
            }
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
