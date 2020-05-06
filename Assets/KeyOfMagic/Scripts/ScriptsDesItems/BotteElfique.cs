using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BotteElfique : MonoBehaviour, ItemInterface
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
            return "Elven Boots";
        }
    }

    public int Type
    {
        get
        {
            return 4;
        }
    }

    public string description
    {
        get
        {
            return "<sprite=0>  Hugely increase your speed \n<sprite=1>  Decrease your time to hesitate";
        }
    }
    public string lore
    {
        get
        {
            return "\" <i>In my work ma'am,  don't have time to think 'bout making decisions, everything must be instinctive </i> - Väar An Ghart, at a bar counter, the day before the chariot accident which ended his racing career. \"";
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
        GameObject.Find("Player").GetComponent<UnityEngine.AI.NavMeshAgent>().speed +=5;
        ImprovedSpellInput.tempsReset -= 20; 
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        GameObject.Find("Player").GetComponent<UnityEngine.AI.NavMeshAgent>().speed -= 5;
        ImprovedSpellInput.tempsReset += 20;
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
