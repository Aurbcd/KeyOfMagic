using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimationScript : MonoBehaviour
{
    int compteur = 0;
    public float mouvementVertical=1;
    public float mouvementRot=1;
    public string axeRot="y";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(axeRot=="z")
        transform.Rotate(0, 0, 100 * Time.deltaTime * mouvementRot);
        if (axeRot== "y")
            transform.Rotate(0, 100 * Time.deltaTime * mouvementRot,0);
        if (axeRot== "x")
            transform.Rotate(100 * Time.deltaTime * mouvementRot, 0,0);
        if (compteur < 120*mouvementVertical)
        {
            transform.position = transform.position + new Vector3(0, 0.001f, 0);
            compteur += 1;
        }
        if (compteur >=120 * mouvementVertical && compteur < 240 * mouvementVertical)
        {
            transform.position = transform.position + new Vector3(0, -0.001f, 0);
            compteur += 1;
        }
        if (compteur >= 240 * mouvementVertical)
            compteur = 0;
    }
}
