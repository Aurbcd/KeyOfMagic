using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationDeMonstre : MonoBehaviour
{
    public Transform spawn;
    public GameObject enemy;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, spawn.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
