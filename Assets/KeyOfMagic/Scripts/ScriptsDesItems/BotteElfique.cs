using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class BotteElfique : MonoBehaviour, ItemInterface
{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI titre;
    public TextMeshProUGUI description_affiché;
    public TextMeshProUGUI lore_affiché;
    private bool isDisplayed;
    public string Nom
    {
        get
        {
            return "Botte Elfique";
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
            return "<sprite=0>  Augmente grandement la vitesse de déplacement \n<sprite=1>  Réduit votre temps d'hésitation";
        }
    }
    public string lore
    {
        get
        {
            return "\" <i>Dans mon métier madame, on n'a pas le temps de réfléchir pour prendre des décisions, tout doit être instinctif </i> - Väar An Ghart, au comptoir d'un bar la veille de l'accident de course de char qui mit fin à sa carrière de pilote. \"";
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
        GameObject.Find("Player").GetComponent<NavMeshAgent>().speed +=5;
        ImprovedSpellInput.tempsReset -= 20; 
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        GameObject.Find("Player").GetComponent<NavMeshAgent>().speed -= 5;
        ImprovedSpellInput.tempsReset += 20;
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
