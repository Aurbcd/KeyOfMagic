﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AI_Portail : MonoBehaviour
{
    public float distanceToPlayer;
    public List<GameObject> Cultists;
    public bool Eau,Feu,Terre,Air,Electricite,estInvoqué;
    private GameObject clone;
    private int pv;
    private bool boule;
    //Son
    public static AudioClip GolemA;

    // Start is called before the first frame update
    void Start()
    {
        boule = true;
        changeElement("Eau");
        Portail(true);
        Eau = false;
        Feu = false;
        Terre = false;
        Air = false;
        estInvoqué = false;
        Electricite = false;
        GolemA = Resources.Load<AudioClip>("GolemGroan"); //Achanger
    }
    private void Update()
    {
        distanceToPlayer = (GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude;
        if (distanceToPlayer < 25 && gameObject.GetComponent<MonsterStatText>().PV >= 0 && boule)
        {
            StartCoroutine(HeAttac());
        }
        if(clone != null)
        {
            if (clone.GetComponent<MonsterStatText>().PV > 0)
            {
                Portail(false);
                GetComponent<MonsterStatText>().PV = pv;
            }
            if (clone.GetComponent<MonsterStatText>().PV <= 0)
            {
                Portail(true);
            }
        }
        else
        {
            Portail(true);
        }
    }

    void Portail(bool ouvert)
    {
        ParticleSystem PS = GetComponentInChildren<ParticleSystem>();
        if (ouvert & !PS.isPlaying)
        {
            PS.Play();
        }
        if (!ouvert && PS.isPlaying)
        {
            PS.Stop();
        }
    }
    void changeElement(string element)
    {
        GetComponent<MonsterStatText>().element = element;
        ParticleSystem.MainModule settings = GetComponentInChildren<ParticleSystem>().main;
        if(element.Equals("Eau"))
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0f, 4f, 19f, 1f));
        if (element.Equals("Terre"))
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0.07f, 2.7f, 0.4f, 1f));
        if (element.Equals("Feu"))
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(2f, 0.03f, 0f, 1f));
        if (element.Equals("Electricite"))
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(9.5f, 8.1f, 0f, 1f));
        if (element.Equals("Air"))
            settings.startColor = new ParticleSystem.MinMaxGradient(new Color(0.5f, 0.08f, 0.65f, 1f));
        GetComponent<MonsterStatText>().weakness = GetComponent<XmlManager>().ElementDatabase.Elementdb.Find(elementEntry => elementEntry.elementName == GetComponent<MonsterStatText>().element).weakness;
        GetComponent<MonsterStatText>().resistance = GetComponent<XmlManager>().ElementDatabase.Elementdb.Find(elementEntry => elementEntry.elementName == GetComponent<MonsterStatText>().element).resistance;
    }
    void groan()
    { 
        GetComponent<AudioSource>().PlayOneShot(GolemA);
    }
    IEnumerator HeAttac()
    {
        boule = false;
        Vector3 invokPosition = (transform.position + ClickToMove.playerPosition) / 2;
        if((!Eau) && (!Feu) && (!Terre) && (!Air) && (!Electricite))
        {
            if ((clone == null || !clone.activeSelf) && !estInvoqué)
            {
                pv = GetComponent<MonsterStatText>().PV;
                estInvoqué = true;
                clone = Instantiate(Cultists[0], invokPosition, Quaternion.identity); //Done
            }
            changeElement("Feu");
            yield return new WaitForSeconds(30);
            Eau = true;
            estInvoqué = false;
            yield return new WaitForSeconds(3);
        }
        if (Eau && !Feu && !Terre && !Air && !Electricite)
        {
            pv = GetComponent<MonsterStatText>().PV;
            if ((clone == null || !clone.activeSelf) && !estInvoqué)
            {
                Debug.Log(estInvoqué);
                estInvoqué = true;
                clone = Instantiate(Cultists[1], invokPosition, Quaternion.identity); //Done
            }
            changeElement("Terre");
            yield return new WaitForSeconds(30);
            Feu = true;
            estInvoqué = false;
            yield return new WaitForSeconds(3);
        }
        if (Eau && Feu && !Terre && !Air && !Electricite)
        {
            if ((clone == null || !clone.activeSelf) && !estInvoqué)
            {
                pv = GetComponent<MonsterStatText>().PV;
                estInvoqué = true;
                clone = Instantiate(Cultists[2], invokPosition, Quaternion.identity); //Done
            }
            changeElement("Air");
            yield return new WaitForSeconds(30);
            Terre = true;
            estInvoqué = false;
            yield return new WaitForSeconds(3);
        }
        if (Eau && Feu && Terre && !Air && !Electricite)
        {
            if ((clone == null || !clone.activeSelf) && !estInvoqué)
            {
                pv = GetComponent<MonsterStatText>().PV;
                estInvoqué = true;
                clone = Instantiate(Cultists[3], invokPosition, Quaternion.identity); //Done
            }
            changeElement("Electricite");
            yield return new WaitForSeconds(30);
            Air = true;
            estInvoqué = false;
            yield return new WaitForSeconds(3);
        }
        if (Eau && Feu && Terre && Air && !Electricite)
        {
            if ((clone == null || !clone.activeSelf) && !estInvoqué)
            {
                pv = GetComponent<MonsterStatText>().PV;
                estInvoqué = true;
                clone = Instantiate(Cultists[4], invokPosition, Quaternion.identity); //Done
            }
            changeElement("Eau");
            yield return new WaitForSeconds(30);
            Electricite = true;
            yield return new WaitForSeconds(3);
            Feu = false;
            Air = false;
            estInvoqué = false;
            Terre = false;
            boule = true;
        }
    }
}