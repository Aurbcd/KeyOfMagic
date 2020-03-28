using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class ChevaliereDuDestin : MonoBehaviour, ItemInterface
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
            return "Chevaliere du Destin";
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
            return "<sprite=0> Les incantations des monstres sont ralenties \n<sprite=1> Vous avez moins de temps d'hésitation";
        }
    }
    public string lore
    {
        get
        {
            return "\" <i>Sur le champ de bataille, il ne faut pas réfléchir car il n'y a pas de place pour l'hésitation. Il faut se laisser porter par le flot du combat. La vie et la mort n'ont plus de sens, seul l'appel de la destinée compte.</i> - Baron du Comté Rouge. \"";
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
        PlayerStats.Difficulte -= 0.75f;
        ImprovedSpellInput.tempsReset = (int)(ImprovedSpellInput.tempsReset / 2);
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.Difficulte += 0.75f;
        ImprovedSpellInput.tempsReset = (int)(ImprovedSpellInput.tempsReset * 2);
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
