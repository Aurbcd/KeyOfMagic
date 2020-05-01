using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventaireDisplayCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{
    public CanvasGroup cardCanvasGroup;

    void Start()
    {
        cardCanvasGroup.alpha = 0f;
    }

    private int getIndice(string type){
        switch (type)
        {
            case "Chapeau":
                return 0;
            case "Robe":
                return 1;
            case "Baton":
                return 2;
            case "Anneau":
                return 3;
            case "Chaussures":
                return 4;
            default:
                return -1;
        }
    }

    private Color32 getColor(int rareté){
        switch(rareté)
        {
            case 0:
                return new Color32(255, 255, 255, 150);
            case 1:
                return new Color32(19, 114, 113, 255);
            case 2:
                return new Color32(152, 20, 52, 255);
            case 4:
                return new Color32(155, 119, 0, 255);
            default:
                return new Color32(255,255,255,0);
        }
    }
    public void OnPointerEnter(PointerEventData pointerEventData) //Va loader les trucs quand le curseur passe
    {
        var type = this.name.Substring(4,this.name.Length - 4); //Type du slot d'inventaire
        var indice = getIndice(type); //Converti le nom du slot en "Type" de l'ItemInterface

        foreach (ItemInterface item in InventaireScript.items)
        {
            if (item.Type.Equals(indice))
            {
                cardCanvasGroup.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.Nom; 
                cardCanvasGroup.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.description;
                cardCanvasGroup.transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = item.lore;
                cardCanvasGroup.transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().sprite = item.Image;
                cardCanvasGroup.transform.GetChild(0).transform.GetChild(3).GetComponent<Image>().color = getColor(item.rarete);
                cardCanvasGroup.transform.GetChild(1).GetComponent<Image>().color = getColor(item.rarete);
                cardCanvasGroup.alpha = 1f;
            }
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        cardCanvasGroup.alpha = 0f;
    }

}
