using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationDeMonstre : MonoBehaviour
{
    public Transform spawn;
    public List<GameObject> enemyPool;
    public GameObject player;
    public int valeurAleatoire;
    // Start is called before the first frame update
    void Awake()
    {

        valeurAleatoire = Random.Range(0,enemyPool.Count);
        Instantiate(enemyPool[valeurAleatoire], spawn.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
