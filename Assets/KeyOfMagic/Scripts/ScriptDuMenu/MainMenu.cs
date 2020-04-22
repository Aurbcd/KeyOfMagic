using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public List<string> nomNiveauxAleatoire;
    public void PlayGame()
    {
        //Valeur à mettre initial
        PlayerStats.Difficulte = 1.5f;
        PlayerStats.niveau = 1;
        PlayerStats.playerMaxHeathPointsInitial = 200;
        PlayerStats.playerMaxHeathPoints = 200;
        PlayerStats.playerHealthPoints = 200;
        PlayerStats.playerShieldPoints = 0;
        PlayerStats.playerMaxShieldPoints = 0;
        PlayerStats.shieldElement = "";
        PlayerStats.DamageMultiplier = 1;
        PlayerStats.volDeVie = 0;
        PlayerStats.resistanceMultiplier = 1;
        PlayerStats.shieldMultiplier = 1;

        //Generation aléatoire
        int rand = Random.Range(0, nomNiveauxAleatoire.Capacity);
        Debug.Log(nomNiveauxAleatoire[rand]);
        SceneManager.LoadScene(nomNiveauxAleatoire[rand]);   
        }

        public void QuitGame()
        {
            Application.Quit();
        }
}
