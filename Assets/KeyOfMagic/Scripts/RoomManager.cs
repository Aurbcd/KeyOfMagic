﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    
    public List<GameObject> poolMonstreG1, poolMonstreG2, poolMonstreG3, poolMonstreD1, poolMonstreD2, poolMonstreD3;
    public GameObject Droite, Gauche;
    public List<GameObject> poolSpecialG;
    [Header("!! poolMonstre.lenght + 1 (Parchemin ou Objet) +1 (poolSpécial choisi) = nb de salles")]
    public List<GameObject> poolSpecialD;
    static public List<GameObject> PoolG1 = new List<GameObject>();
    static public List<GameObject> PoolG2 = new List<GameObject>();
    static public List<GameObject> PoolG3 = new List<GameObject>();
    static public List<GameObject> PoolD1 = new List<GameObject>();
    static public List<GameObject> PoolD2 = new List<GameObject>();
    static public List<GameObject> PoolD3 = new List<GameObject>();


    // Start is called before the first frame update
    void Start() 
    {
        //Niveau 1
        PoolG1.Add(Gauche);
        foreach (GameObject monstre in poolMonstreG1)
        {
            PoolG1.Add(monstre);
        }
        PoolG1.Add(poolSpecialG[Random.Range(0, poolSpecialG.Count)]); //Choisi un spécial aléatoirement
        
        PoolD1.Add(Droite);
        foreach (GameObject monstre in poolMonstreD1)
        {
            PoolD1.Add(monstre);
        }
        PoolD1.Add(poolSpecialD[Random.Range(0, poolSpecialD.Count)]); //Choisi un spécial aléatoirement

        //Niveau 2
        PoolG2.Add(Gauche);
        foreach (GameObject monstre in poolMonstreG2)
        {
            PoolG2.Add(monstre);
        }
        PoolG2.Add(poolSpecialG[Random.Range(0, poolSpecialG.Count)]); //Choisi un spécial aléatoirement

        PoolD2.Add(Droite);
        foreach (GameObject monstre in poolMonstreD2)
        {
            PoolD2.Add(monstre);
        }
        PoolD2.Add(poolSpecialD[Random.Range(0, poolSpecialD.Count)]); //Choisi un spécial aléatoirement

        //Niveau 3
        PoolG3.Add(Gauche);
        foreach (GameObject monstre in poolMonstreG3)
        {
            PoolG3.Add(monstre);
        }
        PoolG3.Add(poolSpecialG[Random.Range(0, poolSpecialG.Count)]); //Choisi un spécial aléatoirement

        PoolD3.Add(Droite);
        foreach (GameObject monstre in poolMonstreD3)
        {
            PoolD1.Add(monstre);
        }
        PoolD3.Add(poolSpecialD[Random.Range(0, poolSpecialD.Count)]); //Choisi un spécial aléatoirement
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
