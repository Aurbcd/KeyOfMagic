using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnneauOuvrage : MonoBehaviour, ItemInterface
{
    public string Nom
    {
        get
        {
            return "Anneau Ouvragé";
        }
    }

    public int Type
    {
        get
        {
            return 3;
        }
    }

    public string description
    {
        get
        {
            return "<sprite=0>  Augmente la chance d'apparition de potion";
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
        MonsterMouvSelection.modificateurApparitionPotions += 0.1f;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        MonsterMouvSelection.modificateurApparitionPotions -= 0.1f;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 2f, 2f);
    }
}
