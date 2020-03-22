using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AA_Template: MonoBehaviour
{
    public float distanceToPlayer;
    private NavMeshAgent mNavMeshAgent;
    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = (GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude;
        if (distanceToPlayer < 15 && gameObject.GetComponent<MonsterStatText>().PV <= 0)
        {
            mNavMeshAgent.ResetPath();
            mAnimator.SetBool("Attacking", true);
            //Code du monstre



            //Code du monstre
        }

    }
}
