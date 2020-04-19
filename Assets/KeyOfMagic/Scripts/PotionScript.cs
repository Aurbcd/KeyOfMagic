using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    //Mécanique d'objet de le valeur de potion
    public static float modificateurValeur = 1;
    public static AudioClip PotionS;

    // Start is called before the first frame update
    void Start()
    {
        PotionS = Resources.Load<AudioClip>("Potion");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            if(Physics.Raycast(ray, out hit, 100) && hit.collider.gameObject == gameObject && PlayerStats.playerHealthPoints != PlayerStats.playerMaxHeathPoints)
            {   
                if((GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude < 5) {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(PotionS,0.75f);
                    PlayerStats.playerHealthPoints += (int)(modificateurValeur * PlayerStats.playerMaxHeathPoints * 10 / 100);
                    Destroy(transform.gameObject);
                }
            }
        }
        if((GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude < 2 && PlayerStats.playerMaxHeathPoints != PlayerStats.playerHealthPoints)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(PotionS, 0.75f);
            PlayerStats.playerHealthPoints += PlayerStats.playerMaxHeathPoints * 10 / 100;
            Destroy(transform.gameObject);
        }
    }
}
