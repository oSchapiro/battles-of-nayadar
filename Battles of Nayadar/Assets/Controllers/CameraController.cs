using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform cameraTarget;

    private float thirdPersonFactorMax;
    private float thirdPersonFactorMin;
    private float thirdPersonFactor;
    private float mouseSensitivity = 6f;
    private float yaw = 0f;
    private float pitch = 0f;
    private float xin, yin;

    void Start()
    {
        thirdPersonFactorMax = 2.75f;
        thirdPersonFactorMin = thirdPersonFactorMax * 0.75f;
        thirdPersonFactor = thirdPersonFactorMax;
}

    void Update()
    {
        xin = Input.GetAxis("Mouse X");
        yin = Input.GetAxis("Mouse Y");
        yaw += xin * mouseSensitivity;
        pitch -= yin * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0);

        if (Input.GetMouseButton(1))
        {
            thirdPersonFactor = Mathf.Lerp(thirdPersonFactor, thirdPersonFactorMin, 0.1f);
        }
        else
        {
            thirdPersonFactor = Mathf.Lerp(thirdPersonFactor, thirdPersonFactorMax, 0.1f);
        }

        transform.position = Vector3.Lerp(transform.position, cameraTarget.position - transform.forward * thirdPersonFactor, 0.95f);
    }

}