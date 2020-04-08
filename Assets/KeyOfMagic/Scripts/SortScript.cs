using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] ListeMonstre = GameObject.FindGameObjectsWithTag("Ennemy");
        foreach (GameObject monstre in ListeMonstre)
        {
            if (monstre.GetComponent<MonsterMouvSelection>().distanceToPlayer <= 20)
            {
                if (monstre.GetComponent<MonsterMouvSelection>().estSelectionne || monstre.GetComponent<MonsterMouvSelection>().IsDead)
                {
                    transform.LookAt(monstre.transform.position + new Vector3(0f, 0.8f, 0f));
                }
            }
        }
        Destroy(gameObject, 0.5f);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
