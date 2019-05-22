using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingWithMouseViaCamera : MonoBehaviour
{
    float SpeedHor, SpeedVer, Distance;
    float Check1, Check2;

    void Start()
    {
        SpeedHor = 2.0f;
        SpeedVer = 2.0f;
        Check1 = 0.0f;
        Check2 = 0.0f;
        Distance = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
       Check1 += SpeedHor * Input.GetAxisRaw("Mouse X");
       Check2 -= SpeedVer * Input.GetAxisRaw("Mouse Y");
       transform.eulerAngles = new Vector3(Check2, Check1, 0.0f);
       Cursor.lockState = CursorLockMode.Locked;
       transform.position = transform.position + Camera.main.transform.forward * Distance * Time.deltaTime;// doesn't do anything and probably will delete
    }
}
