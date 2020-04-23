using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMouvSelection : MonoBehaviour
{
    public bool estSelectionne = false;

    private NavMeshAgent mNavMeshAgent;

    private Animator mAnimator;

    private GameObject potion;
    
    private bool loot;
    public bool IsDead;
    private bool BobAttackRate;

    private float Position;
    public float distanceToPlayer;

    //Mécanique d'objet de l'apparition de potion
    public static float modificateurApparitionPotions = 1;
    public static int modificateurMinimumPotions = 0;
    public static int modificateurMaximumPotions = 0;

    // Distance entre l'ennemi et sa position de base
    private float DistanceBase;
    private Vector3 basePositions;

    //Son
    public static AudioClip hitPAudio;
    public static AudioClip hitSAudio;
    public static AudioClip enemyA;

    void Start()
    {
        BobAttackRate = true;
        loot = false;
        IsDead = false;
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        mAnimator = GetComponent<Animator>();
        mAnimator.updateMode = AnimatorUpdateMode.Normal;
        basePositions = transform.position;
        potion = Resources.Load<GameObject>("Potion");
        hitPAudio = Resources.Load<AudioClip>("HitP");
        hitSAudio = Resources.Load<AudioClip>("HitS");
        enemyA = Resources.Load<AudioClip>("Woosh");
    }

    // Update is called once per frame
    void Update()
    {
        if (estSelectionne)
        {
            BobScript.element = GetComponent<MonsterStatText>().element;
        }
        mAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        distanceToPlayer = (GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude;
        DistanceBase = Vector3.Distance(basePositions, transform.position);
        if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
            StopMovement();
            mAnimator.SetBool("Moving", false);
        }

        if(distanceToPlayer < 16 && !IsDead && GetComponent<MonsterStatText>().monsterName != "Portail" && GetComponent<MonsterStatText>().monsterName != "Mannequin") 
        {
            mAnimator.SetBool("Backing", false);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(ClickToMove.playerPosition - transform.position), 4 * Time.deltaTime); //SmoothLookAt
        }


        if (distanceToPlayer < 14 && distanceToPlayer > 10 && !IsDead && GetComponent<MonsterStatText>().monsterName != "Portail" && GetComponent<MonsterStatText>().monsterName != "Mannequin")
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(ClickToMove.playerPosition - transform.position), 4*Time.deltaTime); //SmoothLookAt
            MoveInDirection(ClickToMove.playerPosition);
            mAnimator.SetBool("Attacking", false);
            mAnimator.SetBool("Moving", true);
        }
        
        if (distanceToPlayer < 10)
        {
            StopMovement();
            mAnimator.SetBool("Moving", false);
            if (MouvBobScript.attack)
            {
                StartCoroutine(BobAttack());
            }
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
        if (distanceToPlayer > 16 && DistanceBase > 2)
        {
            BackBase();
        }
        if (DistanceBase < 2 && distanceToPlayer > 16)
        {
            if (GetComponent<MonsterStatText>().monsterName != "Portail")
                GetComponent<MonsterStatText>().PV += 3;
            mAnimator.SetBool("Backing", false);
        }

        if (gameObject.GetComponent<MonsterStatText>().PV <= 0) //Mort
        {
            GetComponent<BoxCollider>().enabled = false;
            mAnimator.SetBool("IsDead", true);
            GameObject[] aDetruire = GameObject.FindGameObjectsWithTag("ADetruireMonstre");
            foreach (GameObject s in aDetruire)
                Destroy(s);
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
            Destroy(transform.gameObject, 2f);
        }
    }

    public void MoveInDirection(Vector3 direction)
    {
        if(GetComponent<MonsterStatText>().monsterName != "Portail")
            GetComponent<MonsterStatText>().PV += 3;
        mNavMeshAgent.destination = direction;
    }

    public void HitP()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (!PlayerStats.IsDead)
        {
            if(PlayerStats.playerShieldPoints == 0)
            {
                player.GetComponent<AudioSource>().PlayOneShot(hitPAudio, 0.5f);
                player.GetComponent<Animator>().Play("GetHit");
            }
            if (PlayerStats.playerShieldPoints > 0)
            {
                player.GetComponent<AudioSource>().PlayOneShot(hitSAudio, 0.5f);
            }
        }
    }
    public void AttackSound()
    {
        GetComponent<AudioSource>().PlayOneShot(enemyA,0.5f);
    }
    public void StopMovement()
    {
        mNavMeshAgent.ResetPath();
    }
    IEnumerator BobAttack()
    {
        if (BobAttackRate)
        {
            BobAttackRate = false;
            yield return new WaitForSeconds(0.83f);
            GetComponent<MonsterStatText>().PV -= 5;
            BobAttackRate = true;
        }
    }
    public void BackBase()
    {
        if (GetComponent<MonsterStatText>().monsterName != "Portail")
            GetComponent<MonsterStatText>().PV += 3;
        mAnimator.SetBool("Backing", true);
        MoveInDirection(basePositions);
    }
}
