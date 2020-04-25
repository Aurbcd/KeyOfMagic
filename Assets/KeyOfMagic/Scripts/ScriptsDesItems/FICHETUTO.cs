using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FICHETUTO : MonoBehaviour, ItemInterface
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
            return "Votre Fiche";
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
            return "<sprite=0>  Permet d'ouvrir la fiche en appuyant sur Echap ";
        }
    }
    public string lore
    {
        get
        {
            return "\" J'ai bien fait de la faire celle-là ! \" - Vous";
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
        //ARTHUR FAIT LES CHOSES
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
        cadreCarte.color = new Color32(255, 255, 255, 150);
        cadreSprite.color = new Color32(255, 255, 255, 150);
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
