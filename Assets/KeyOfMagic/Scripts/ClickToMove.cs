﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {
    private Animator mAnimator;
    private NavMeshAgent mNavMeshAgent;
    private bool mRunning = false;
    //Affichage de sort
    public GameObject sortEau;
    public GameObject Gemme;
    //private bool isGrounded = true;
    public static bool selectionne = false;
    //private float jumpForce = 5f;
    //private Vector3 jump;
    //private Vector3 velocity;
    private Vector3 destination;
    public bool doubleclick;
    public static bool pAttack;
    public GameObject pausePanel;
    public static Vector3 playerPosition;
    private float doubleClickTimeLimit = 0.25f;
    public Projector projector;
    bool walkautomonstre = true;
    bool walkautoItem = true;
    //Curseur
    public CursorMode cursormode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Texture2D CursorRamasser;
    public Texture2D CursorClassique;
    // Start is called before the first frame update
    void Start () {
        StartCoroutine (InputListener ());
        mAnimator = GetComponent<Animator> ();
        mNavMeshAgent = GetComponent<NavMeshAgent> ();
        projector.enabled = false;
        //jump = new Vector3(0.0f, 2.0f, 0.0f);
        Cursor.SetCursor (CursorClassique, hotSpot, cursormode);
    }

    // Update is called once per frame
    void Update () {

        playerPosition = GetComponent<Transform> ().position;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

        RaycastHit hit;
        RaycastHit hit2;
        Cursor.SetCursor (CursorClassique, hotSpot, cursormode);
        if (Physics.Raycast (ray, out hit2, 100)) {
            if (hit2.collider.tag == "Item") {
                Cursor.SetCursor (CursorRamasser, hotSpot, cursormode);
            }
        }
        if (Input.GetMouseButton (0) && !pausePanel.activeSelf) {
            if (Physics.Raycast (ray, out hit, 100)) {

                if (hit.collider.tag == "Sol") {
                    walkautomonstre = false;
                    walkautoItem = false;
                    selectionne = false;
                    destination = hit.point;
                    mNavMeshAgent.destination = destination;
                }
                if (hit.collider.tag == "Ennemy") {
                    selectionne = true;
                    transform.LookAt (hit.collider.transform);
                }
                if (hit.collider.tag == "Ennemy" && doubleclick) {
                    selectionne = true;
                    mNavMeshAgent.destination = hit.collider.transform.position;
                    walkautomonstre = true;
                }
                if (hit.collider.tag == "Item" && doubleclick) {
                    selectionne = true;
                    mNavMeshAgent.destination = hit.collider.transform.position;
                    walkautoItem = true;
                }
                doubleclick = false;
            }
        }
        if ((playerPosition - mNavMeshAgent.destination).magnitude < 20 && walkautomonstre) {
            mNavMeshAgent.ResetPath ();
            walkautomonstre = false;
        }
        if ((playerPosition - mNavMeshAgent.destination).magnitude < 3 && walkautoItem) {
            mNavMeshAgent.ResetPath ();
            walkautoItem = false;
        }

        if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance) {
            mRunning = false;
        } else {
            mRunning = true;
        }

        mAnimator.SetBool ("Moving", mRunning);


        StartCoroutine(WaitForAnimation());


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
        if (selectionne) {
            projector.enabled = true;
        } else {
            projector.enabled = false;
        }
    }
    private IEnumerator InputListener () {
        while (enabled) { //Run as long as this is activ

            if (Input.GetMouseButtonDown (0))
                yield return ClickEvent ();

            yield return null;
        }
    }

    private IEnumerator ClickEvent () {
        //pause a frame so you don't pick up the same mouse down event.
        yield return new WaitForEndOfFrame ();

        float count = 0f;
        while (count < doubleClickTimeLimit) {
            if (Input.GetMouseButtonDown (0)) {
                doubleclick = true;
                yield break;
            }
            count += Time.deltaTime; // increment counter by change in time between frames
            yield return null; // wait for the next frame
        }
    }
    private IEnumerator WaitForAnimation()
    {
        if (pAttack)
        {
            mAnimator.SetTrigger("Attack1Trigger");
            yield return new WaitForSeconds(0.25f);
            GameObject clone = Instantiate(sortEau, Gemme.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            Destroy(clone);
            pAttack = false;
        }
    }

    void OnCollisionStay () {
        //isGrounded = true;
        mNavMeshAgent.enabled = true;
    }
}