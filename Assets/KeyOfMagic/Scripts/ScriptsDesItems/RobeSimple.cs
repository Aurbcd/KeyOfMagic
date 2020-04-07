using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RobeSimple : MonoBehaviour, ItemInterface
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
            return "Robe Simple";
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
            return "<sprite=0>  Augmente votre nombre de points de vie maximum";
        }
    }
    public string lore
    {
        get
        {
            return "\" Une lourde robe aux pans larges et mal ajustés. À défaut de vous faire briller lors d'évènements mondains, elle a l'avantage de vous tenir chaud.\" ";
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
        PlayerStats.playerMaxHeathPoints += (int)(PlayerStats.playerMaxHeathPoints*0.1f);
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.playerMaxHeathPoints -= (int)(PlayerStats.playerMaxHeathPoints * 0.1f);
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 0f, 2f);
    }

    public void Start()
    {
        cadreCarte.color = new Color32(255, 255, 255, 150);
        cadreSprite.color = new Color32(255, 255, 255, 150);
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
