﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public List<string> nomNiveauxAleatoire;
    public void PlayGame()
    {
        InitStats();
        //Generation aléatoire
        int rand = Random.Range(0, nomNiveauxAleatoire.Capacity);
        Debug.Log(nomNiveauxAleatoire[rand]);
        SceneManager.LoadScene(nomNiveauxAleatoire[rand]);   
    }

    public void Tutoriel()
    {
        InitStats();
        SceneManager.LoadScene("Tutoriel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public static void InitStats()
    {
        PlayerStats.playerMaxHeathPoints = 200;
        PlayerStats.playerHealthPoints = 200;
        PlayerStats.playerMaxShieldPoints = 0;
        PlayerStats.playerShieldPoints = 0;
        PlayerStats.shieldElement = "";
        PlayerStats.niveau = 1;
        PlayerStats.DamageMultiplier = 1;
        PlayerStats.volDeVie = 0;
        PlayerStats.shieldMultiplier = 1;
        PlayerStats.resistanceMultiplier = 1;
        PlayerStats.niveau = 1;
        PlayerStats.DifficulteInitiale = PlayerStats.Difficulte;
    }
}
