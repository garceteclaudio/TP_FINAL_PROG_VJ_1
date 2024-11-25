using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NavMeshController : MonoBehaviour
{
    private NavMeshAgent agente; // Componente NavMeshAgent
    private GameObject player; // Referencia al jugador

    void Start()
    {
        agente = GetComponent<NavMeshAgent>(); //  el componente NavMeshAgent
                                               // Buscar el jugador usando el tag "Player"
        player = GameObject.FindWithTag("Player");

        if (player == null)
        {
            Debug.LogWarning("No se encontró un objeto con el tag 'Player'.");
        }
    }

    void Update()
    {
        if (player != null) // Verificar que el objetivo no sea nulo
        {
            agente.destination = player.transform.position;
        }
    }
    // Método para detectar colisiones
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra al collider tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador detectado. Cambiando a la escena 'Menu'.");
            SceneManager.LoadScene("Menu");
        }
    }
}
