using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public List<string> nomNiveauxAleatoire;
    public void PlayGame()
    {
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
