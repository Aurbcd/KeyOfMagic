using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HabitsDeHeros : MonoBehaviour, ItemInterface
{
    public string Nom
    {
        get
        {
            return "Habits de Héros";
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
            return "<sprite=0>  Augmente vos nombres de points de vie maximum \n<sprite=0> Double la veleur de vos boucliers \n<sprite=1>  Vos boucliers sont détruits par les éléments efficaces";
        }
    }

    public int rarete
    {
        get
        {
            return 3;
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
        PlayerStats.playerMaxHeathPoints += (int)(PlayerStats.playerMaxHeathPoints*0.25f);
        PlayerStats.shieldMultiplier += 1;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.playerMaxHeathPoints -= (int)(PlayerStats.playerMaxHeathPoints * 0.25f);
        PlayerStats.shieldMultiplier -= 1;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 2f, 2f);
    }
}
