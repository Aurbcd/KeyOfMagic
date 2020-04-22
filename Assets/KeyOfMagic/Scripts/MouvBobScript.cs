using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvBobScript : MonoBehaviour
{
    private Animator mAnimator;
    private NavMeshAgent mNavMeshAgent;
    private GameObject montreSelectionne;
    public static bool attack=false;
    private string memoire="";
    public static AudioClip bobAttack;
    public static AudioClip bobWalk;


    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        bobAttack = Resources.Load<AudioClip>("BobAttack");
        bobWalk = Resources.Load<AudioClip>("BobJump");
    }
    void walkSound()
    {
        GetComponent<AudioSource>().PlayOneShot(bobWalk);
    }
    void jumpSound()
    {
        GetComponent<AudioSource>().PlayOneShot(bobWalk);
    }
    void attackSound()
    {
        GetComponent<AudioSource>().PlayOneShot(bobAttack);
    }

    // Update is called once per frame
    void Update()
    {
        if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
            mNavMeshAgent.ResetPath();
            mAnimator.SetBool("Moving", false);
        }
        else
            mAnimator.SetBool("Moving", true);
        if(ClickToMove.playerRotation.y < 135 && ClickToMove.playerRotation.y > 45)
            if(!attack)
                mNavMeshAgent.destination = ClickToMove.playerPosition + new Vector3(0f, 0f, -2f);
            else
                mNavMeshAgent.destination = ClickToMove.playerPosition + new Vector3(0f, 0f, -3f);
        if (ClickToMove.playerRotation.y < 225 && ClickToMove.playerRotation.y >= 135)
            if (!attack)
                mNavMeshAgent.destination = ClickToMove.playerPosition + new Vector3(-2f, 0f, 0f);
            else
                mNavMeshAgent.destination = ClickToMove.playerPosition + new Vector3(-3f, 0f, 0f);
        if (ClickToMove.playerRotation.y < 315 && ClickToMove.playerRotation.y >= 225)
            if(!attack)
                mNavMeshAgent.destination = ClickToMove.playerPosition + new Vector3(0f, 0f, 2f);
            else
              mNavMeshAgent.destination = ClickToMove.playerPosition + new Vector3(0f, 0f, 3f);
        if ((ClickToMove.playerRotation.y < 45 && ClickToMove.playerRotation.y >= 0) || (ClickToMove.playerRotation.y < 380 && ClickToMove.playerRotation.y >= 315))
            if(!attack)
                mNavMeshAgent.destination = ClickToMove.playerPosition + new Vector3(2f, 0f, 0f);
            else
                mNavMeshAgent.destination = ClickToMove.playerPosition + new Vector3(3f, 0f, 0f);
        GameObject[] ListeMonstre = GameObject.FindGameObjectsWithTag("Ennemy");
        foreach (GameObject monstre in ListeMonstre)
        {
            if (monstre.GetComponent<MonsterMouvSelection>().distanceToPlayer <= 22)
            {
                if (monstre.GetComponent<MonsterMouvSelection>().estSelectionne)
                {
                    montreSelectionne = monstre;
                    transform.LookAt(montreSelectionne.transform.position);
                }
            }
        }

        if (memoire != BobScript.element)
        {
            if(!attack)
            mAnimator.SetTrigger("changing");
            memoire = BobScript.element;
        }

        if (attack)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<NavMeshAgent>().radius = 0.3f;
            GetComponent<AudioSource>().pitch = 0.6f;
            if (montreSelectionne !=null && (montreSelectionne.transform.position - ClickToMove.playerPosition).magnitude < 18) {
                transform.LookAt(montreSelectionne.transform);
                mAnimator.SetBool("Attacking", true);
            }
            else
                mAnimator.SetBool("Attacking", false);

        }
        else
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            GetComponent<NavMeshAgent>().radius = 0.6f;
            GetComponent<AudioSource>().pitch = 1;
        }
    }
}
