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
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0f,4f,19f,1f));
        }
    }
}
