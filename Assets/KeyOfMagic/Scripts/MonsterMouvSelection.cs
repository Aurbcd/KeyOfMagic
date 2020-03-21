using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMouvSelection : MonoBehaviour
{
    public bool estSelectionne = false;

    private NavMeshAgent mNavMeshAgent;

    private Animator mAnimator;

    public float distanceToPlayer;

    void Start()
    {
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        mAnimator = GetComponent<Animator>();
        mAnimator.updateMode = AnimatorUpdateMode.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        mAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        distanceToPlayer = (GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude;
        if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
            StopMovement();
            mAnimator.SetBool("Moving", false);
        }

        if (distanceToPlayer < 20)
        {
            MoveInDirection(ClickToMove.playerPosition);
            mAnimator.SetBool("Attacking", false);
            mAnimator.SetBool("Moving", true);
        }
        
        if (distanceToPlayer < 15)
        {
            StopMovement();
            mAnimator.SetBool("Moving", false);
            mAnimator.SetBool("Attacking", true);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, 100) && hit.collider.gameObject == gameObject)
            {
                estSelectionne = true;
            }
            else
            {
                estSelectionne = false;
            }
        }

   
        if(gameObject.GetComponent<MonsterStatText>().PV <= 0) //Mort
        {
            mAnimator.SetBool("IsDead", true);
            Destroy(transform.gameObject, 2);
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
