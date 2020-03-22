using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private Animator mAnimator;
    private NavMeshAgent mNavMeshAgent;
    private bool mRunning = false;
//    private bool isGrounded = true;
    public bool selectionne = false;
    //private float jumpForce = 5f;
    //private Vector3 jump;
    //private Vector3 velocity;
    private Vector3 destination;
    bool doubleclick;
    public GameObject pausePanel;
    public static Vector3 playerPosition;
    private float doubleClickTimeLimit = 0.25f;
    public Projector projector;
    bool walkauto = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InputListener());
        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        projector.enabled = false;
        //jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        playerPosition = GetComponent<Transform>().position;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Input.GetMouseButton(0) && !pausePanel.activeSelf)
        {
            if(Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "Sol")
                {
                    walkauto = false;
                    selectionne = false;
                    destination = hit.point;
                    mNavMeshAgent.destination = destination;
                }
                if (hit.collider.tag == "Ennemy")
                {
                    selectionne = true;
                    transform.LookAt(hit.collider.transform);
                }
                if (hit.collider.tag == "Ennemy" && doubleclick)
                {
                    selectionne = true;
                    mNavMeshAgent.destination = hit.collider.transform.position;
                    walkauto = true;
                }
            }
        }
        if ((playerPosition - mNavMeshAgent.destination ).magnitude < 15 && walkauto)
        {
            mNavMeshAgent.ResetPath();
            walkauto = false;
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


        //Gestion de l'affichage de la range
        if (selectionne)
        {
            projector.enabled = true;
        }
        else
        {
            projector.enabled = false;
        }
    }
    private IEnumerator InputListener()
    {
        while (enabled)
        { //Run as long as this is activ

            if (Input.GetMouseButtonDown(0))
                yield return ClickEvent();

            yield return null;
        }
    }

    private IEnumerator ClickEvent()
    {
        //pause a frame so you don't pick up the same mouse down event.
        yield return new WaitForEndOfFrame();

        float count = 0f;
        while (count < doubleClickTimeLimit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                doubleclick = true;
                yield break;
            }
            count += Time.deltaTime;// increment counter by change in time between frames
            yield return null; // wait for the next frame
        }
    }

    void OnCollisionStay()
    {
        //isGrounded = true;
        mNavMeshAgent.enabled = true;
    }
}
