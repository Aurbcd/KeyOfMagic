using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTextController : MonoBehaviour
{
    private static PopUpText popUpText;
    private static GameObject canvas;
    public static void Initialize()
    {
        canvas = GameObject.Find("UICanvas");
        popUpText = Resources.Load<PopUpText>("/PopupTextParent");
    }
    public static void CreateFloatingText(Transform location)
    {
        Debug.Log("coucou");
        PopUpText instance = Instantiate(popUpText);
        instance.transform.SetParent(canvas.transform, false);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
