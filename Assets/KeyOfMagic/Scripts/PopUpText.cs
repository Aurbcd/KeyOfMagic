using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    public Animator efficace;
    
    // Start is called before the first frame update
    void Start()
    {
        AnimatorClipInfo[] clipInfo = efficace.GetCurrentAnimatorClipInfo(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
