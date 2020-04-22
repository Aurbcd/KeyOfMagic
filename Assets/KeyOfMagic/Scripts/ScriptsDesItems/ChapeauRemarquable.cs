using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChapeauRemarquable : MonoBehaviour, ItemInterface
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
            return "Chapeau Remarquable";
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
            return "<sprite=0>  Les incantations ennemies sont ralenties \n<sprite=0>  Vos boucliers sont plus efficaces";
        }
    }
    public string lore
    {
        get
        {
            return "\" Un chapeau aux lignes sobres et raffinées. En plus d'être un atout aux soirées chics, il permet de distraire les ennemis qui manquent de vigilance. \"";
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
        PlayerStats.Difficulte -= 0.2f;
        PlayerStats.shieldMultiplier += 0.1f;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.Difficulte += 0.2f;
        PlayerStats.shieldMultiplier -= 0.1f;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 0f, 2f);
    }

    public void Start()
    {

        canvasGroup.alpha = 0f;
        titre.text = this.Nom;
        description_affiché.text = this.description;
        lore_affiché.text = this.lore;
        cadreCarte.color = new Color32(19, 114, 113, 255);
        cadreSprite.color = new Color32(19, 114, 113, 255);
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
