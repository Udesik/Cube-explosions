using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    [SerializeField] private float _speedX = 2.0f;
    [SerializeField] private float _speedY = 2.0f;

    private float _yaw = 0.0f;
    private float _pitch = 0.0f;

    void Update()
    {
        _yaw += _speedX * Input.GetAxis("Mouse X");
        _pitch -= _speedY * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(_pitch, _yaw, 0.0f);
    }
}
