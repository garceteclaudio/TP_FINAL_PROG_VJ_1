using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand
{
    private CharacterController controller;
    private float jumpHeight = 1.5f;
    private float gravity = -20f;
    private float verticalVelocity;

    public JumpCommand(CharacterController controller)
    {
        this.controller = controller;
    }

    public void Execute()
    {
        //Aplicar gravedad y mover al soldado verticalmente.
        verticalVelocity += gravity * Time.deltaTime;

        Vector3 jumpMove = new Vector3(0, verticalVelocity, 0);
        controller.Move(jumpMove * Time.deltaTime);
    }

    public void Jump()
    {
        //Calcular el salto si el soldado está en el suelo.
        if (controller.isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
