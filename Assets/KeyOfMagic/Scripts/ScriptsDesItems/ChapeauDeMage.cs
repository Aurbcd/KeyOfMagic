using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapeauDeMage : MonoBehaviour, ItemInterface
{
    public string Nom
    {
        get
        {
            return "Chapeau de Mage";
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
            return "<sprite=0>  Les ennemis sont ralentis";
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
        PlayerStats.Difficulte -= 0.2f;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.Difficulte += 0.2f;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 2f, 2f);
    }
}
