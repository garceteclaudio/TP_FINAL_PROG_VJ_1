using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionHelicoptero : MonoBehaviour
{
    public float rotationSpeed = 500f; // Velocidad de rotaci�n (grados por segundo)

    void Update()
    {
        // Rotar las h�lices en el eje Y (o cambia el eje seg�n tu modelo)
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}