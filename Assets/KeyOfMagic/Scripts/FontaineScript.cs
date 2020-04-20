using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontaineScript : MonoBehaviour
{
    private bool ouvert;
    //Son
    public static AudioClip fontaine;

    // Start is called before the first frame update
    void Start()
    {
        ouvert = false;
        fontaine = Resources.Load<AudioClip>("Fontaine");
    }

   // Update is called once per frame
    void OnMouseDown() { 
        if ((GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude < 9)
        {
            if (!ouvert)
            {
                PlayerStats.playerHealthPoints = PlayerStats.playerMaxHeathPoints;
                ouvert = true;
                GetComponent<AudioSource>().PlayOneShot(fontaine);
                GetComponent<Animator>().SetBool("Drink",true);
            }
        }
    }
}
