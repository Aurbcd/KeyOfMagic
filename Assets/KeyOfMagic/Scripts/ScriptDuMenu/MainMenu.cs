using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public static bool appuye;
    private void Start()
    {
        appuye = false;
    }
    public void PlayGame()
    {
        if (!appuye)
        {
            appuye = true;
            InitStats();
            GetComponentInParent<LevelLoader>().ChangeScene();
        }
    }



    public void Tutoriel()
    {
        if (!appuye)
        {
            appuye = true;
            InitStats();
            SceneManager.LoadScene("Tutoriel");

        }
    }
    public void Back()
    {
        if (!appuye)
        {
            appuye = true;
            InitStats();
            SceneManager.LoadScene("Start Menu");
        }
    }

    public void QuitGame()
    {
        if (!appuye)
        {
            appuye = true;
            Application.Quit();
        }
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
        ImprovedSpellInput.tempsReset = 60;
        PlayerStats.DifficulteInitiale = PlayerStats.Difficulte;
    }
}
