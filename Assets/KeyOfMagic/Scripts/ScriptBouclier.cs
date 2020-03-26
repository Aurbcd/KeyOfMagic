using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBouclier : MonoBehaviour
{
    private ParticleSystem PS;
    
    // Start is called before the first frame update
    void Start()
    {
        PS = GetComponent<ParticleSystem>();
        PS.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.shieldElement == "")
        {
            PS.Stop();
        }
        if (PlayerStats.shieldElement == "Eau")
        {
            PS.Play();
            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startLifetime = PlayerStats.playerShieldPoints;
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0f,4f,19f,1f));
        }
        if (PlayerStats.shieldElement == "Feu")
        {
            PS.Play();
            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(2f, 0.03f, 0f, 1f));
        }
        if (PlayerStats.shieldElement == "Electricite")
        {
            PS.Play();
            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(9.5f, 8.1f, 0f, 1f));
        }
        if (PlayerStats.shieldElement == "Air")
        {
            PS.Play();
            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0.5f, 0.08f, 0.65f, 1f));
        }
        if (PlayerStats.shieldElement == "Terre")
        {
            PS.Play();
            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0.07f, 2.7f, 0.4f, 1f));
        }
    }
}
