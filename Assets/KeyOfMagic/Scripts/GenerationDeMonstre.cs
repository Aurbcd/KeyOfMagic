using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationDeMonstre : MonoBehaviour
{
    public List<Transform> spawns;
    public List<GameObject> enemyPool1, enemyPool2, enemyPool3;
    public int valeurAleatoire;
    // Start is called before the first frame update
    public void Generer()
    {
        if (PlayerStats.niveau == 1 && enemyPool1.Capacity != 0)
        {
            foreach (Transform spawn in spawns)
            {
                valeurAleatoire = Random.Range(0, enemyPool1.Count);
                Instantiate(enemyPool1[valeurAleatoire], spawn.position, Quaternion.identity);
            }
        }
        if (PlayerStats.niveau == 2 && enemyPool2.Capacity != 0)
        {
            foreach (Transform spawn in spawns)
            {
                valeurAleatoire = Random.Range(0, enemyPool2.Count);
                Instantiate(enemyPool2[valeurAleatoire], spawn.position, Quaternion.identity);
            }
        }
        if (PlayerStats.niveau == 3 && enemyPool1.Capacity != 0)
        {
            foreach (Transform spawn in spawns)
            {
                valeurAleatoire = Random.Range(0, enemyPool3.Count);
                Instantiate(enemyPool3[valeurAleatoire], spawn.position, Quaternion.identity);
            }
        }
    }
}
