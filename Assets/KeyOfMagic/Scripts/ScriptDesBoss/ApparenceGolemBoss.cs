using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparenceGolemBoss : MonoBehaviour
{

    public Material[] affichageDeLaTete;
    Renderer rend;
    string element;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("BOSS Le Golem(Clone)");
        element = go.GetComponent<MonsterStatText>().element;
        if (element.Equals("Terre"))
        {
            Material[] mats = rend.materials;
            mats[4] = affichageDeLaTete[0];
            rend.materials = mats;
        }
        if (element.Equals("Elecricite"))
        {
            Material[] mats = rend.materials;
            mats[4] = affichageDeLaTete[1];
            rend.materials = mats;
        }
        if (element.Equals("Eau"))
        {
            Material[] mats = rend.materials;
            mats[4] = affichageDeLaTete[2];
            rend.materials = mats;
        }
        if (element.Equals("Feu"))
        {
            Material[] mats = rend.materials;
            mats[4] = affichageDeLaTete[3];
            rend.materials = mats;
        }
        if (element.Equals("Air"))
        {
            Material[] mats = rend.materials;
            mats[4] = affichageDeLaTete[4];
            rend.materials = mats;
        }
    }
}
