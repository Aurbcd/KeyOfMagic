using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class OnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 

{
    public string textancien;
    public Animator animator;

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Souligne le texte du TMP du bouton
        string text = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        textancien = text;
        text = "<u>" + text + "</u>";
        this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        if (animator != null )
        {
            animator.SetBool("play",true);
        }
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Dé-souligne le texte du TMP
        this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = textancien;
        if (animator != null)
        {
            animator.SetBool("play", false);
        }
    }

}
