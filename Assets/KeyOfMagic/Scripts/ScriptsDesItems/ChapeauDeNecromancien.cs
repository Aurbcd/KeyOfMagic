using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChapeauDeNecromancien : MonoBehaviour, ItemInterface

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
            return "Chapeau de Nécromancien";
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
            return "<sprite=0>  Vol de vie \n<sprite=1>  Diminution des dégats infligés";
        }
    }

    public string lore
    {
        get
        {
            return "\" Ce chapeau appartenait autrefois à un puissant mage versé dans l'art de la nécromancie. La puissance de cet art tabou se serait imiscée dans ses vêtements, conférant à leur nouveau propriétaire des pouvoirs hors du commun. \"";
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
        PlayerStats.volDeVie += 0.1f;
        PlayerStats.DamageMultiplier -= 0.4f;
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.volDeVie -= 0.1f;
        PlayerStats.DamageMultiplier += 0.4f;
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 2f, 2f);
    }

    public void Start(){

        canvasGroup.alpha = 0f;
        titre.text = this.Nom;
        description_affiché.text = this.description;
        lore_affiché.text = this.lore;

    }

    public void Update () 
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
