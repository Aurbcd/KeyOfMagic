using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(niv);
    }
}
