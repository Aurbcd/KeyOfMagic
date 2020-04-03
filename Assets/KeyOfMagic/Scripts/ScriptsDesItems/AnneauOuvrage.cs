using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class AnneauOuvrage : MonoBehaviour, ItemInterface
{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI titre;
    public TextMeshProUGUI description_affiché;
    public TextMeshProUGUI lore_affiché;
    private bool isDisplayed;
    private float fadeSpeed = 5f;
    public string Nom
    {
        get
        {
            return "Anneau Ouvragé";
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
            return "<sprite=0>  Augmente la chance d'apparition des potions";
        }
    }
    public string lore
    {
        get
        {
            return "\" Un anneau à la fois beau et pratique. Grâce à celui-ci, un mage aurait précipité la chute de l'industrie du verre dans les contrées du Sud, après avoir découvert comment boire les potions de vitalité sans perdre la fiole. C'est un secret aujourd'hui oublié. \"";
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
