using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BotteArmée : MonoBehaviour, ItemInterface
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
            return "Armored Boots";
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
            return "<sprite=0>  Increase your speed \n<sprite=0>  Reduce incoming damage";
        }
    }
    public string lore
    {
        get
        {
            return "\" Particularly comfortable boots. Although having metal, their weight does not seem to constrain their wearer. Their sole allows the user to walk much faster, since he no longer has to look where he steps. \"";
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
        GameObject.Find("Player").GetComponent<UnityEngine.AI.NavMeshAgent>().speed +=2;
        PlayerStats.resistanceMultiplier -= 0.1f; 
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        GameObject.Find("Player").GetComponent<UnityEngine.AI.NavMeshAgent>().speed -= 2;
        PlayerStats.resistanceMultiplier += 0.1f;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 0f, 2f);
    }

    public void Start()
    {

        canvasGroup.alpha = 0f;
        titre.text = this.Nom;
        description_affiché.text = this.description;
        lore_affiché.text = this.lore;
        cadreCarte.color = new Color32(19, 114, 113, 255);
        cadreSprite.color = new Color32(19, 114, 113, 255);

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
