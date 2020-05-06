using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChapeauDeNecromancien : MonoBehaviour, ItemInterface

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
            return "Necromancer Hat";
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
            return "<sprite=0>  Steal foes' health \n<sprite=1>  Reduce your damage";
        }
    }

    public string lore
    {
        get
        {
            return "\" This hat once belonged to a powerful mage related to the art of necromancy. The power of this taboo art would have crept into his clothes, giving their new owner rare powers. \"";
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
        PlayerStats.volDeVie += 0.2f;
        PlayerStats.DamageMultiplier -= 0.4f;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.volDeVie -= 0.1f;
        PlayerStats.DamageMultiplier += 0.4f;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 0f, 2f);
    }

    public void Start(){

        canvasGroup.alpha = 0f;
        titre.text = this.Nom;
        description_affiché.text = this.description;
        lore_affiché.text = this.lore;
        cadreCarte.color = new Color32(152, 20, 52, 255);
        cadreSprite.color = new Color32(152, 20, 52, 255);
    }

    public void Update () 
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
