using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapeauDeNecromancien : MonoBehaviour, ItemInterface
{
    public string Nom
    {
        get
        {
            return "Chapeau de Nécromancien";
        }
    }

    public int Type
    {
        get
        {
            return 0;
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
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 2f, 2f);
    }
}
