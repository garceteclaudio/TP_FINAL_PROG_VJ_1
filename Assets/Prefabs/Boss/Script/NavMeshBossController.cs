using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBossController : MonoBehaviour
{
    public Transform objetivo; // El objetivo que el agente seguirá
    private NavMeshAgent agente; // El componente NavMeshAgent

    void Start()
    {
        agente = GetComponent<NavMeshAgent>(); // Obtén el componente NavMeshAgent

        // Verificar que el componente NavMeshAgent existe
        if (agente == null)
        {
            Debug.LogError("No se encontró el componente NavMeshAgent en el objeto");
        }
    }

    void Update()
    {
        if (objetivo != null && agente != null) // Verificar que el objetivo y el agente no sean nulos
        {
            agente.destination = objetivo.position;
        }
    }
}

