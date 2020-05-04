using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EngimeChasseur : MonoBehaviour
{
    public int nombreDePorte;
    public static int compteur = 0;
    public GameObject coffre;
    public bool ouvert;
    public static AudioClip bravo;

    // Start is called before the first frame update
    void Start()
    {
        Porte.NombrePNJ += 1;
        bravo = Resources.Load<AudioClip>("Fontaine");
        ouvert = false;
        if (SceneManager.GetActiveScene().name.Equals("Layout1") || SceneManager.GetActiveScene().name.Equals("Layout1Bis"))
        {
            nombreDePorte = 18;
        }

        if (SceneManager.GetActiveScene().name.Equals("Layout2") || SceneManager.GetActiveScene().name.Equals("Layout2Bis"))
        {
            nombreDePorte = 19;
        }
        if (SceneManager.GetActiveScene().name.Equals("Layout3") || SceneManager.GetActiveScene().name.Equals("Layout3Bis"))
        {
            nombreDePorte = 22;
        }
        for (int i = 0; i < nombreDePorte; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = nombreDePorte; i < 22; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void Update() 
    {
        if (nombreDePorte <= compteur && !ouvert)
        {
            ouvert = true;
            GetComponent<AudioSource>().PlayOneShot(bravo);
            GameObject potion = Resources.Load<GameObject>("Potion");
            Vector3 Aleatoire = new Vector3(Random.Range(0, 1), 0, Random.Range(0, 1));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(Random.Range(0, 2), 0, Random.Range(0, 2));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(Random.Range(0, 3), 0, Random.Range(0, 3));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(Random.Range(0, 4), 0, Random.Range(0, 4));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(Random.Range(0, 4), 0, Random.Range(0, 4));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
            Instantiate(coffre, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            tag = "Untagged";
            Porte.NombrePNJ -= 1;
        }
        for (int i = 0; i < compteur; i++)
        {
            ParticleSystem.MainModule settings = transform.GetChild(i).GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(2f, 0.03f, 0f, 1f));
        }
    }
}
