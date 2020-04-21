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
            return "Tunique de Tisse-Sort";
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
            return "<sprite=0>  Augmente vos nombres de points de vie maximum \n<sprite=0>  Augmente le nombre de potion à la mort d'un monstre \n<sprite=0>  Réduit les dégats subis \n<sprite=1>  Réduit votre vitesse de déplacement";
        }
    }
    public string lore
    {
        get
        {
            return "\" Elle appartenait autre fois à une des dernières survivantes de la race des Tisse-Sort qui était connue pour son couvre chef inhabituel. Attiré par son pouvoir, un marchand la lui aurait échangée contre un artefact sans valeur. La légende veut que la ville toute entière dans laquelle il résidait en ait payé le prix, rappelant à tous l'implacable puissance du feu de la vengeance. \"";
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
