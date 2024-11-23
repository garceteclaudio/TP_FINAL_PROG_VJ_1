using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset;
    public float mouseSensitivity = 400f;
    private float xRotation;
    private float yRotation;
    public Transform orientation;

    void Start()
    {
        offset = new Vector3(0, 3, -3);
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro
        Cursor.visible = false;
    }

    void Update()
    {
        // Obtener la entrada del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Actualizar las rotaciones
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Aplicar la rotación a la cámara y la orientación
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); // Mantener la orientación horizontal
    }

    private void LateUpdate()
    {
        // Posiciona el objeto en relación con el jugador usando el offset
        transform.position = player.position + orientation.TransformDirection(offset);
    }
}
