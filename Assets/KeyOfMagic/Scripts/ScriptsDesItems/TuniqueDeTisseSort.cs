using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TuniqueDeTisseSort : MonoBehaviour, ItemInterface
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
            return "SpellWeaver Dress";
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
            return "<sprite=0>  Increase your health \n<sprite=0>  Potions are more likely to appear \n<sprite=0>  Reduce incoming damage \n<sprite=1>  Reduce your speed";
        }
    }
    public string lore
    {
        get
        {
            return "\" She once belonged to one of the last survivors of the Spellweaver race who was known for her unusual headgear. Attracted by his power, a merchant would have exchanged it for a worthless artifact. Legend has it that the entire city in which he lived paid the price, reminding everyone of the relentless power of the fire of revenge.\"";
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
        PlayerStats.playerMaxHeathPoints += (int)(PlayerStats.playerMaxHeathPointsInitial * 0.2f);
        PlayerStats.playerHealthPoints += (int)(PlayerStats.playerMaxHeathPointsInitial * 0.2f);
        MonsterMouvSelection.modificateurMinimumPotions += 1;
        MonsterMouvSelection.modificateurMaximumPotions += 1;
        PlayerStats.resistanceMultiplier -= 0.05f;
        GameObject.Find("Player").GetComponent<UnityEngine.AI.NavMeshAgent>().speed -= 3;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.playerHealthPoints -= (int)(PlayerStats.playerMaxHeathPointsInitial * 0.2f);
        PlayerStats.playerMaxHeathPoints -= (int)(PlayerStats.playerMaxHeathPointsInitial * 0.2f);
        MonsterMouvSelection.modificateurMinimumPotions -= 1;
        MonsterMouvSelection.modificateurMaximumPotions -= 1;
        PlayerStats.resistanceMultiplier += 0.05f;
        GameObject.Find("Player").GetComponent<UnityEngine.AI.NavMeshAgent>().speed += 3;
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
