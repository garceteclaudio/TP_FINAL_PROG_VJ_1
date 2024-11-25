using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;

    private CharacterController controller;
    private Animator animator;
    private Vector3 moveDirection;

    private IMovementStrategy walkingStrategy;
    private IMovementStrategy rotationStrategy;
    private JumpCommand jumpCommand;
    private ShootCommand shootCommand;
    public GameObject bulletPrefab;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        walkingStrategy = new WalkingMovement(controller);
        rotationStrategy = new RotationMovement();
        jumpCommand = new JumpCommand(controller);
        shootCommand = new ShootCommand(bulletPrefab, transform, 90);

    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        moveDirection = transform.right * moveX + transform.forward * moveZ;
        animator.SetFloat("Speed", moveDirection.magnitude);

        if (moveDirection.magnitude >= 0.1f)
        {
            //Mover y rotar al soldado en base a las estrategias.
            walkingStrategy.Move(transform, moveDirection, moveSpeed);
            rotationStrategy.Move(transform, moveDirection, rotationSpeed);
        }

        //Ejecutar el comando de salto del soldado.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCommand.Jump();
        }

        jumpCommand.Execute();

        //Manejar el comando de disparo del soldado.
        if (Input.GetMouseButtonDown(0))
        {
            shootCommand.Execute();
        }

        //Ejecutar el comando para recargar balas.
        if (Input.GetKeyDown(KeyCode.R))
        {
            shootCommand.Reload();
        }
    }

    public void SetMovementStrategy(IMovementStrategy newStrategy)
    {
        walkingStrategy = newStrategy;
    }

    public void SetRotationStrategy(IMovementStrategy newStrategy)
    {
        rotationStrategy = newStrategy;
    }

    //Habilitar la recolección de balas al estar cerca de la caja.
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("AmmoBox") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("SOLDADO: -Estas balas me servirán de momento...");
            shootCommand.AddAmmo(30);
        }
    }
}