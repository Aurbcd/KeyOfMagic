using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutoechap : MonoBehaviour
{

public GameObject tutopanel;
public Canvas tutoBlinker;

    void Start()
    {
        tutopanel.SetActive(false);
        tutoBlinker.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            tutopanel.SetActive(true);
            Debug.Log("Coucou");
            tutoBlinker.enabled = false; //Eteint le symbole qui clignotte
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            tutopanel.SetActive(false);
        }
    }

}
