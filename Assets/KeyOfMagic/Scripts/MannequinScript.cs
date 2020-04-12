using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MannequinScript : MonoBehaviour
{
    int compteur;
    bool toHeal;
   void Start()
   {
        compteur = 0;
        toHeal = false;
   }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<MonsterStatText>().PV < GetComponent<MonsterStatText>().PVMax)
        {
            if(compteur != 120)
            {
                compteur += 1;
            }
            else
            {
                toHeal = true;
                compteur = 0;
            }
        }
        if (toHeal)
        {
            GetComponent<MonsterStatText>().PV += 3;
        }
        if (GetComponent<MonsterStatText>().PV == GetComponent<MonsterStatText>().PVMax)
            toHeal = false;
    }
}
