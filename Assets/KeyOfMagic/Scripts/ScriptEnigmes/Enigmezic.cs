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


    //Son
    public static AudioClip feu;
    public static AudioClip air;
    public static AudioClip eau;
    public static AudioClip elec;
    public static AudioClip terre;
    public static AudioClip enonce;
    public static AudioClip final;

    void Start()
    {

        reponse.Capacity = 8;
        choix.Capacity = 8;
        reponse.Add("u"); reponse.Add("u"); reponse.Add("e"); reponse.Add("e"); reponse.Add("u"); reponse.Add("u"); reponse.Add("o"); reponse.Add("a");
        feu = Resources.Load<AudioClip>("feu");
        eau = Resources.Load<AudioClip>("eau");
        air = Resources.Load<AudioClip>("air");
        terre = Resources.Load<AudioClip>("terre");
        elec = Resources.Load<AudioClip>("elec");
        enonce = Resources.Load<AudioClip>("enonce");
        final = Resources.Load<AudioClip>("final");
        player = GameObject.Find("Player");


    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        GetComponent<AudioSource>().PlayOneShot(enonce);
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

                GetComponent<AudioSource>().PlayOneShot(final);
            }
        }
        if (CheckMatch(choix, reponse))
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