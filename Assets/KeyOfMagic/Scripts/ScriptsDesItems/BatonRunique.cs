using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BatonRunique : MonoBehaviour, ItemInterface
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
            return "Rune Stick";
        }
    }

    public int Type
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
            return "<sprite=0> Hugely rise your damage \n<sprite=1>  Potions are less likely to appear";
        }
    }
    public string lore
    {
        get
        {
            return "\" An ancient artifact with incredible power. Although it greatly increases the effects of its user's incantations, former owners of this weapon all seem to have come to an early end. \"";
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
        PlayerStats.DamageMultiplier += 0.30f;
        MonsterMouvSelection.modificateurApparitionPotions = -0.2f;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.DamageMultiplier -= 0.30f;
        MonsterMouvSelection.modificateurApparitionPotions = -0.2f;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 0f, 2f);
    }

    public void Start()
    {

        canvasGroup.alpha = 0f;
        titre.text = this.Nom;
        description_affiché.text = this.description;
        lore_affiché.text = this.lore;
        cadreCarte.color = new Color32(152, 20, 52, 255);
        cadreSprite.color = new Color32(152, 20, 52, 255);

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
