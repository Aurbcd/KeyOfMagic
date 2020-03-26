using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayStatCard : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    private bool isDisplayed;
    public float fadeSpeed;
    void Start()
    {
        canvasGroup.alpha = 0f;
    }

    void Update()
    {
        if(isDisplayed)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1f, fadeSpeed * Time.deltaTime);
        }
        else
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 0f, fadeSpeed * Time.deltaTime);
        }
    }

    void OnMouseOver()
    {
        isDisplayed = true;
    }

    void OnMouseExit()
    {
        isDisplayed = false;
    }
    

}
