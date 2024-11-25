using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 3, -3);
    public float mouseSensitivity = 400f;
    private float xRotation;
    private float yRotation;
    public Transform orientation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (target != null)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + orientation.TransformDirection(offset);
        }

        if (target == null)
        {
            Debug.LogError("Target no está asignado. Asegúrate de que la referencia está configurada en el Inspector.");
        }
        if (orientation == null)
        {
            Debug.LogError("Orientation no está asignado. Asegúrate de que la referencia está configurada en el Inspector.");
        }
    }
}
