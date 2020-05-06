using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChevaliereDuDestin : MonoBehaviour, ItemInterface
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
            return "Signet Ring of Fate";
        }
    }

    public int Type
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
            return "<sprite=0> Greatly slows down foes' summoning \n<sprite=1> Decrease your time to hesitate";
        }
    }
    public string lore
    {
        get
        {
            return "\" <i>On the battlefield, do not think, because there is no time for hesitation. You have to let yourself be carried by the flow of the battle. Only Fate's call matters.</i> - Baron of Red County. \"";
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
        PlayerStats.Difficulte -= 0.3f * PlayerStats.DifficulteInitiale;
        ImprovedSpellInput.tempsReset = (int)(ImprovedSpellInput.tempsReset / 2);
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.Difficulte += 0.3f * PlayerStats.DifficulteInitiale;
        ImprovedSpellInput.tempsReset = (int)(ImprovedSpellInput.tempsReset * 2);
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
