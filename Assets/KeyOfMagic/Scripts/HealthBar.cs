using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text healthValue;
    public void  SetMaxHealth(int health){
        slider.maxValue =  health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
        healthValue.text = health.ToString() + " / " + health.ToString();
    }
    public void SetHealth(int health) {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        healthValue.text = slider.value.ToString() + " / " + slider.maxValue.ToString();
    }

}
