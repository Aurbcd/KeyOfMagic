using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarresInventaire : MonoBehaviour
{
    public InventaireScript inventaire;
    // Start is called before the first frame update
    void Start()
    {
        inventaire.ItemAjouté += InventoryScript_ObjetAjoute;
        inventaire.ItemJeté += InventoryScript_ObjetJeté;
    }


    private void InventoryScript_ObjetAjoute(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("AffInventaire");
        Image image = inventoryPanel.GetChild(e.Item.Type).GetChild(0).GetChild(0).GetComponent<Image>();
        image.enabled = true;
        Image fond = inventoryPanel.GetChild(e.Item.Type).GetComponent<Image>();
        image.sprite = e.Item.Image;
        if (e.Item.rarete == 0)
        {
            fond.color = new Color32(255, 255, 255, 150);
        }
        if (e.Item.rarete == 1)
        {
            fond.color = new Color32(19, 114, 113, 255);
        }

        if (e.Item.rarete == 2)
        {
            fond.color = new Color32(152, 20, 52, 255);
        }

        if (e.Item.rarete == 3)
        {
            fond.color = new Color32(155, 119, 0, 255);
        }
    }

private void InventoryScript_ObjetJeté(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("AffInventaire");
        Image fond = inventoryPanel.GetChild(e.Item.Type).GetComponent<Image>();
        fond.color = new Color32(0, 0, 0, 255);
        Image image = inventoryPanel.GetChild(e.Item.Type).GetChild(0).GetChild(0).GetComponent<Image>();
        image.enabled = false;
    }
}
