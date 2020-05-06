using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ArmeDElementaliste : MonoBehaviour, ItemInterface
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
            return "Elementalist Staff";
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
            return "<sprite=0>  Greatly increase your damage";
        }
    }
    public string lore
    {
        get
        {
            return "\" Among the Arcane Masters, few can pretend to wield all 5 elements flawlessly. Those only are called Elementalists. It is said that this staff's cristals hold a tremendous power. \"";
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
        PlayerStats.DamageMultiplier += 0.10f;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.DamageMultiplier -= 0.10f;
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
