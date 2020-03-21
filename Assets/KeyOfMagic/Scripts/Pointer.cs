using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 newPosition = Vector3.zero;
    public int speed = 5;
    public GameObject point;
    public float opacity;
    public GameObject pausePanel;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Sol" && !pausePanel.activeSelf )
                {
                    newPosition = hit.point;
                    newPosition.y = newPosition.y + 0.1f;
                    transform.position = newPosition;
                    opacity = 1.0f;
                }
            }
        }
        if (opacity >= 0)
        {
            opacity = opacity - 0.25f * Time.deltaTime;
        }
        this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, opacity);
    }
}
