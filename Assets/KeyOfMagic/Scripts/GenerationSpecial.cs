using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationSpecial : MonoBehaviour
{
    public Transform spawn;
    public List<GameObject> pool2,pool3;
    public int valeurAleatoire;
    // Start is called before the first frame update
    public string Generer()
    {
        GameObject res;
        if (PlayerStats.niveau == 1 && RoomManager.PoolG1.Capacity != 0)
        {
            valeurAleatoire = Random.Range(0, RoomManager.PoolG1.Count);
            Instantiate(RoomManager.PoolG1[valeurAleatoire], spawn.position, Quaternion.identity);
            res = RoomManager.PoolG1[valeurAleatoire];
            RoomManager.PoolG1.RemoveAt(valeurAleatoire);
            Debug.Log(res.name);
            return res.name;
        }
        if (PlayerStats.niveau == 2 && pool2.Capacity != 0)
        {
            valeurAleatoire = Random.Range(0, pool2.Count);
            res = Instantiate(pool2[valeurAleatoire], spawn.position, Quaternion.identity);
            pool2.RemoveAt(valeurAleatoire);
            return res.name;
        }
        if (PlayerStats.niveau == 3 && pool3.Capacity != 0)
        {
            valeurAleatoire = Random.Range(0, pool3.Count);
            res = Instantiate(pool3[valeurAleatoire], spawn.position, Quaternion.identity);
            pool3.RemoveAt(valeurAleatoire);
            return res.name;
        }
        else
        {
            Debug.LogError("Probleme dans Generation Special, on atteint le bout du code");
            return "Probleme";
        }
    }
}