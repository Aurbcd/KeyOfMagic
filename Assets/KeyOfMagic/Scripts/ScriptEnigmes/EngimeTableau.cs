using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngimeTableau : MonoBehaviour
{
    public List<string> reponse = new List<string>();
    public List<string> buffer = new List<string>();
    private GameObject player;
    public GameObject coffre;
    public bool ouvert;
    public static AudioClip bravo;

    // Start is called before the first frame update
    void Start()
    {
        Porte.NombrePNJ += 1;
        bravo = Resources.Load<AudioClip>("Fontaine");
        player = GameObject.Find("Player");
        ouvert = false;
        reponse.Capacity = 3;
        buffer.Capacity = 3;
        foreach (GameObject tab in GameObject.FindGameObjectsWithTag("Tableau"))
        {
            reponse[tab.GetComponentInChildren<Tableau>().numero] = tab.GetComponentInChildren<Tableau>().element;
        }
    }

    void groan()
    {
       string choixActuel = player.GetComponent<ImprovedSpellInput>().choix;
            if (choixActuel[0].Equals('a'))
            {
                buffer.RemoveAt(0);
                buffer.Add("Eau");
            }
            if (choixActuel[0].Equals('u'))
            {
                buffer.RemoveAt(0);
                buffer.Add("Feu");
            }
            if (choixActuel[0].Equals('o'))
            {
                buffer.RemoveAt(0);
                buffer.Add("Terre");
            }
            if (choixActuel[0].Equals('e'))
            {
                buffer.RemoveAt(0);
                buffer.Add("Air");
            }
            if (choixActuel[0].Equals('i'))
            {
                buffer.RemoveAt(0);
                buffer.Add("Electricite");
            }
        if (CheckMatch(buffer, reponse) && !ouvert)
        {
            ouvert = true;
            GetComponent<AudioSource>().PlayOneShot(bravo);
            GameObject potion = Resources.Load<GameObject>("Potion");
            Vector3 Aleatoire = new Vector3(Random.Range(0, 1), 0, Random.Range(0, 1));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(Random.Range(0, 2), 0, Random.Range(0, 2));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(Random.Range(0, 3), 0, Random.Range(0, 3));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(Random.Range(0, 4), 0, Random.Range(0, 4));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(Random.Range(0, 4), 0, Random.Range(0, 4));
            Instantiate(potion, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            Aleatoire = new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
            Instantiate(coffre, transform.localPosition + transform.TransformDirection(Aleatoire), Quaternion.identity);
            tag = "Untagged";
            Porte.NombrePNJ -= 1;
        }
    }

    bool CheckMatch(List<string> l1, List<string> l2)
    {
        if (l1.Count != l2.Count)
            return false;
        for (int i = 0; i < l1.Count; i++)
        {
            if (l1[i] != l2[i])
                return false;
        }
        return true;
    }
}
