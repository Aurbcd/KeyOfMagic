using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStatText : MonoBehaviour
{
    public string monsterName;
    public int PV = 150;
    public int PVMax = 200;

    public HealthBar Barre;

    public CanvasGroup CanvasGBarre;

    public Text Text;

    // Start is called before the first frame update
    void Start()
    {
        Barre.SetMaxHealth(PVMax);
        Barre.SetHealth(PV);
    }

    // Update is called once per frame
    void Update()
    {
        Text.transform.LookAt(Camera.main.transform.position);
        Text.transform.Rotate(0, 180, 0);
        Text.text = "" + monsterName;
        Barre.SetHealth(PV);


        if (gameObject.GetComponent<MonsterMouvSelection>().estSelectionne)
        {
            CanvasGBarre.alpha = 1f;
        }
        if(gameObject.GetComponent<MonsterMouvSelection>().estSelectionne == false)
        {
            CanvasGBarre.alpha = 0f;
        }
    }
}
