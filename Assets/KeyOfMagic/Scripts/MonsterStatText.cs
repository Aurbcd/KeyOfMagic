using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatText : MonoBehaviour
{
    public string monsterName;
    public int PV = 150;
    public int PVMax = 200;

    public HealthBar Barre;
    public CanvasGroup CanvasGBarre;
    public GameObject TextName;
    public GameObject SpriteSelection;

    // Start is called before the first frame update
    void Start()
    {
        Barre.SetMaxHealth(PVMax);
        Barre.SetHealth(PV);
    }

    // Update is called once per frame
    void Update()
    {
        if (TextName != null)
        {
            TextName.transform.LookAt(Camera.main.transform.position);
            TextName.transform.Rotate(0, 180, 0);
            TextName.GetComponent<TextMesh>().text = "" + monsterName + " | " + PV;  //EN ATTENDANT UNE BARRE DE VIE
            Barre.SetHealth(PV);
        }

        if (gameObject.GetComponent<MonsterMouvSelection>().estSelectionne)
        {
            SpriteSelection.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.75f);
            SpriteSelection.transform.LookAt(Camera.main.transform.position);
            SpriteSelection.transform.Rotate(0, 180, 0);

            CanvasGBarre.alpha = 0.75f;
        }
        if(gameObject.GetComponent<MonsterMouvSelection>().estSelectionne == false)
        {
            SpriteSelection.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
            CanvasGBarre.alpha = 0f;
        }
    }
}
