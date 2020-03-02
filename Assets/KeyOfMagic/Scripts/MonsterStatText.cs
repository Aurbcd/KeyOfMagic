using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatText : MonoBehaviour
{
    public string monsterName;
    public float PV = 150;
    public float PVMax = 200;

    public GameObject TextName;
    public GameObject SpriteSelection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TextName != null)
        {
            TextName.transform.LookAt(Camera.main.transform.position);
            TextName.transform.Rotate(0, 180, 0);
            TextName.GetComponent<TextMesh>().text = "" + monsterName + " | " + PV;  //EN ATTENDANT UNE BARRE DE VIE
        }

        if (gameObject.GetComponent<MonsterMouvSelection>().estSelectionne)
        {
            SpriteSelection.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.75f);
            SpriteSelection.transform.LookAt(Camera.main.transform.position);
            SpriteSelection.transform.Rotate(0, 180, 0);
        }
        if(gameObject.GetComponent<MonsterMouvSelection>().estSelectionne == false)
        {
            SpriteSelection.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
        }
    }
}
