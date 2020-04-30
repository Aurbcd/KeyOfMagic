using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {
    private Animator mAnimator;
    private NavMeshAgent mNavMeshAgent;
    private bool mRunning = false;
    //private bool isGrounded = true;
    public static bool selectionne = false;
    //private float jumpForce = 5f;
    //private Vector3 jump;
    //private Vector3 velocity;
    private Vector3 destination;
    public bool doubleclick;
    public GameObject pausePanel;
    public static Vector3 playerPosition;
    public static Vector3 playerRotation;
    private float doubleClickTimeLimit = 0.5f;
    public Projector projector;
    bool walkautomonstre = true;
    bool walkautoItem = true;
    //Curseur
    public CursorMode cursormode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Texture2D CursorRamasser;
    public Texture2D CursorClassique;
    //Inventaire
    public InventaireScript inventaire;
    //Son
    public static AudioClip walkClip;
    public AudioMixerGroup soundEffectPlayer;

    // Start is called before the first frame update
    void Start () {
        StartCoroutine (InputListener ());
        mAnimator = GetComponent<Animator> ();
        mNavMeshAgent = GetComponent<NavMeshAgent> ();
        mAnimator.SetBool("Selectionne", false);
        projector.enabled = false;
        //jump = new Vector3(0.0f, 2.0f, 0.0f);
        Cursor.SetCursor (CursorClassique, hotSpot, cursormode);
        walkClip = Resources.Load<AudioClip>("Walk");
    }

    // Update is called once per frame
    void Update () {
        playerPosition = GetComponent<Transform> ().position;
        playerRotation = GetComponent<Transform>().eulerAngles;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

        RaycastHit hit;
        RaycastHit hit2;
        Cursor.SetCursor (CursorClassique, hotSpot, cursormode);
        if (Physics.Raycast (ray, out hit2, 100)) {
            if (hit2.collider.tag == "Item") {
                Cursor.SetCursor (CursorRamasser, hotSpot, cursormode);
            }
        }
        if (Input.GetMouseButton (0) && !PlayerStats.IsDead) {
            if (Physics.Raycast (ray, out hit, 100)) {
                mAnimator.SetBool("Selectionne", false);
                if (hit.collider.tag == "Sol") {
                    walkautomonstre = false;
                    walkautoItem = false; 
                    selectionne = false;
                    destination = hit.point;
                    mNavMeshAgent.destination = destination;
                }
                if (hit.collider.tag == "Ennemy") {
                    selectionne = true;
                    mAnimator.SetBool("Selectionne", true);
                    transform.LookAt (hit.collider.transform);
                    GameObject.Find("Bob").transform.LookAt(hit.collider.transform);
                }
                if (hit.collider.tag == "Item")
                {
                    selectionne = false;
                    transform.LookAt(hit.collider.transform);
                    ItemInterface item = hit.collider.GetComponent<ItemInterface>();
                    if(item != null && (playerPosition - hit.collider.transform.position).magnitude < 5 && item.Nom !="Votre Fiche")
                    {
                        inventaire.AjouterItem(item);
                    }
                    if(item != null && item.Nom.Equals("Votre Fiche"))
                        item.Ramasse();
                }
                if (hit.collider.tag == "Ennemy" && doubleclick) {
                    selectionne = true;
                    mNavMeshAgent.destination = hit.collider.transform.position;
                    walkautomonstre = true;
                }
                if (hit.collider.tag == "Potion" && doubleclick || hit.collider.tag == "CoffreAFermer" && doubleclick) {
                    selectionne = false;
                    mNavMeshAgent.destination = hit.collider.transform.position;
                    walkautoItem = true;
                }

                if (hit.collider.tag == "Item" && doubleclick)
                {
                    selectionne = false;
                    mNavMeshAgent.destination = hit.collider.transform.position;
                    walkautoItem = true;
                }
                doubleclick = false;
            }
        }
        if ((playerPosition - mNavMeshAgent.destination).magnitude < 14 && walkautomonstre) {
            mNavMeshAgent.ResetPath ();
            mAnimator.SetBool("Selectionne", true);
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
        //pause a frame so you don't pick up the same mouse down even
        yield return new WaitForSeconds(0.1f);

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

    void walk()
    {
        if (mRunning)
        {
            GetComponent<AudioSource>().outputAudioMixerGroup = soundEffectPlayer;
            GetComponent<AudioSource>().PlayOneShot(walkClip, 0.4f);
        }
    }
}