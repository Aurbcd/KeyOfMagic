using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayStatCard : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public TextMeshProUGUI titre;
    public TextMeshProUGUI description;
    private int rarete;
    private bool isDisplayed;
    private float fadeSpeed = 5f;
    void Start()
    {
        canvasGroup.alpha = 0f;
        rarete = this.GetComponent<ItemInterface>().rarete;
    }

    void Update()
    {
        if(isDisplayed)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1f, fadeSpeed * Time.deltaTime);
            Debug.Log(rarete);
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
