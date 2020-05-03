using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffreScript : MonoBehaviour
{
    public List<GameObject> ListeItem;
    private bool ouvert;
    public GameObject Drop;
    private ItemInterface choix;
    //Son
    public static AudioClip coffre;

    // Start is called before the first frame update
    void Start()
    {
        ouvert = false;
        coffre = Resources.Load<AudioClip>("Coffre");

        var hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, 10f);
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject == transform.gameObject)
                continue;

            transform.position = hit.point;
            break;
        }
        transform.LookAt(ClickToMove.playerPosition);
    }

    void OnMouseDown() { 
        if ((GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude < 14)
        {
            if (!ouvert)
            {
                int Rareté = Random.Range(1, 101);
                int Type = Random.Range(0, 5);
                if (Rareté <= 50)
                {
                    choix = ListeItem[Type].GetComponent<ItemInterface>();
                    Drop = ListeItem[Type];
                }
                if (Rareté > 50 && Rareté <= 75)
                {
                    choix = ListeItem[Type + 5].GetComponent<ItemInterface>();
                    Drop = ListeItem[Type+5];
                }
                if (Rareté > 75 && Rareté <= 88)
                {
                    choix = ListeItem[Type + 10].GetComponent<ItemInterface>();
                    Drop = ListeItem[Type+10];
                }
                if (Rareté > 88 && Rareté <= 100)
                {
                    choix = ListeItem[Type + 15].GetComponent<ItemInterface>();
                    Drop = ListeItem[Type+15];
                }
                while(InventaireScript.itemsRencontres.Contains(choix)) {
                    Rareté = Random.Range(1, 101);
                    Type = Random.Range(0, 5);
                    if (Rareté <= 50)
                    {
                        choix = ListeItem[Type].GetComponent<ItemInterface>();
                        Drop = ListeItem[Type];
                    }
                    if (Rareté > 50 && Rareté <= 75)
                    {
                        choix = ListeItem[Type + 5].GetComponent<ItemInterface>();
                        Drop = ListeItem[Type+5];
                    }
                    if (Rareté > 75 && Rareté <= 88)
                    {
                        choix = ListeItem[Type + 10].GetComponent<ItemInterface>();
                        Drop = ListeItem[Type+10];
                    }
                    if (Rareté > 88 && Rareté <= 100)
                    {
                        choix = ListeItem[Type + 15].GetComponent<ItemInterface>();
                        Drop = ListeItem[Type+15];
                    }
                }
                InventaireScript.itemsRencontres.Add(choix);
                ouvert = true;
                this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Open", true);
                GetComponent<AudioSource>().PlayOneShot(coffre);
                Instantiate(Drop, transform.localPosition + transform.TransformDirection(new Vector3(0, 0, 1.5f)), Quaternion.identity);
                Collider collider = (choix as MonoBehaviour).GetComponent<Collider>();
                if (!collider.enabled)
                {
                    collider.enabled = true;
                }
            }
        }
    }
}
