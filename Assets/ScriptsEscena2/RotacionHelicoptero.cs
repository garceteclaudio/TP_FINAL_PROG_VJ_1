using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionHelicoptero : MonoBehaviour
{
    public float rotationSpeed = 500f; // Velocidad de rotación (grados por segundo)

    void Update()
    {
        // Rotar las hélices en el eje Y (o cambia el eje según tu modelo)
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}