using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventaireScript : MonoBehaviour
{
    private List<int> itemsType = new List<int>();
    private List<ItemInterface> items = new List<ItemInterface>();
    public event EventHandler<InventoryEventArgs> ItemAjouté;
    public event EventHandler<InventoryEventArgs> ItemJeté;

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
