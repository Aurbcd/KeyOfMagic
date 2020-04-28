using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffer : MonoBehaviour
{
    public int numero;
    // Update is called once per frame
    void Update()
    {
        string element = transform.GetComponentInParent<EngimeTableau>().buffer[numero];
        if (element != null && element.Equals("Terre")){
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0.07f, 2.7f, 0.4f, 1f));
        }
        if (element != null && element.Equals("Feu")){
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(2f, 0.03f, 0f, 1f));

        }
        if (element != null && element.Equals("Air")){
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0.5f, 0.08f, 0.65f, 1f));
        }
        if (element != null && element.Equals("Eau")){
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0f, 4f, 19f, 1f));
        }
        if (element != null && element.Equals("Electricite")){
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(9.5f, 8.1f, 0f, 1f));
        }
    }
}
