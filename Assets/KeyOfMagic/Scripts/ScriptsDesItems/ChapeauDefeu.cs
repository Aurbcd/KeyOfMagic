using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChapeauDefeu : MonoBehaviour, ItemInterface

{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI titre;
    public TextMeshProUGUI description_affiché;
    public TextMeshProUGUI lore_affiché;
    private bool isDisplayed;
    private float fadeSpeed = 5f;
    public string Nom
    {
        get
        {
            return "Chapeau draconnique";
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

    public string description
    {
        get
        {
            return "<sprite=0>  Augmente grandement votre vie \n<sprite=1>  Les incantations ennemies sont plus rapides";
        }
    }

    public string lore
    {
        get
        {
            return "\"Le Havre de la Nuit était une citée marchande prospère, mais il n'en reste aujourd'hui que des ruines. Dotée d'une force de défense pourtant hors du commun, la légende raconte qu'une seule magicienne l'aurait réduite en cendres, impassible face à l'assaut continu de la garde de la ville.  \"";
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
        PlayerStats.playerMaxHeathPoints += 200;
        PlayerStats.playerHealthPoints += 200;
        PlayerStats.Difficulte += 1;

        gameObject.SetActive(false);
    }

    public void Jete()
    {
        //Ne pas oublier de retirer ces effets (attention à l'ordre)
        PlayerStats.playerHealthPoints -= 200;
        PlayerStats.playerMaxHeathPoints -= 200;
        PlayerStats.Difficulte -= 1;

        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 0f, 2f);
    }

    public void Start()
    {

        canvasGroup.alpha = 0f;
        titre.text = this.Nom;
        description_affiché.text = this.description;
        lore_affiché.text = this.lore;
    }

    public void Update()
    {
        if (isDisplayed)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1f, fadeSpeed * Time.deltaTime);
        }
        else
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 0f, fadeSpeed * Time.deltaTime);
        }
    }

    void OnMouseOver()
    {
        isDisplayed = true;
    }

    void OnMouseExit()
    {
        isDisplayed = false;
    }


}