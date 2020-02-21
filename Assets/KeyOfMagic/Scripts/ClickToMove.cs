using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private Animator mAnimator;
    private NavMeshAgent mNavMeshAgent;
    private bool mRunning = false;
    private bool isGrounded = true;
    public bool selectionne = false;
    //private float jumpForce = 5f;
    //private Vector3 jump;
    //private Vector3 velocity;
    private Vector3 destination;

    public static Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {

        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        //jump = new Vector3(0.0f, 2.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GetComponent<Transform>().position;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Input.GetMouseButton(0))
        {
            if(Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "Sol")
                {
                    selectionne = false;
                    destination = hit.point;
                    mNavMeshAgent.destination = destination;
                }
                if (hit.collider.tag == "Ennemy")
                {
                    selectionne = true;
                }
            }
        }


        
        if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
            mRunning = false;
            //mNavMeshAgent.ResetPath();
        }
        else
        {
            mRunning = true;
        }
        

        mAnimator.SetBool("Moving", mRunning);

        /*
        if (Input.GetKeyDown("space") && isGrounded)
        {
            velocity = new Vector3(0, 0, 0);
            velocity += mNavMeshAgent.velocity;
            mNavMeshAgent.enabled = false;
            GetComponent<Rigidbody>().velocity = velocity * 1.3f;
            GetComponent<Rigidbody>().AddForce(0, 100 * jumpForce, 0, ForceMode.Impulse);
            isGrounded = false;
        }
        */

    }

    void OnCollisionStay()
    {
        isGrounded = true;
        mNavMeshAgent.enabled = true;
    }
}
