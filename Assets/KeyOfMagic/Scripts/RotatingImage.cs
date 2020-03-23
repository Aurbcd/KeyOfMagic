using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingImage : MonoBehaviour
{

    // Update is called once per frame
    void LateUpdate()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);        
    }
}
