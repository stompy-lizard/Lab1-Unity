using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // choose mouse sensitivity
    public float mouseXSensitivity = 1000f;
    public float mouseYSensitivity = 1000f;

    // player
    public Transform playerBody;

    // x axis rotation.
    public float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // lock mouse(canecl with esc key)
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // lateral-vertical movement
        float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseYSensitivity * Time.deltaTime;

        // rotate player on mouse y movement
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate player horizontally
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
