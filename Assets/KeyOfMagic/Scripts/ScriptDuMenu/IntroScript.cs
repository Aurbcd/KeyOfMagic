using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tutoriel());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Start Menu");
        } 
    }

    IEnumerator Tutoriel()
    {
        MainMenu.InitStats();
        yield return new WaitForSeconds(26);
        SceneManager.LoadScene("Tutoriel");
    }
}
