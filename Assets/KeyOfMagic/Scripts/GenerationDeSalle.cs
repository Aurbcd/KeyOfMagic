using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationDeSalle : MonoBehaviour
{
    public Transform spawn;
    public static List<string> PoolG = new List<string>();
    public static List<string> PoolD = new List<string>();
    private GameObject instance;

    // Start is called before the first frame update
     void Start()
     {
        PoolG.Add("PasDeSalle");
        //PoolG.Add("SalleDeCoffre");
        //PoolG.Add("SalleDeFontaine");
        MelangePoolG();
        MelangePoolD();
     }

    public string Generer(string cote)
    {
        if (cote.Equals("Droite")){
            string res = PoolD[0];
            PoolD.RemoveAt(0);
            if(res == "PasDeSalle")
                return res;
            if (res == "SalleDeCoffre")
            {
                instance = Instantiate(Resources.Load<GameObject>("Coffre"), spawn.position, Quaternion.identity);
                instance.transform.LookAt(transform.position);
                return res;
            }
            if (res == "SalleDeFontaine")
            {
                instance = Instantiate(Resources.Load<GameObject>("Fontaine"), spawn.position, Quaternion.identity);
                instance.transform.LookAt(transform.position);
                return res;
            }
            else
            {
                Debug.LogError("Aucune salle ne correspond");
                return "Probleme";
            }
        }
        if (cote.Equals("Gauche"))
        {
            string res = PoolG[0];
            PoolG.RemoveAt(0);
            if (res == "PasDeSalle")
                return res;
            if (res == "SalleDeCoffre")
            {
                instance = Instantiate(Resources.Load<GameObject>("Coffre"), spawn.position, Resources.Load<GameObject>("Coffre").transform.rotation);
                instance.transform.LookAt(transform.position);
                return res;
            }
            if (res == "SalleDeFontaine")
            {
                instance = Instantiate(Resources.Load<GameObject>("Fontaine"), spawn.position, Quaternion.identity);
                instance.transform.LookAt(transform.position);
                return res;
            }
            else
            {
                Debug.LogError("Aucune salle ne correspond");
                return "Probleme";
            }
        }
        else
        {
            Debug.LogError("Ni Droite ou Gauche renseigné");
            return "Probleme";
        }
    }
    public void MelangePoolD()
    {
        var count = PoolD.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = PoolD[i];
            PoolD[i] = PoolD[r];
            PoolD[r] = tmp;
        }
    }

    public void MelangePoolG()
    {
        var count = PoolG.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = PoolG[i];
            PoolG[i] = PoolG[r];
            PoolG[r] = tmp;
        }
    }
}
