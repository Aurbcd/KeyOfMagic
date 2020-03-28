using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class BaguettedeSorcier : MonoBehaviour, ItemInterface
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
            return "Baguette de Sorcier";
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
            return "<sprite=0>  Augmente vos dégats";
        }
    }
    public string lore
    {
        get
        {
            return "\" Une arme équilibrée, à la fois souple et légère. Adaptée aux apprentis comme aux confirmés. Garantie uniquement dans un cadre d'utilisation normal*.\n<i angle=40>*Les situations suivantes ne sont pas couvertes : Fissures après incantation d'un sort de catégorie supérieure ou égale à 4, [...] surchauffe suite à une tentative d'invocation du Grand Démon Ancestral.</i> \"";
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
        PlayerStats.DamageMultiplier += 0.05f;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.DamageMultiplier -= 0.05f;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 2f, 2f);
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
