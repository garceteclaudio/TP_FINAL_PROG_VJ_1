using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public float rangoAtaque = 3f;
    public float gravedad = -9.81f;
    public Animator animator;

    private NavMeshAgent agente;
    private Transform player;
    private Coroutine attackCoroutine;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (agente.isOnNavMesh && player != null)
        {
            agente.destination = player.position;
            animator.SetBool("isWalking", true);

            agente.Move(Vector3.down * gravedad * Time.deltaTime);

            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

            float distanciaAlPlayer = Vector3.Distance(transform.position, player.position);

            if (distanciaAlPlayer <= rangoAtaque)
            {
                if (attackCoroutine == null)
                {
                    attackCoroutine = StartCoroutine(AttackPlayer());
                }
            }
            else
            {
                if (attackCoroutine != null)
                {
                    StopCoroutine(attackCoroutine);
                    attackCoroutine = null;
                    animator.SetBool("isAttacking", false);
                    animator.SetBool("isWalking", true);
                }
            }
        }
    }

    IEnumerator AttackPlayer()
    {
        while (true)
        {
            animator.SetBool("isAttacking", true);
            yield return new WaitForSeconds(1f);
        }
    }
}






