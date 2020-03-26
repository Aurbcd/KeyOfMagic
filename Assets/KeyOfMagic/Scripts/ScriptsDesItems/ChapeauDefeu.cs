using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapeauDefeu : MonoBehaviour, ItemInterface
{
    public string Nom
    {
        get
        {
            return "Chapeau de feu";
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
        //On met ici les effets de l'objet
        PlayerStats.playerMaxHeathPoints += 50;
        PlayerStats.playerHealthPoints += 50;


        gameObject.SetActive(false);
    }

    public void Jete()
    {
        //Ne pas oublier de retirer ces effets (attention à l'ordre)
        PlayerStats.playerHealthPoints -= 50;
        PlayerStats.playerMaxHeathPoints -= 50;

        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 2f, 2f);
    }

}