using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingWithMouseViaCamera : MonoBehaviour
{
    [SerializeField] private string MouseInputNameX, MouseInputNameY;
    [SerializeField] private float MouseSensitivity;

    [SerializeField] private Transform PlayerBody;

    private float xAxisStop;

    private void Update()
    {
        CameraRotate();
    }

    private void CursorLock() //self explanatory
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake()
    {
        CursorLock();
    }

    private void CameraRotate() //Camera movement
    {
        float MouseX = Input.GetAxisRaw(MouseInputNameX) * MouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxisRaw(MouseInputNameY) * MouseSensitivity * Time.deltaTime;

        xAxisStop += MouseY;

        if (xAxisStop > 90)
        {
            xAxisStop = 90.0f;
            MouseY = 0.0f;
            ClampXAxisRotationValue(270.0f);
        }

        else if (xAxisStop < -90)
        {
            xAxisStop = -90.0f;
            MouseY = 0.0f;
            ClampXAxisRotationValue(90.0f);
        }

        transform.Rotate(Vector3.left * MouseY);
        PlayerBody.Rotate(Vector3.up * MouseX);
    }

    private void ClampXAxisRotationValue(float ClampRotationValue) //stops the camera from having free 360 degree access
    {
        Vector3 EulerRotationAngle = transform.eulerAngles;
        EulerRotationAngle.x = ClampRotationValue;
        transform.eulerAngles = EulerRotationAngle;
    }
}
