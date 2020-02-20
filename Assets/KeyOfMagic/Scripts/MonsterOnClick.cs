using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterOnClick : MonoBehaviour
{
    void OnMouseDown()
    {
        var Rendu = gameObject.GetComponent<Renderer>();

        //Call SetColor using the shader property name "_Color" and setting the color to red
        Rendu.material.SetColor("_Color", Color.red);
    }
}
