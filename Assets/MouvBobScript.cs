﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvBobScript : MonoBehaviour
{
    private Animator mAnimator;
    private NavMeshAgent mNavMeshAgent;
    private GameObject montreSelectionne;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
            mNavMeshAgent.ResetPath();
            mAnimator.SetBool("Moving", false);
        }else
        mAnimator.SetBool("Moving", true);
        mNavMeshAgent.destination = ClickToMove.playerPosition + new Vector3(2f, 2f, 0f);
        GameObject[] ListeMonstre = GameObject.FindGameObjectsWithTag("Ennemy");
        foreach (GameObject monstre in ListeMonstre)
        {
            if (monstre.GetComponent<MonsterMouvSelection>().distanceToPlayer <= 22)
            {
                if (monstre.GetComponent<MonsterMouvSelection>().estSelectionne)
                {
                    montreSelectionne = monstre;
                    transform.LookAt(montreSelectionne.transform.position);
                }
            }
        }

        foreach(ItemInterface item in InventaireScript.items)
        {
            if (item.Nom == "Anneau de Bob")
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                if ((montreSelectionne.transform.position - ClickToMove.playerPosition).magnitude < 18)
                    mAnimator.SetBool("Attacking", true);
                else
                    mAnimator.SetBool("Attacking", false);
            }
        }

    }
}
