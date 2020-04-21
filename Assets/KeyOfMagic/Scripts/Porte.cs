using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    //Niveau
    public string cote;
    public string salle;

    public bool ouvert;
    public List<GameObject> lumieresAAllumer;
    //Son
    public static AudioClip door;

    // Start is called before the first frame update
    void Start()
    {
        ouvert = false;
        door = Resources.Load<AudioClip>("Porte");
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if ((GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude < 15)
        {
            if (!ouvert)
            {
                if (GameObject.FindGameObjectsWithTag("Ennemy").Length == 1)
                {
                    ouvert = true;
                    GetComponent<AudioSource>().PlayOneShot(door);
                    GetComponent<Animator>().SetBool("ouverture", true);
                    
                    if(GetComponent<GenerationDeSalle>() != null)
                    {
                        salle = GetComponent<GenerationDeSalle>().Generer(cote);
                        if(salle.Equals("PasDeSalle"))
                        {
                            GetComponent<GenerationDeMonstre>().Generer();
                        }
                    }
                    else
                    {
                        GetComponent<GenerationDeMonstre>().Generer();
                    }
                    foreach (GameObject lum in lumieresAAllumer)
                    {
                        foreach (Light light in lum.GetComponentsInChildren<Light>())
                        {
                            light.enabled = true;
                        }

                    }
                }
            }
        }
    }
}