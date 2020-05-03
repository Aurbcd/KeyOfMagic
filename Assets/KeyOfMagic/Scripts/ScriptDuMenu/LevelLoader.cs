using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1;
    public List<string> nomNiveauxAleatoire;

    public void ChangeScene()
    {
        //Generation aléatoire
        int rand = Random.Range(0, nomNiveauxAleatoire.Capacity);
        Debug.Log(nomNiveauxAleatoire[rand]);
        StartCoroutine(LoadLevel(nomNiveauxAleatoire[rand]));
    }

    IEnumerator LoadLevel(string niv)
    {
        transition.SetTrigger("Start");
        GameObject.Find("MusicManager").GetComponent<AudioSource>().Stop();
        GameObject.Find("MusicManager").GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("newgame"));
        //On tente de mettre des couleurs dans nos vies
        if(!SceneManager.GetActiveScene().name.Equals("Tutoriel")){
            if (SceneManager.GetActiveScene().name.Equals("Start Menu"))
            {
                this.transform.GetChild(3).transform.GetChild(0).transform.GetChild(2).GetComponent<TipsandTricks>().couleur();
            }
            else
            {
                this.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).GetComponent<TipsandTricks>().couleur();
            }
        }

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(niv);
    }
}
