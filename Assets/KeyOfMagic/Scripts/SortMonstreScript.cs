using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortMonstreScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(ClickToMove.playerPosition + new Vector3(0f, 0.8f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
