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
    public float jumpForce = 5f;
    private Vector3 jump;
    private Vector3 velocity;
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {

        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Input.GetMouseButton(0) && isGrounded)
        {
            if(Physics.Raycast(ray, out hit, 100))
            {
                destination = hit.point;
                mNavMeshAgent.destination = destination;
            }
        }



        if ((mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)   || ((Mathf.Abs(destination.x - gameObject.transform.position.x)) < 0.2f && (Mathf.Abs(destination.z - gameObject.transform.position.z)) < 0.2f))
        {
            mRunning = false;
            mNavMeshAgent.ResetPath();
        }
        else
        {
            mRunning = true;
        }
        

        mAnimator.SetBool("Moving", mRunning);

        if (Input.GetKeyDown("space") && isGrounded)
        {
            velocity = new Vector3(0, 0, 0);
            velocity += mNavMeshAgent.velocity;
            mNavMeshAgent.enabled = false;
            GetComponent<Rigidbody>().velocity = velocity * 1.3f;
            GetComponent<Rigidbody>().AddForce(0, 100 * jumpForce, 0, ForceMode.Impulse);
            isGrounded = false;
        }


    }

    void OnCollisionStay()
    {
        isGrounded = true;
        mNavMeshAgent.enabled = true;
    }
}
