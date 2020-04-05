using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffreScriptType : MonoBehaviour
{
    public List<GameObject> ListeItem;
    private bool ouvert;
    public int Type;
    public GameObject Drop;
    private ItemInterface choix;
    // Start is called before the first frame update
    void Start()
    {
        ouvert = false;
    }

    // Update is called once per frame
    void OnMouseDown() { 
        if ((GetComponent<Transform>().position - ClickToMove.playerPosition).magnitude < 9)
        {
            if (!ouvert)
            {
                int Rareté = Random.Range(1, 101);
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
                Instantiate(Drop, (transform.position + ClickToMove.playerPosition) / 2, Quaternion.identity);
                Collider collider = (choix as MonoBehaviour).GetComponent<Collider>();
                if (!collider.enabled)
                {
                    collider.enabled = true;
                }
                GameObject[] aFermer = GameObject.FindGameObjectsWithTag("CoffreAFermer");
                foreach (GameObject s in aFermer)
                    s.GetComponent<CoffreScriptType>().ouvert = true;
            }
        }
    }
}
