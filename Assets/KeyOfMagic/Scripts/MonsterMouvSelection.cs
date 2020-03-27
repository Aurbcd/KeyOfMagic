using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMouvSelection : MonoBehaviour
{
    public bool estSelectionne = false;

    private NavMeshAgent mNavMeshAgent;

    private Animator mAnimator;

    public GameObject potion;
    
    private bool loot;
    public bool IsDead;

    private float Position;
    public float distanceToPlayer;

    //Mécanique d'objet de l'apparition de potion
    public static float modificateurApparitionPotions = 1;
    public static int modificateurMinimumPotions = 0;
    public static int modificateurMaximumPotions = 0;

    // Distance entre l'ennemi et sa position de base
    private float DistanceBase;
    private Vector3 basePositions;

    void Start()
    {
        loot = false;
        IsDead = false;
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        mAnimator = GetComponent<Animator>();
        mAnimator.updateMode = AnimatorUpdateMode.Normal;
        basePositions = transform.position;
        potion = GameObject.Find("Potion");
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


        if (distanceToPlayer < 20 && distanceToPlayer > 15)
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
                BobScript.element = GetComponent<MonsterStatText>().element;
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
        if (DistanceBase < 2 && distanceToPlayer > 22)
        {
            GetComponent<MonsterStatText>().PV += 3;
            mAnimator.SetBool("Backing", false);
        }

        if (gameObject.GetComponent<MonsterStatText>().PV <= 0) //Mort
        {
            mAnimator.SetBool("IsDead", true);
            IsDead = true;
            ClickToMove.selectionne = false;

            if (!loot)
            {
                int NombreDePotions= Random.Range(0 + modificateurMinimumPotions, (int)(modificateurApparitionPotions * PlayerStats.playerMaxHeathPoints*3/200) + 1 + modificateurMaximumPotions);
                int i = 0;
                while (i < NombreDePotions)
                {
                    Position = Random.Range(1f, 3f);
                    i += 1;
                    Instantiate(potion, transform.position + new Vector3(1f * Position, 1f * Position, 1 * Position), Quaternion.identity);
                }
                loot = true;
            }
            Destroy(transform.gameObject, 2);
        }
    }

    public void MoveInDirection(Vector3 direction)
    {
        GetComponent<MonsterStatText>().PV += 3;
        mNavMeshAgent.destination = direction;
    }

    public void StopMovement()
    {
        mNavMeshAgent.ResetPath();
    }
    public void BackBase()
    {
        GetComponent<MonsterStatText>().PV += 3;
        mAnimator.SetBool("Backing", true);
        MoveInDirection(basePositions);
    }
}
