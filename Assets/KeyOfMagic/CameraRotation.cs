using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public Transform PlayerTransform;
    private Vector3 _cameraOffset;
    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    public bool LookAtPlayer = false;
    public bool RotateAroundPlayer = true;
    public float RotationsSpeed = 5.0f;
    public float fieldOfView = 60f;

    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 newPos = PlayerTransform.position + _cameraOffset;
        Debug.Log(Vector3.Angle(_cameraOffset, new Vector3 (0,1,0)));
        Debug.Log(Input.GetAxis("Mouse X"));
        Debug.Log(Vector3.Angle(_cameraOffset, new Vector3(0, 1, 0)) > 10 && Input.GetAxis("Mouse Y") > 0);

        transform.position = Vector3.Lerp(transform.position, newPos, SmoothFactor);
        if (Input.GetMouseButton(1))
        {
            //if (Vector3.Angle(_cameraOffset, new Vector3(0, 1, 0)) > 10 || Input.GetAxis("Mouse Y")<0 )
            //{
                if (RotateAroundPlayer)
                {
                    Quaternion camTurnAngleY =
                        Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);

                    Quaternion camTurnAngleX =
                        Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationsSpeed, Vector3.left);

                    _cameraOffset = camTurnAngleX * _cameraOffset;

                }
            //}
        }
        if (LookAtPlayer || RotateAroundPlayer)
            {
                transform.LookAt(PlayerTransform);
            }
        
        // Pour zoom : Input.mouseScrollDelta.y * 5f;

    }
}
