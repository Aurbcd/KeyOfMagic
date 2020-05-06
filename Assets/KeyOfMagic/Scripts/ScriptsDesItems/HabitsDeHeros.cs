using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HabitsDeHeros : MonoBehaviour, ItemInterface
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
            return "Hero Garb";
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
            return "<sprite=0>  Increase your Health \n<sprite=0> Double your shield \n<sprite=1>  Your shiel is destroyed by efficient elements";
        }
    }
    public string lore
    {
        get
        {
            return "\" This habit was created and worn by an adventurer of unprecedented talent. With disproportionate confidence, he claimed never to be wrong. The burn marks surrounding the cuffs, however, seem to prove the opposite.\"";
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
        PlayerStats.playerMaxHeathPoints += (int)(PlayerStats.playerMaxHeathPointsInitial * 0.25f);
        PlayerStats.playerHealthPoints += (int)(PlayerStats.playerMaxHeathPointsInitial * 0.25f);
        PlayerStats.shieldMultiplier += 1;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.playerHealthPoints -= (int)(PlayerStats.playerMaxHeathPointsInitial * 0.25f);
        PlayerStats.playerMaxHeathPoints -= (int)(PlayerStats.playerMaxHeathPointsInitial * 0.25f);
        PlayerStats.shieldMultiplier -= 1;
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
