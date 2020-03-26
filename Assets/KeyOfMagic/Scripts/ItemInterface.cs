using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ItemInterface{

    string Nom { get; }
    int Type { get; }
    Sprite Image { get; }

    int rarete { get;  }
    void Ramasse();

    void Jete();
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(ItemInterface item)
    {
        Item = item;
    }

    public ItemInterface Item;
}