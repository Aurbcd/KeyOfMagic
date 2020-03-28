using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class ReliqueDeLegende : MonoBehaviour, ItemInterface
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
            return "Relique de Légende";
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
            return "<sprite=0>  Double les dégats que vous infligez \n<sprite=1>  Double vos dégats subits";
        }
    }
    public string lore
    {
        get
        {
            return "\" <i>Qu'est ce que la puissance sans le goût du risque ?  À tous ces mages qui s'enferment dans leur tour d'argent, je leur dis, vous n'avez jamais pratiqué la vraie magie </i> - Archibald Greyroux, membre de l'escadron de la Lance D'Argent. \"";
        }
    }

    public int rarete
    {
        get
        {
            return 3;
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
        PlayerStats.DamageMultiplier += 1f;
        PlayerStats.resistanceMultiplier += 1f;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.DamageMultiplier -= 1f;
        PlayerStats.resistanceMultiplier -= 1f;
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
