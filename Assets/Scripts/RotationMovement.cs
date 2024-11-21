using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : IMovementStrategy
{
    public void Move(Transform transform, Vector3 direction, float speed)
    {
        if (direction.magnitude >= 0.1f)
        {
            //C�lculos para rotar al soldado hacia la direcci�n de movimiento.
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);

            //Suavizar la rotaci�n para evitar giros demasiado r�pidos.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
