﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class BotteDuMarcheVide : MonoBehaviour, ItemInterface
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
            return "Botte du Marche-Vide";
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
            return "<sprite=0>  Vol de vie conséquent \n<sprite=1>  Points de vie maximum grandement réduit";
        }
    }
    public string lore
    {
        get
        {
            return "\" L'ordre des Marche-Vide a longtemps terrorisé les plaines de l'Est. Bien que leur corps éthéré ne leur permettait que de brèves apparitions dans notre monde, chacune de celle-ci était signe de désolation et de mort pour toutes les formes de vie alentours. \"";
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
