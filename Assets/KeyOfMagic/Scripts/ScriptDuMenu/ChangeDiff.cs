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
        PlayerStats.Difficulte = 1f;
    }

    public void changeDiff(){
        float currdiff = PlayerStats.Difficulte;
        if (currdiff == 1.5f)
        {
            tmp.text = "<u>Difficulty : Easy</u>";
            button.GetComponent<OnHover>().textancien = "Difficulty : Easy";
            PlayerStats.Difficulte = 0.5f;
        }
        if (currdiff == 1f)
        {
            tmp.text = "<u>Difficulty : Hard</u>";
            button.GetComponent<OnHover>().textancien = "Difficulty : Hard";
            PlayerStats.Difficulte = 1.5f;
        }
        if (currdiff == 0.5f)
        {
            tmp.text = "<u>Difficulty : Normal</u>";
            button.GetComponent<OnHover>().textancien = "Difficulty : Normal";
            PlayerStats.Difficulte = 1f;
        }
    }

}
