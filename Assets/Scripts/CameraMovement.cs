using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(5, -1, 2);

    void LateUpdate()
    {
        //Calcular la posici�n de la c�mara para ubicarla detr�s del jugador.
        Vector3 rotatedOffset = target.rotation * offset;
        Vector3 desiredPosition = target.position + rotatedOffset;

        //Suavizar el movimiento de rotaci�n de la c�mara hacia la posici�n deseada.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.125f);
        transform.position = smoothedPosition;

        //Asegurarse de que la c�mara mire siempre hacia la espalda del soldado.
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}