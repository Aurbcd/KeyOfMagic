using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    public bool ouvert;
    public bool sallePreBoss;
    public List<GameObject> lumieresAAllumer;
    private string objet;
    public string cote;
    public static int NombrePNJ;
    //Son
    public static AudioClip door,boss;

    // Start is called before the first frame update
    void Start()
    {
        NombrePNJ = 1;
        ouvert = false;
        door = Resources.Load<AudioClip>("Porte");
        boss = Resources.Load<AudioClip>("BossSFX");
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if ((GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude < 20)
        {
            if (!ouvert)
            {
                if (GameObject.FindGameObjectsWithTag("Ennemy").Length == NombrePNJ)
                {
                    ouvert = true;
                    GetComponent<AudioSource>().PlayOneShot(door,0.5f);
                    if(sallePreBoss)
                        GetComponent<AudioSource>().PlayOneShot(boss);
                    GetComponent<Animator>().SetBool("ouverture", true);

                    if(GetComponent<GenerationDeMonstre>() != null)
                        GetComponent<GenerationDeMonstre>().Generer();
                    if (GetComponent<GenerationSpecial>() != null)
                        objet = GetComponent<GenerationSpecial>().Generer(cote);

                    foreach (GameObject lum in lumieresAAllumer)
                    {
                        foreach (Light light in lum.GetComponentsInChildren<Light>())
                        {
                            light.enabled = true;
                            if (objet != null && objet.Equals("Coffre"))
                                light.color = new Color(0.18f, 0.5f, 0.95f, 1f);
                            if (objet != null && objet.Equals("Mimic"))
                                light.color = new Color(0.18f, 0.5f, 0.95f, 1f);
                            if (objet != null && objet.Equals("Fontaine"))
                                light.color = new Color(1f, 1f, 1f, 1f);
                            if (objet != null && objet.Equals("Parchemin"))
                                light.color = new Color(0.18f, 0.95f, 0.19f, 1f);
                            if (objet != null && objet.Equals("Enigme"))
                                light.color = new Color(0.85f, 0.18f, 0.95f, 1f);
                        }
                    }
                }
            }
        }
    }
}