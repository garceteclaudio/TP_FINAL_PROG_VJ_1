using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMovement : IMovementStrategy
{
    private CharacterController controller;

    public WalkingMovement(CharacterController controller)
    {
        //Guardar la referencia controller para habilitar las colisiones con el terreno.
        this.controller = controller; 
    }

    public void Move(Transform transform, Vector3 direction, float speed)
    {
        Vector3 movement = direction * speed * Time.deltaTime;

        //Llamar el método move del contoller para manejar las colisiones con el terreno.
        controller.Move(movement);
    }
}
