using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ChangeDiff : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public Button button;
    private void Start()
    {
        PlayerStats.Difficulte = 1.5f;
    }

    public void changeDiff(){
        float currdiff = PlayerStats.Difficulte;
        if (currdiff == 1.5f)
        {
            tmp.text = "<u>Difficulté : Facile</u>";
            button.GetComponent<OnHover>().textancien = "Difficulté : Facile";
            PlayerStats.Difficulte = 0.5f;
        }
        if (currdiff == 1f)
        {
            tmp.text = "<u>Difficulté : Difficile</u>";
            button.GetComponent<OnHover>().textancien = "Difficulté : Difficile";
            PlayerStats.Difficulte = 1.5f;
        }
        if (currdiff == 0.5f)
        {
            tmp.text = "<u>Difficulté : Normale</u>";
            button.GetComponent<OnHover>().textancien = "Difficulté : Normale";
            PlayerStats.Difficulte = 1f;
        }
    }

}
