using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShieldBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public void  SetNewShield(int shield, string element){ // /!\ Cela ne met pas à jour la valeur du bouclier, juste sa valeur maximale
        slider.maxValue =  shield;
        if (string.Compare(element,"Eau") == 0)
        {
            fill.color = new Color32(0,0,102,100);
        }
    }
    public void SetShield(int shield) {
        slider.value = shield;
    }

}
