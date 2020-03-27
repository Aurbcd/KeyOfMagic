using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobScript : MonoBehaviour
{
    public static string element="";

    public Material[] Bobs;

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(element != null)
        {
            if (element.Equals("Eau"))
            {
                rend.sharedMaterial = Bobs[0];
            }
            if (element.Equals("Feu"))
            {
                rend.sharedMaterial = Bobs[1];
            }
            if (element.Equals("Terre"))
            {
                rend.sharedMaterial = Bobs[2];
            }
            if (element.Equals("Air"))
            {
                rend.sharedMaterial = Bobs[3];
            }
            if (element.Equals("Electricite"))
            {
                rend.sharedMaterial = Bobs[4];
            }
        }
    }
}
