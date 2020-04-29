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
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene("Tutoriel");
    }
}
