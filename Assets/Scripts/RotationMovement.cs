using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : IMovementStrategy
{
    public void Move(Transform transform, Vector3 direction, float speed)
    {
        if (direction.magnitude >= 0.1f)
        {
            //Cálculos para rotar al soldado hacia la dirección de movimiento.
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);

            //Suavizar la rotación para evitar giros demasiado rápidos.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
