using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<GameObject> poolMonstre;
    public List<GameObject> poolSpecial;
    static public List<GameObject> PoolG1 = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        PoolG1.Add(Resources.Load<GameObject>("Coffre"));
        foreach(GameObject monstre in poolMonstre)
        {
            PoolG1.Add(monstre);
        }
        PoolG1.Add(poolSpecial[Random.Range(0, poolSpecial.Count)]); //Choisi un spécial aléatoirement
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
