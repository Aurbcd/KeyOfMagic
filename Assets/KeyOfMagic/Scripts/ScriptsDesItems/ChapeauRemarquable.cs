using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapeauRemarquable : MonoBehaviour, ItemInterface
{
    public string Nom
    {
        get
        {
            return "Chapeau Remarquable";
        }
    }

    public int Type
    {
        get
        {
            return 0;
        }
    }
    public string description
    {
        get
        {
            return "<sprite=0>  Les ennemis sont ralentis \n<sprite=0>  Vos boucliers sont plus efficaces";
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
        PlayerStats.Difficulte -= 0.2f;
        PlayerStats.shieldMultiplier += 0.1f;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.Difficulte += 0.2f;
        PlayerStats.shieldMultiplier -= 0.1f;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 2f, 2f);
    }
}
