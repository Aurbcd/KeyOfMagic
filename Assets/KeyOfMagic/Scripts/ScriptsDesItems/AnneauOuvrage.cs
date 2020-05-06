using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnneauOuvrage : MonoBehaviour, ItemInterface
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
            return "Ornated Ring";
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
            return "<sprite=0>  Potions are more likely to appear";
        }
    }
    public string lore
    {
        get
        {
            return "\" A beautiful yet useful ring. Thanks to it, a magician would have create a massive plunge in the glass industry, after finding out how to drink vitality potions without losing the vial. That's a secret long forgotten. \"";
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
        MonsterMouvSelection.modificateurApparitionPotions += 0.1f;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        MonsterMouvSelection.modificateurApparitionPotions -= 0.1f;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 0f, 2f);
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
