using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ChangeDiff : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public GameObject difficulte;
    public Button button;
    public void changeDiff(){
        float currdiff = difficulte.GetComponent<Difficulte>().difficulte;
        if (currdiff == 0.5f)
        {
            tmp.text = "<u>Difficulté : Facile</u>";
            button.GetComponent<OnHover>().textancien = "Difficulté : Facile";
            difficulte.GetComponent<Difficulte>().difficulte = 2.5f;
        }
        if (currdiff == 1.5f)
        {
            tmp.text = "<u>Difficulté : Difficile</u>";
            button.GetComponent<OnHover>().textancien = "Difficulté : Difficile";
            difficulte.GetComponent<Difficulte>().difficulte = 0.5f;
        }
        if (currdiff == 2.5f)
        {
            tmp.text = "<u>Difficulté : Normale</u>";
            button.GetComponent<OnHover>().textancien = "Difficulté : Normale";
            difficulte.GetComponent<Difficulte>().difficulte = 1.5f;
        }
    }

}
