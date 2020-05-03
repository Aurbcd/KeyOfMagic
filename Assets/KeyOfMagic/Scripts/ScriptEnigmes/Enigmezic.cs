using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class Enigmezic : MonoBehaviour
{
    private GameObject player;
    public List<string> reponse = new List<string>();
    public List<string> choix = new List<string>();
    string type;
    //["u","u","e","e","u","u","o","a"]
    public GameObject coffre;
    public bool ouvert;

    //Son
    public static AudioClip feu;
    public static AudioClip air;
    public static AudioClip eau;
    public static AudioClip elec;
    public static AudioClip terre;
    public static AudioClip enonce;
    public static AudioClip final;
    int compteur;
    bool victoire;

    void Start()
    {
        Porte.NombrePNJ += 1;
        ouvert = false;
        reponse.Capacity = 8;
        choix.Capacity = 8;
        reponse.Add("u"); reponse.Add("u"); reponse.Add("e"); reponse.Add("e"); reponse.Add("u"); reponse.Add("u"); reponse.Add("o"); reponse.Add("a");
        feu = Resources.Load<AudioClip>("feu");
        eau = Resources.Load<AudioClip>("eau");
        air = Resources.Load<AudioClip>("air");
        terre = Resources.Load<AudioClip>("terre");
        elec = Resources.Load<AudioClip>("elec");
        enonce = Resources.Load<AudioClip>("enonce");
        final = Resources.Load<AudioClip>("fontaine");
        player = GameObject.Find("Player");
        compteur = 0;
        victoire = false;
    }

    void OnMouseDown()
    {
        GetComponent<AudioSource>().PlayOneShot(enonce);
    }

    private void Update()
    {
        if (!GetComponent<MonsterMouvSelection>().estSelectionne)
        {
            GetComponent<AudioSource>().mute = true;
            if(compteur <= 5)
            {
                compteur += 1;
            }else
            {
                compteur = 0;
                GetComponent<AudioSource>().Stop();
            }
        }
        else
        {
            GetComponent<AudioSource>().mute = false;
            compteur = 0;
        }
        if (victoire && !ouvert)
        {
            ouvert = true;
            GameObject potion = Resources.Load<GameObject>("Potion");
            Vector3 Aleatoire = new Vector3(UnityEngine.Random.Range(0, 1), 0, UnityEngine.Random.Range(0, 1));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(UnityEngine.Random.Range(0, 2), 0, UnityEngine.Random.Range(0, 2));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(UnityEngine.Random.Range(0, 3), 0, UnityEngine.Random.Range(0, 3));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(UnityEngine.Random.Range(0, 4), 0, UnityEngine.Random.Range(0, 4));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(UnityEngine.Random.Range(0, 4), 0, UnityEngine.Random.Range(0, 4));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(UnityEngine.Random.Range(0, 5), 0, UnityEngine.Random.Range(0, 5));
            Instantiate(coffre, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            tag = "Untagged";
            Porte.NombrePNJ -= 1;
        }
    }
    void groan()
    {
        if (Convert.ToBoolean(choix.Count.CompareTo(8)))
        {
            type = player.GetComponent<ImprovedSpellInput>().choix;
            Debug.Log(type);
            if (type[0].Equals('a'))
            {
                choix.Add("a");
                GetComponent<AudioSource>().PlayOneShot(eau);
            }
            if (type[0].Equals('u'))
            {
                choix.Add("u");
                GetComponent<AudioSource>().PlayOneShot(feu);
            }
            if (type[0].Equals('o'))
            {
                choix.Add("o");
                GetComponent<AudioSource>().PlayOneShot(terre);
            }
            if (type[0].Equals('e'))
            {
                choix.Add("e");
                GetComponent<AudioSource>().PlayOneShot(air);
            }
            if (type[0].Equals('i'))
            {
                choix.Add("i");
                GetComponent<AudioSource>().PlayOneShot(elec);
            }
         
            Debug.Log(choix.Count);
            if (CheckMatch(choix, reponse))
            {
                victoire = true;
                GetComponent<AudioSource>().PlayOneShot(final);
            }
        }
        else
        {
            choix.Clear();
        }
    }
    bool CheckMatch(List<string> l1, List<string> l2)
    {
        if (l1.Count != l2.Count)
            return false;
        for (int i = 0; i < l1.Count; i++)
        {
            if (l1[i] != l2[i])
                return false;
        }
        return true;
    }

}