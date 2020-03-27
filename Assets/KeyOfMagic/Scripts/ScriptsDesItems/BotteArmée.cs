using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotteArmée : MonoBehaviour, ItemInterface
{
    public string Nom
    {
        get
        {
            return "Botte Armée";
        }
    }

    public int Type
    {
        get
        {
            return 4;
        }
    }

    public string description
    {
        get
        {
            return "<sprite=0>  Augmente la vitesse de déplacement \n<sprite=0>  Réduit les dégats reçus";
        }
    }
    public string lore
    {
        get
        {
            return "\" Ce chapeau apartenait autrefois à un puissant mage versé dans l'art de la nécromancie. La puissance de cet art tabou se serait imiscée dans ses vêtements, conférant à leur nouveau propriétaire des pouvoirs hors du commun.\" ";
        }
    }

    public int rarete
    {
        get
        {
            return 1;
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void Ramasse()
    {
        GameObject.Find("Player").GetComponent<NavMeshAgent>().speed +=2;
        PlayerStats.resistanceMultiplier -= 0.1f; 
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        GameObject.Find("Player").GetComponent<NavMeshAgent>().speed -= 2;
        PlayerStats.resistanceMultiplier += 0.1f;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 2f, 2f);
    }
}
