using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventaireScript : MonoBehaviour
{
    private List<int> itemsType = new List<int>();
    public static List<ItemInterface> items = new List<ItemInterface>();
    public static List<ItemInterface> itemsRencontres = new List<ItemInterface>();
    public event EventHandler<InventoryEventArgs> ItemAjouté;
    public event EventHandler<InventoryEventArgs> ItemJeté;
    public static AudioClip ItemRamasseS;
    private void Start()
    {
        ItemRamasseS = Resources.Load<AudioClip>("PickUp");
    }

    public void AjouterItem(ItemInterface item)
    {
        foreach(ItemInterface it in items)
        {
            if (it.Type == item.Type)
                JeterItem(it);
        }
        Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
        if (collider.enabled)
        {
            collider.enabled = false;
            items.Add(item);
            item.Ramasse();
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(ItemRamasseS, 0.4f);
        }
        ItemAjouté?.Invoke(this, new InventoryEventArgs(item));
    }
    public void JeterItem(ItemInterface item)
    {
        if(items.Contains(item))
        {
            itemsType.Remove(item.Type);
            items.Remove(item);
            item.Jete();

            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (!collider.enabled)
            {
                collider.enabled = true;
            }

            ItemJeté?.Invoke(this, new InventoryEventArgs(item));
        }
    }
}
