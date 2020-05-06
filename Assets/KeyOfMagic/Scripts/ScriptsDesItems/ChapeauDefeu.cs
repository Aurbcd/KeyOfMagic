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
    public Image cadreCarte;
    public Image cadreSprite;
    public string Nom
    {
        get
        {
            return "Dragonskin Hat";
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

    public string description
    {
        get
        {
            return "<sprite=0>  Hugely increase your health \n<sprite=1>  Foes' summoning is faster";
        }
    }

    public string lore
    {
        get
        {
            return "\"Le Havre de la Nuit was a prosperous trading city, but only ruins remain today. Even if it had an extraordinary defense force, legend says that only one magician would have reduced her to ashes.  \"";
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
        PlayerStats.Difficulte += 1 * PlayerStats.DifficulteInitiale;

        gameObject.SetActive(false);
    }

    public void Jete()
    {
        //Ne pas oublier de retirer ces effets (attention à l'ordre)
        PlayerStats.playerHealthPoints -= 200;
        PlayerStats.playerMaxHeathPoints -= 200;
        PlayerStats.Difficulte -= 1 * PlayerStats.DifficulteInitiale;

        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 0f, 2f);
    }

    public void Start()
    {

        canvasGroup.alpha = 0f;
        titre.text = this.Nom;
        description_affiché.text = this.description;
        lore_affiché.text = this.lore;
        cadreCarte.color = new Color32(155, 119, 0, 255);
        cadreSprite.color = new Color32(155, 119, 0, 255);
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