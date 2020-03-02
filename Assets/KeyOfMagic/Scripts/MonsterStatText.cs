using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatText : MonoBehaviour
{
    public string monsterName;
    public int PV = 150;
    public int PVMax = 200;

    public GameObject TextName;
    public GameObject SpriteSelection;

    public HealthBar BarreDeVie;
    private CanvasGroup Barre;


    // Start is called before the first frame update
    void Start()
    {
        BarreDeVie.SetMaxHealth(PVMax);
        BarreDeVie.SetHealth(PV);
        Barre = BarreDeVie.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TextName != null)
        {
            TextName.transform.LookAt(Camera.main.transform.position);
            TextName.transform.Rotate(0, 180, 0);
            BarreDeVie.SetHealth(PV);                                                                                       //Update barre de vie
            TextName.GetComponent<TextMesh>().text = "" + monsterName + " | " + PV;  //EN ATTENDANT UNE BARRE DE VIE
        }

        if (gameObject.GetComponent<MonsterMouvSelection>().estSelectionne)                                        // Quand le monstre est sélectionné
        {
            SpriteSelection.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.75f); //Aligner sprite
            SpriteSelection.transform.LookAt(Camera.main.transform.position);
            SpriteSelection.transform.Rotate(0, 180, 0);

            //Barre.GetComponent<CanvasRenderer>().SetAlpha(0.5f);                                                                      // Aligner Barre

            Barre.alpha = 0.5f;
/*             Barre.transform.LookAt(Camera.main.transform.position);
            Barre.transform.Rotate(0, 180, 0); */
        }
        if(gameObject.GetComponent<MonsterMouvSelection>().estSelectionne == false)
        {
            SpriteSelection.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
            //Barre.GetComponent<CanvasRenderer>().SetAlpha(0f);
            Barre.alpha = 0f;
        }
    }
}
