using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trapdoor : MonoBehaviour
{
    public bool ouvert;
    private ParticleSystem PS;
    public static bool OpenTrapdoor;

    public static AudioClip trapdoor;

    // Start is called before the first frame update
    void Start()
    {
        OpenTrapdoor = false;
        ouvert = false;
        trapdoor = Resources.Load<AudioClip>("Coffre");
        PS = GetComponentInChildren<ParticleSystem>();
        PS.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenTrapdoor)
        {
            PS.Play();
        }
    }

    private void OnMouseDown()
    {
        if((transform.position - ClickToMove.playerPosition).magnitude < 8)
        {
            if (OpenTrapdoor)
            {
                OpenTrapdoor = false;
                StartCoroutine(Ouverture());
            }
        }
    }

    IEnumerator Ouverture()
    {
        GetComponent<AudioSource>().PlayOneShot(trapdoor);
        GetComponent<Animator>().SetBool("Open", true);
        RoomManager.PoolD1.Clear();
        RoomManager.PoolD2.Clear();
        RoomManager.PoolD3.Clear();
        RoomManager.PoolG1.Clear();
        RoomManager.PoolG2.Clear();
        RoomManager.PoolG3.Clear();
        //Enigmes
        EngimeChasseur.compteur = 0;
        PlayerStats.niveau += 1;
        yield return new WaitForSeconds(1);
        foreach (Object item in InventaireScript.items)
        {
            DontDestroyOnLoad(item);
        }
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Item"))
        {
            Destroy(item);
        }
        GameObject.Find("Canvas").GetComponent<LevelLoader>().ChangeScene();
    }
}
