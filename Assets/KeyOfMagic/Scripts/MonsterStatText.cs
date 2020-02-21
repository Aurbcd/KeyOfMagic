using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatText : MonoBehaviour
{
    public string monsterName;
    public float PV = 150;
    public float PVMax = 200;

    public GameObject TextName;

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
    }
}
