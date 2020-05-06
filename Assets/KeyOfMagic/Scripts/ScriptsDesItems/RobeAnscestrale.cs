using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RobeAnscestrale : MonoBehaviour, ItemInterface
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
            return "Anscestral Dress";
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
            return "<sprite=0>  Increase your health \n<sprite=0>  Portions are sure to appear after a fight";
        }
    }
    public string lore
    {
        get
        {
            return "\" Many signs indicate a certain lived experience. You can read on the lining in golden letters: <i> You don't necessarily have to be better than your opponent, sometimes, you just have to be able to stay in the race longer. </i>\"";
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
        PlayerStats.playerMaxHeathPoints += (int)(PlayerStats.playerMaxHeathPointsInitial * 0.15f);
        PlayerStats.playerHealthPoints += (int)(PlayerStats.playerMaxHeathPointsInitial * 0.15f);
        MonsterMouvSelection.modificateurMinimumPotions += 1;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.playerHealthPoints -= (int)(PlayerStats.playerMaxHeathPointsInitial * 0.15f);
        PlayerStats.playerMaxHeathPoints -= (int)(PlayerStats.playerMaxHeathPointsInitial * 0.15f);
        MonsterMouvSelection.modificateurMinimumPotions -= 1;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 0f, 2f);
    }


    public void Start()
    {
        cadreCarte.color = new Color32(19, 114, 113, 255);
        cadreSprite.color = new Color32(19, 114, 113, 255);
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
