using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationSpecial : MonoBehaviour
{
    public Transform spawn;
    public int valeurAleatoire;
    // Start is called before the first frame update
    public string Generer(string cote)
    {
        GameObject res;
        if (cote.Equals("Gauche")){
            if (PlayerStats.niveau == 1 && RoomManager.PoolG1.Capacity != 0)
            {
                valeurAleatoire = Random.Range(0, RoomManager.PoolG1.Count);
                Instantiate(RoomManager.PoolG1[valeurAleatoire], spawn.position, Quaternion.identity);
                res = RoomManager.PoolG1[valeurAleatoire];
                RoomManager.PoolG1.RemoveAt(valeurAleatoire);
                if (res.name.Equals("Tableaux") || res.name.Equals("Chasseur"))
                    return "Enigme";
                Debug.Log(res.name);
                return res.name;
            }
            if (PlayerStats.niveau == 2 && RoomManager.PoolG2.Capacity != 0)
            {
                valeurAleatoire = Random.Range(0, RoomManager.PoolG2.Count);
                Instantiate(RoomManager.PoolG2[valeurAleatoire], spawn.position, Quaternion.identity);
                res = RoomManager.PoolG2[valeurAleatoire];
                RoomManager.PoolG2.RemoveAt(valeurAleatoire);
                if (res.name.Equals("Tableaux") || res.name.Equals("Chasseur"))
                    return "Enigme";
                Debug.Log(res.name);
                return res.name;
            }
            if (PlayerStats.niveau == 3 && RoomManager.PoolG3.Capacity != 0)
            {
                valeurAleatoire = Random.Range(0, RoomManager.PoolG3.Count);
                Instantiate(RoomManager.PoolG3[valeurAleatoire], spawn.position, Quaternion.identity);
                res = RoomManager.PoolG3[valeurAleatoire];
                RoomManager.PoolG3.RemoveAt(valeurAleatoire);
                if (res.name.Equals("Tableaux") || res.name.Equals("Chasseur"))
                    return "Enigme";
                Debug.Log(res.name);
                return res.name;
            }
            else
            {
                Debug.LogError("Probleme dans Generation Special, on atteint le bout du code");
                return "Probleme";
            }
        }
        if (cote.Equals("Droite")){
            if (PlayerStats.niveau == 1 && RoomManager.PoolD1.Capacity != 0)
            {
                valeurAleatoire = Random.Range(0, RoomManager.PoolD1.Count);
                Instantiate(RoomManager.PoolD1[valeurAleatoire], spawn.position, Quaternion.identity);
                res = RoomManager.PoolD1[valeurAleatoire];
                RoomManager.PoolD1.RemoveAt(valeurAleatoire);
                if (res.name.Equals("Tableaux") || res.name.Equals("Chasseur"))
                    return "Enigme";
                Debug.Log(res.name);
                return res.name;
            }
            if (PlayerStats.niveau == 2 && RoomManager.PoolD2.Capacity != 0)
            {
                valeurAleatoire = Random.Range(0, RoomManager.PoolD2.Count);
                Instantiate(RoomManager.PoolD2[valeurAleatoire], spawn.position, Quaternion.identity);
                res = RoomManager.PoolD2[valeurAleatoire];
                RoomManager.PoolD2.RemoveAt(valeurAleatoire);
                if (res.name.Equals("Tableaux") || res.name.Equals("Chasseur"))
                    return "Enigme";
                Debug.Log(res.name);
                return res.name;
            }
            if (PlayerStats.niveau == 3 && RoomManager.PoolD3.Capacity != 0)
            {
                valeurAleatoire = Random.Range(0, RoomManager.PoolD3.Count);
                Instantiate(RoomManager.PoolD3[valeurAleatoire], spawn.position, Quaternion.identity);
                res = RoomManager.PoolD3[valeurAleatoire];
                RoomManager.PoolD3.RemoveAt(valeurAleatoire);
                if (res.name.Equals("Tableaux") || res.name.Equals("Chasseur"))
                    return "Enigme";
                Debug.Log(res.name);
                return res.name;
            }
            else
            {
                Debug.LogError("Probleme dans Generation Special, on atteint le bout du code");
                return "Probleme";
            }
        }
        else
        {
            Debug.LogError("Ni Droite ni Gauche renseigné");
            return "Probleme";
        }
    }
}