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

    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {



            Vector3 newPos = PlayerTransform.position + _cameraOffset;

            transform.position = Vector3.Lerp(transform.position, newPos, SmoothFactor);
        if (Input.GetMouseButton(1))
        {
            if (RotateAroundPlayer)
            {
                Quaternion camTurnAngle =
                    Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);
                _cameraOffset = camTurnAngle * _cameraOffset;

            }
            if (LookAtPlayer || RotateAroundPlayer)
            {
                transform.LookAt(PlayerTransform);
            }
        }
    }
}
