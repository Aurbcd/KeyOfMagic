using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public int healthPoints;
    public string monsterName;
    public bool estSelectionne = false;

    private NavMeshAgent mNavMeshAgent;

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

        if (distanceToPlayer < 20)
        {
            MoveInDirection(ClickToMove.playerPosition);
        }
        
        if (distanceToPlayer < 15)
        {
            StopMovement();
        }
        


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, 100) && hit.collider.gameObject == gameObject)
            {
                estSelectionne = true;
            }
        }

        if (estSelectionne)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
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
