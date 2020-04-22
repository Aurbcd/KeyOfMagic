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

        var hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, 10f); //Tout le monde à terre !
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject == transform.gameObject)
                continue;

            transform.position = hit.point;
            break;
        }
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
