using UnityEngine;
using System.Collections;

public class CameraRotationFixed : MonoBehaviour
{

    public float turnSpeedX = 7.0f;
    public float turnSpeedY = 5.0f;

    public bool touch;
    public Transform player;
    public Vector3 offset;
    private Vector3 vectorRotation;
    private Vector3 playerHeadPosition;

    void Start()
    {
        offset = new Vector3(10, 5, 0);
        playerHeadPosition = new Vector3(player.position.x, player.position.y + 2, player.position.z);
    }

    void LateUpdate()
    {
        vectorRotation = player.position - gameObject.GetComponent<Transform>().position;
        if (Input.GetMouseButton(1))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeedX, Vector3.up) * offset;
            if ((Input.GetAxis("Mouse Y") < 0 && Vector3.Angle(Vector3.up, vectorRotation) < 140) || (Input.GetAxis("Mouse Y") > 0 && Vector3.Angle(Vector3.up, vectorRotation) > 100))
            {
                offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeedY, Vector3.Cross(vectorRotation, Vector3.up)) * offset;
            }
        }
        playerHeadPosition = new Vector3(player.position.x, player.position.y +2, player.position.z);

        if ((offset.magnitude > 6 && Input.mouseScrollDelta.y >= 0) || (Input.mouseScrollDelta.y <= 0 && offset.magnitude < 15))
        {
            offset *= 1 - Input.mouseScrollDelta.y * 0.1f;
        }

        transform.position = player.position + offset;
        transform.LookAt(playerHeadPosition);
    }

    void OnTriggerStay(Collider col)
    {
        if ((transform.position - player.position).magnitude > 3)
        {
            offset *= 1 - 0.1f;
            transform.position = player.position + offset;
            transform.LookAt(playerHeadPosition);
        }
    }
}
