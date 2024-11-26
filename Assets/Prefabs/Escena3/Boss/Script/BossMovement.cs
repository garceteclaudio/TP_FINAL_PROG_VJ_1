using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    public float speed = 0.5f; //Velocidad de movimiento del Boss
    public float rangoAtaque = 3f; //Rango de ataque
    public float gravedad = -9.81f; //Gravedad para el Boss
    public Animator animator; //Componente animator para las animaciones

    private NavMeshAgent agente; //NavMeshAgent para que el Boss se desplace por el mapa
    private Transform player; //Posicion del Jugador
    private Coroutine attackCoroutine; //Corrutina para controlar el ataque

    void Start()
    {
        agente = GetComponent<NavMeshAgent>(); //Llama al componente de NavMeshAgent
        player = GameObject.FindWithTag("Player").transform; //Busca la posion del jugador mediante su tag 
        animator = GetComponent<Animator>(); //Lllama al componente animator para la animacion
    }

    void Update()
    {
        if (agente.isOnNavMesh && player != null) //Verifica que el agente esté en la maya de navegacion y si existe el jugador
        {
            agente.destination = player.position; //Establece la posicion del jugador hacia donde se dirigirá el Boss
            animator.SetBool("isWalking", true); //Activa la animacion del Boss donde está caminando

            agente.Move(Vector3.down * gravedad * Time.deltaTime); //Aplica la gravedad

            Vector3 direction = (player.position - transform.position).normalized; //Calcula la direccion hacia el jugador
            Quaternion targetRotation = Quaternion.LookRotation(direction); //Clcula la rotacion hacia el jugador
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); //Suaviza la rotacion

            float distanciaAlPlayer = Vector3.Distance(transform.position, player.position); //Calcula la distancia al jugador

            if (distanciaAlPlayer <= rangoAtaque) //Verifica que el jugador este en el rango de ataque
            {
                if (attackCoroutine == null) //Inicia la corrutina si no está activa
                {
                    attackCoroutine = StartCoroutine(AttackPlayer());
                }
            }
            else //Detiene la corrutina si el jugador no esta en el rango de ataque
            {
                if (attackCoroutine != null)
                {
                    StopCoroutine(attackCoroutine);
                    attackCoroutine = null;
                    animator.SetBool("isAttacking", false); //Desactiva la animacion de atacar
                    animator.SetBool("isWalking", true); //Vuelve a activar la animacion de caminar
                }
            }
        }
    }

    IEnumerator AttackPlayer() //Corrutina de ataque al jugador
    {
        while (true) //Bucle para atacar constantemente
        {
            animator.SetBool("isAttacking", true); //Activa la animacion de ataque
            yield return new WaitForSeconds(1f); //Intervalo de 1 segundo entre ataque
        }
    }
}






