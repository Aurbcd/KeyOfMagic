using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 newPosition = Vector3.zero;
    public int speed = 5;
    public GameObject Point;
    public float x;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            x = 1.0f;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
                newPosition.y = newPosition.y + 0.1f; 
                transform.position = newPosition;
            }
        }
        Debug.Log(x);
        x = x - 0.25f * Time.deltaTime;
        this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, x);
    }
}
