using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterRotation : MonoBehaviour
{
    public float rotationSpeed = 500f;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}