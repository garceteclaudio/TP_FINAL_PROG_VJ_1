using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSoldado : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;

    private CharacterController controller;
    private Animator animator;
    private Vector3 moveDirection;

    private IMovementStrategy walkingStrategy;
    private IMovementStrategy rotationStrategy;
    private ComSaltar jumpCommand;
    private ComDisparar shootCommand;
    public GameObject bulletPrefab;

    public AudioClip shotSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        walkingStrategy = new MovCaminar(controller);
        rotationStrategy = new MovRotar();
        jumpCommand = new ComSaltar(controller);
        shootCommand = new ComDisparar(bulletPrefab, transform, audioSource, shotSound);
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
    }

    public void SetMovementStrategy(IMovementStrategy newStrategy)
    {
        walkingStrategy = newStrategy;
    }

    public void SetRotationStrategy(IMovementStrategy newStrategy)
    {
        rotationStrategy = newStrategy;
    }
}