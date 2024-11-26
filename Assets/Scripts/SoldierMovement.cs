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

    public AudioClip shotSound;
    public AudioClip emptySound;
    public AudioClip reloadSound;
    private AudioSource audioSource;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        walkingStrategy = new WalkingMovement(controller);
        rotationStrategy = new RotationMovement();
        jumpCommand = new JumpCommand(controller);
        shootCommand = new ShootCommand(bulletPrefab, transform, 90, audioSource, shotSound, emptySound, reloadSound);

    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        moveDirection = transform.right * moveX + transform.forward * moveZ;
        animator.SetFloat("Speed", moveDirection.magnitude);

        if (moveDirection.magnitude >= 0.1f)
        {

            walkingStrategy.Move(transform, moveDirection, moveSpeed);
            rotationStrategy.Move(transform, moveDirection, rotationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCommand.Jump();
        }

        jumpCommand.Execute();

        if (Input.GetMouseButtonDown(0))
        {
            shootCommand.Execute();
        }

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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("AmmoBox") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("SOLDADO: -Estas balas me servirán de momento...");
            shootCommand.AddAmmo(30);
        }
    }
}