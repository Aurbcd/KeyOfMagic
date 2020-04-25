using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffreTutoScript : MonoBehaviour
{
    private bool ouvert;
    public GameObject Drop;
    //Son
    public static AudioClip coffre;

    // Start is called before the first frame update
    void Start()
    {
        ouvert = false;
        coffre = Resources.Load<AudioClip>("Coffre");

        var hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, 10f);
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject == transform.gameObject)
                continue;

            transform.position = hit.point;
            break;
        }
    }

    void OnMouseDown() { 
        if ((GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude < 14)
        {
            if (!ouvert)
            {
                ouvert = true;
                this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Open", true);
                GetComponent<AudioSource>().PlayOneShot(coffre);
                Instantiate(Drop, (transform.position + ClickToMove.playerPosition) / 2, Quaternion.identity);
            }
        }
    }
}
