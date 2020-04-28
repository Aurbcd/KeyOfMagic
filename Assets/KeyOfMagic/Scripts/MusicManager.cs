using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static AudioClip OSTWalk;
    public static AudioClip OSTFight;
    private int compteur = 0;
    public bool Combat;
    // Start is called before the first frame update
    void Start()
    {
        Combat = false;
        OSTWalk = Resources.Load<AudioClip>("OSTWalk");
        OSTFight = Resources.Load<AudioClip>("OSTFight");
    }

    // Update is called once per frame
    void Update()
    {   
        compteur = 0;
        foreach (GameObject monstre in GameObject.FindGameObjectsWithTag("Ennemy"))
        {
            if ((monstre.transform.position - ClickToMove.playerPosition).magnitude < 22 && monstre.GetComponent<MonsterStatText>().monsterName != "Statue du chasseur" && monstre.GetComponent<MonsterStatText>().monsterName != "Statue de peintre" && monstre.GetComponent<MonsterStatText>().monsterName != "Mannequin") {
                Combat = true;
                compteur -= 1;
            }
            compteur += 1;
        }
        if (compteur == GameObject.FindGameObjectsWithTag("Ennemy").Length)
            Combat = false;

        if (Combat)
        {
            if (GetComponent<AudioSource>().time >= GetComponent<AudioSource>().clip.length - 0.05f)
            {   
                GetComponent<AudioSource>().clip = OSTFight;
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            if (GetComponent<AudioSource>().time >= GetComponent<AudioSource>().clip.length-0.05f)
            {
                GetComponent<AudioSource>().clip = OSTWalk;
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
