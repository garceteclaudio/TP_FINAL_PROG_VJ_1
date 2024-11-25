using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public float rangoAtaque = 3f; // Añadir rango de ataque
    public float gravedad = -9.81f;
    public Animator animator; // Añadir el componente Animator

    private NavMeshAgent agente;
    private Transform player;
    private Coroutine attackCoroutine; // Referencia a la corrutina de ataque

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>(); // Obtener el componente Animator
    }

    void Update()
    {
        if (agente.isOnNavMesh && player != null)
        {
            agente.destination = player.position;
            animator.SetBool("isWalking", true); // Activar la animación de caminar

            // Aplicar gravedad para evitar que los enemigos floten
            agente.Move(Vector3.down * gravedad * Time.deltaTime);

            // Hacer que el prefab del enemigo mire siempre en dirección al soldado
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

            // Verificar la distancia al jugador para iniciar ataque
            float distanciaAlPlayer = Vector3.Distance(transform.position, player.position);
            //Debug.Log($"Distancia al jugador: {distanciaAlPlayer} (Rango de ataque: {rangoAtaque})");

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
                    animator.SetBool("isAttacking", false); // Desactivar la animación de ataque
                    Debug.Log("isAttacking desactivado");
                    animator.SetBool("isWalking", true); // Mantener la animación de caminar
                }
            }
        }
        else
        {
            Debug.LogWarning("El NavMeshAgent no está en el NavMesh o el jugador no está disponible.");
        }
    }

    IEnumerator AttackPlayer()
    {
        while (true)
        {
            animator.SetBool("isAttacking", true); // Activar la animación de ataque
            Debug.Log("isAttacking activado");
            yield return new WaitForSeconds(1f); // Espera entre ataques
        }
    }
}






