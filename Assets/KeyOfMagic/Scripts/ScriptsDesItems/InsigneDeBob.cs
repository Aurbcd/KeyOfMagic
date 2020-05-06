using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InsigneDeBob : MonoBehaviour, ItemInterface
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
            return "Bob's Badge";
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
            return "<sprite=0> Bob can attack foes";
        }
    }
    public string lore
    {
        get
        {
            return "\" LThe whole world always believed that Bob was a passive creature, an adventurers' assistant. But today is the time. Bob will show the world what he can do.\"";
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
        MouvBobScript.attack =true;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        MouvBobScript.attack = false;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 0f, 2f);
    }


    public void Start()
    {
        cadreCarte.color = new Color32(152, 20, 52, 255);
        cadreSprite.color = new Color32(152, 20, 52, 255);
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
