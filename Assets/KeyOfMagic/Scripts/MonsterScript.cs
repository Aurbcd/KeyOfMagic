using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterScript : MonoBehaviour
{
    public int healthPoints;
    public string monsterName;

    private NavMeshAgent mNavMeshAgent;
    private bool mRunning = false;
    private bool isGrounded = true;

    private float distanceToPlayer;

    void Start()
    {
        mNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = (GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude;

        if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
            StopMovement();
        }

        if (distanceToPlayer < 10)
        {
            MoveInDirection(ClickToMove.playerPosition);
        }
        
        if (distanceToPlayer < 5)
        {
            StopMovement();
        }

    }

    public void MoveInDirection(Vector3 direction)
    {
        mNavMeshAgent.destination = direction;
    }

    public void StopMovement()
    {
        mNavMeshAgent.ResetPath();
    }
}
