using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public float gravity = -9.81f;
    private CharacterController controller;
    private Vector3 verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Asignar como objetivo a un objeto que tenga la etiqueta "Player".
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;

            //Mover al enemigo en dirección hacia el soldado.
            Vector3 move = direction * speed * Time.deltaTime;
            controller.Move(move);

            //Aplicarle gravedad a los enemigos para que no floten por el mapa.
            if (controller.isGrounded)
            {
                verticalVelocity.y = 0;
            }
            else
            {
                verticalVelocity.y += gravity * Time.deltaTime;
            }

            controller.Move(verticalVelocity * Time.deltaTime);

            //Hacer que el prefab del enemigo mire siempre en dirección al soldado.
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
