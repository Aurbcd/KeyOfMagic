using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferZik : MonoBehaviour
{
    public int numero;
    // Update is called once per frame
    void Update()
    {
        if(transform.GetComponentInParent<Enigmezic>().choix.Count >= numero + 1) 
        { 
            string element = transform.GetComponentInParent<Enigmezic>().choix[numero];
            if (element != null && element.Equals("o")) {
                GetComponent<ParticleSystem>().Play();
                ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
                settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0.07f, 2.7f, 0.4f, 1f));
            }
            if (element != null && element.Equals("u")) {
                GetComponent<ParticleSystem>().Play();
                ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
                settings.startColor = new ParticleSystem.MinMaxGradient(new Color(2f, 0.03f, 0f, 1f));

            }
            if (element != null && element.Equals("e")) {
                GetComponent<ParticleSystem>().Play();
                ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
                settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0.5f, 0.08f, 0.65f, 1f));
            }
            if (element != null && element.Equals("a")) {
                GetComponent<ParticleSystem>().Play();
                ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
                settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0f, 4f, 19f, 1f));
            }
            if (element != null && element.Equals("i")) {
                GetComponent<ParticleSystem>().Play();
                ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
                settings.startColor = new ParticleSystem.MinMaxGradient(new Color(9.5f, 8.1f, 0f, 1f));
            }
        }
        if (transform.GetComponentInParent<Enigmezic>().choix.Count == 0)
        {
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(1f, 1f, 1f, 1f));
        }
    }
}
