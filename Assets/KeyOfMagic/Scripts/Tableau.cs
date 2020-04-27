using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tableau : MonoBehaviour
{
    public string element;
    public int numero; //Compte à partir de 0
    public Material[] Images;


    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        Random.InitState(Random.Range(0, 100));
        int pourcentage = Random.Range(0, 100);
        if(pourcentage < 20)
        {
            rend.sharedMaterial = Images[0];
            element = "Eau";
        }
        if (pourcentage < 40 && pourcentage >= 20)
        {
            rend.sharedMaterial = Images[1];
            element = "Feu";
        }
        if (pourcentage < 60 && pourcentage >= 40)
        {
            rend.sharedMaterial = Images[2];
            element = "Terre";
        }
        if (pourcentage < 80 && pourcentage >= 60)
        {
            rend.sharedMaterial = Images[3];
            element = "Air";
        }
        if (pourcentage < 100 && pourcentage >= 80)
        {
            rend.sharedMaterial = Images[4];
            element = "Electricite";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
