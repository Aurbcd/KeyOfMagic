using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShieldBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Text shieldValue;
    public void  SetNewShield(int shield, string element){ // /!\ Cela ne met pas à jour la valeur du bouclier, juste sa valeur maximale
        slider.maxValue =  shield;
        if (string.Compare(element,"Eau") == 0)
        {
            fill.color = new Color32(28, 33, 238, 255);
        }
        if (string.Compare(element, "Feu") == 0)
        {
            fill.color = new Color32(243, 64, 18, 255);
        }
        if (string.Compare(element, "Terre") == 0)
        {
            fill.color = new Color32(78, 52, 46, 255);
        }
        if (string.Compare(element, "Air") == 0)
        {
            fill.color = new Color32(75, 4, 88, 255);
        }
        if (string.Compare(element, "Electricite") == 0)
        {
            fill.color = new Color32(255, 234, 0, 255);
        }

         shieldValue.text = shield.ToString() + " / " + shield.ToString();
    }
    public void SetShield(int shield) {
        slider.value = shield;
        shieldValue.text = slider.value.ToString() + " / " + slider.maxValue.ToString();
    }

}
