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

    // Distance entre l'ennemi et sa position de base
    private float DistanceBase;
    private Vector3 basePositions;

    void Start()
    {
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        mAnimator = GetComponent<Animator>();
        mAnimator.updateMode = AnimatorUpdateMode.Normal;
        basePositions = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        distanceToPlayer = (GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude;
        DistanceBase = Vector3.Distance(basePositions, transform.position);
        if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
            StopMovement();
            mAnimator.SetBool("Moving", false);
        }

        if(distanceToPlayer < 22) 
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(ClickToMove.playerPosition - transform.position), 4 * Time.deltaTime); //SmoothLookAt
        }


        if (distanceToPlayer < 20)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(ClickToMove.playerPosition - transform.position), 4*Time.deltaTime); //SmoothLookAt
            MoveInDirection(ClickToMove.playerPosition);
            mAnimator.SetBool("Attacking", false);
            mAnimator.SetBool("Moving", true);
        }
        
        if (distanceToPlayer < 15)
        {
            StopMovement();
            mAnimator.SetBool("Moving", false);
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

        if (distanceToPlayer > 22 && DistanceBase > 2)
        {
            BackBase();
        }
        if (DistanceBase < 2)
        {
            mAnimator.SetBool("Backing", false);
        }

        if (gameObject.GetComponent<MonsterStatText>().PV <= 0) //Mort
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            mAnimator.SetBool("IsDead", true);
            int random = Random.Range(0, 30);
            //Apparition du loot
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
    public void BackBase()
    {
        mAnimator.SetBool("Backing", true);
        MoveInDirection(basePositions);
    }
}
