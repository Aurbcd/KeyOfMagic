using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationDeMonstre : MonoBehaviour
{
    public List<Transform> spawns;
    public List<GameObject> enemyPool;
    public GameObject player;
    public int valeurAleatoire;
    // Start is called before the first frame update
    public void generer()
    {
        if (enemyPool.Capacity != 0)
        {
            foreach(Transform spawn in spawns)
            {
                valeurAleatoire = Random.Range(0, enemyPool.Count);
                Instantiate(enemyPool[valeurAleatoire], spawn.position, Quaternion.identity);
            }
        }
    }
}
