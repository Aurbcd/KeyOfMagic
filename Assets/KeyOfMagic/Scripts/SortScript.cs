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
                    int hauteur = (int)monstre.GetComponent<BoxCollider>().size.y;
                    Vector3 decallage = new Vector3(0f, 0f, 0f);
                    if (hauteur > 4)
                    {
                        decallage.y += (float)hauteur - 3;
                    }
                    transform.LookAt(monstre.transform.position + new Vector3(0f, 0.8f, 0f) + decallage);
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
