using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    [SerializeField] private Transform player; // El objetivo de la cámara
    private Vector3 offset;
    public float mouseSensitivity = 400f;
    private float xRotation;
    private float yRotation;
    public Transform orientation; // Para mantener la orientación horizontal

    void Start()
    {
        offset = new Vector3(0, 3, -3);
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro
        Cursor.visible = false; // Ocultar el cursor
    }

    void Update()
    {
        // Verificar que el jugador no sea nulo antes de procesar la entrada del mouse
        if (player != null)
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
    }

    private void LateUpdate()
    {
        // Verificar que el jugador no sea nulo antes de posicionar la cámara
        if (player != null)
        {
            // Posicionar la cámara en relación con el jugador usando el offset
            transform.position = player.position + orientation.TransformDirection(offset);
        }
    }
}
