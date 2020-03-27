using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotteDuMarcheVide : MonoBehaviour, ItemInterface
{
    public string Nom
    {
        get
        {
            return "Botte du Marche-Vide";
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
            return "<sprite=0>  Vol de vie conséquent \n<sprite=1>  Points de vie maximum grandement réduit";
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
            return 0;
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
        PlayerStats.volDeVie += 0.8f;
        PlayerStats.playerHealthPoints = (int)(PlayerStats.playerHealthPoints/2);
        PlayerStats.playerMaxHeathPoints = (int)(PlayerStats.playerMaxHeathPoints/2);
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.volDeVie -= 0.8f;
        PlayerStats.playerHealthPoints = (int)(PlayerStats.playerHealthPoints * 2);
        PlayerStats.playerMaxHeathPoints = (int)(PlayerStats.playerMaxHeathPoints * 2);
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 2f, 2f);
    }
}
