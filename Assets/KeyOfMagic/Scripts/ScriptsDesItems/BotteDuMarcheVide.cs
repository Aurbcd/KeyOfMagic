using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BotteDuMarcheVide : MonoBehaviour, ItemInterface
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
            return "Boots of the Void Walker";
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
            return "<sprite=0>  Tremendous heatlh steal \n<sprite=1>  Health greatly reduce";
        }
    }
    public string lore
    {
        get
        {
            return "\" The Order of the Void Walker has long terrorized the eastern plains. Although their ethereal bodies allowed them only brief appearances in our world, each of them was a sign of desolation. \"";
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
        PlayerStats.volDeVie += 0.8f;
        PlayerStats.playerHealthPoints = (int)(PlayerStats.playerHealthPoints/2);
        PlayerStats.playerMaxHeathPoints = (int)(PlayerStats.playerMaxHeathPoints/2);
        gameObject.SetActive(false);
    }

    public void Jete()
    {
        PlayerStats.volDeVie -= 0.8f;
        PlayerStats.playerHealthPoints = (int)(PlayerStats.playerHealthPoints * 2);
        PlayerStats.playerMaxHeathPoints = (int)(PlayerStats.playerMaxHeathPoints * 2);
        gameObject.SetActive(true);
        gameObject.transform.position = ClickToMove.playerPosition + new Vector3(2f, 0f, 2f);
    }

    public void Start()
    {

        canvasGroup.alpha = 0f;
        titre.text = this.Nom;
        description_affiché.text = this.description;
        lore_affiché.text = this.lore;
        cadreCarte.color = new Color32(155, 119, 0, 255);
        cadreSprite.color = new Color32(155, 119, 0, 255);
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
