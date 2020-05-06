using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ChapeauDeMage : MonoBehaviour, ItemInterface
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
            return "Mage Hat";
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
            return "<sprite=0>  Slows down foes' summoning";
        }
    }
    public string lore
    {
        get
        {
            return "\" The origin of the attraction that mages have for hats is lost in the origins of time. As far back as the writings go, it seems that anyone with a knack for magic also has an inordinate attraction for pointy hats. Even if it's a little worn, this one will satisfy yours.\"";
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
        PlayerStats.Difficulte -= 0.1f * PlayerStats.DifficulteInitiale;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.Difficulte += 0.1f * PlayerStats.DifficulteInitiale;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 2f, 2f);
    }


    public void Start()
    {

        canvasGroup.alpha = 0f;
        titre.text = this.Nom;
        description_affiché.text = this.description;
        lore_affiché.text = this.lore;
        cadreCarte.color = new Color32(255, 255, 255, 150);
        cadreSprite.color = new Color32(255, 255, 255, 150);

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
