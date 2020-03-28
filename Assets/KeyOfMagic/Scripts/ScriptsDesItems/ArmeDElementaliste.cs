using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class ArmeDElementaliste : MonoBehaviour, ItemInterface
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
            return "Arme d'Élémentaliste";
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
            return "<sprite=0>  Augmente grandement vos dégats";
        }
    }
    public string lore
    {
        get
        {
            return "\" Parmi les maîtres des arcanes, rares sont ceux qui peuvent prétendre au titre d'élémentaliste. À ceux-là sont reservées les essences de bois les plus exceptionnelles, capables de canaliser leur pouvoir démesuré. \"";
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
        PlayerStats.DamageMultiplier += 0.10f;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.DamageMultiplier -= 0.10f;
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
