using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TuniqueDeTisseSort : MonoBehaviour, ItemInterface
{
    public string Nom
    {
        get
        {
            return "Tunique de Tisse-Sort";
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
            return "<sprite=0>  Augmente vos nombres de points de vie maximum \n<sprite=0>  Augmente le nombre de potion à la mort d'un monstre \n<sprite=0>  Réduit les dégats subis \n<sprite=1>  Réduit votre vitesse de déplacement";
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
        PlayerStats.playerMaxHeathPoints += (int)(PlayerStats.playerMaxHeathPoints*0.2f);
        MonsterMouvSelection.modificateurMinimumPotions += 1;
        MonsterMouvSelection.modificateurMaximumPotions += 1;
        PlayerStats.resistanceMultiplier -= 0.05f;
        GameObject.Find("Player").GetComponent<NavMeshAgent>().speed -= 3;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.playerMaxHeathPoints -= (int)(PlayerStats.playerMaxHeathPoints * 0.2f);
        MonsterMouvSelection.modificateurMinimumPotions -= 1;
        MonsterMouvSelection.modificateurMaximumPotions -= 1;
        PlayerStats.resistanceMultiplier += 0.05f;
        GameObject.Find("Player").GetComponent<NavMeshAgent>().speed += 3;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 2f, 2f);
    }
}
