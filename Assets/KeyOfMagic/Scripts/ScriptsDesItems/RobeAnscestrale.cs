using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobeAnscestrale : MonoBehaviour, ItemInterface
{
    public string Nom
    {
        get
        {
            return "Robe Anscestrale";
        }
    }

    public int Type
    {
        get
        {
            return 1;
        }
    }
    public string description
    {
        get
        {
            return "<sprite=0>  Augmente vos nombres de points de vie maximum \n<sprite=0>  Garanti l'apparition de potion à la mort d'un monstre";
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
            return 2;
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
        PlayerStats.playerMaxHeathPoints += (int)(PlayerStats.playerMaxHeathPoints*0.15f);
        MonsterMouvSelection.modificateurMinimumPotions += 1;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.playerMaxHeathPoints -= (int)(PlayerStats.playerMaxHeathPoints * 0.15f);
        MonsterMouvSelection.modificateurMinimumPotions -= 1;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 2f, 2f);
    }
}
