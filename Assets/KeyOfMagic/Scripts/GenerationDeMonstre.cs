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
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if(player.GetComponent<PlayerStats>().playerHealthPoints <=0)
            {
                return;
            }
            Debug.Log("Oui");
            Instantiate(enemy, spawn.position, Quaternion.identity);
        }        
    }
}
