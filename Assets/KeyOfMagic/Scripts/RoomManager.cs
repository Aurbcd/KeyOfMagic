using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    
    public List<GameObject> poolMonstreG1, poolMonstreG2, poolMonstreG3, poolMonstreD1, poolMonstreD2, poolMonstreD3;
    public List<GameObject> Droite, Gauche;
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
        if(Gauche.Capacity == 1 || Random.Range(0, 100) > 5)
            PoolG1.Add(Gauche[0]);
        else
        {
            PoolG1.Add(Gauche[1]);
        }
        foreach (GameObject monstre in poolMonstreG1)
        {
            PoolG1.Add(monstre);
        }
        if (poolSpecialG.Count != 0)
            PoolG1.Add(poolSpecialG[Random.Range(0, poolSpecialG.Count)]); //Choisi un spécial aléatoirement

        if (Droite.Capacity == 1 || Random.Range(0, 100) > 5)
            PoolD1.Add(Droite[0]);
        else
        {
            PoolD1.Add(Droite[1]);
        }
        foreach (GameObject monstre in poolMonstreD1)
        {
            PoolD1.Add(monstre);
        }
        if(poolSpecialD.Count != 0)
             PoolD1.Add(poolSpecialD[Random.Range(0, poolSpecialD.Count)]); //Choisi un spécial aléatoirement

        //Niveau 2
        if (Gauche.Capacity == 1 || Random.Range(0, 100) > 5)
            PoolG2.Add(Gauche[0]);
        else
        {
            PoolG2.Add(Gauche[1]);
        }
        foreach (GameObject monstre in poolMonstreG2)
        {
            PoolG2.Add(monstre);
        }
        if (poolSpecialG.Count != 0)
            PoolG2.Add(poolSpecialG[Random.Range(0, poolSpecialG.Count)]); //Choisi un spécial aléatoirement

        if (Droite.Capacity == 1 || Random.Range(0, 100) > 5)
            PoolD2.Add(Droite[0]);
        else
        {
            PoolD2.Add(Droite[1]);
        }
        foreach (GameObject monstre in poolMonstreD2)
        {
            PoolD2.Add(monstre);
        }
        if (poolSpecialD.Count != 0)
            PoolD2.Add(poolSpecialD[Random.Range(0, poolSpecialD.Count)]); //Choisi un spécial aléatoirement

        //Niveau 3
        if (Gauche.Capacity == 1 || Random.Range(0, 100) > 5)
            PoolG3.Add(Gauche[0]);
        else
        {
            PoolG3.Add(Gauche[1]);
        }
        foreach (GameObject monstre in poolMonstreG3)
        {
            PoolG3.Add(monstre);
        }
        if (poolSpecialG.Count != 0)
            PoolG3.Add(poolSpecialG[Random.Range(0, poolSpecialG.Count)]); //Choisi un spécial aléatoirement

        if (Droite.Capacity == 1 || Random.Range(0, 100) > 5)
            PoolD3.Add(Droite[0]);
        else
        {
            PoolD3.Add(Droite[1]);
        }
        foreach (GameObject monstre in poolMonstreD3)
        {
            PoolD3.Add(monstre);
        }
        if (poolSpecialD.Count != 0)
            PoolD3.Add(poolSpecialD[Random.Range(0, poolSpecialD.Count)]); //Choisi un spécial aléatoirement
    }
}
