using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicScript : MonoBehaviour
{
    public List<GameObject> ListeItem;
    public GameObject Drop;
    private ItemInterface choix;
    private bool drop;

    private void Start()
    {
        drop = false;
    }

    void Update()
    {
        if(GetComponent<MonsterStatText>().PV <= 0 && !drop)
        {
            Choix();
            Choix();
            drop = true;
        }
    }

    void Choix() { 

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
                Vector3 Aleatoire = new Vector3(Random.Range(0, 2), 0, Random.Range(0, 2));
                Instantiate(Drop, (transform.position + ClickToMove.playerPosition) / 2 + Aleatoire, Quaternion.identity);
                Collider collider = (choix as MonoBehaviour).GetComponent<Collider>();
                if (!collider.enabled)
                {
                    collider.enabled = true;
                }
            }
        }
