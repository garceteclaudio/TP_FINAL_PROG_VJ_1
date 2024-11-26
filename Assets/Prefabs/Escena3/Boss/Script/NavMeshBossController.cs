using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBossController : MonoBehaviour
{
    public Transform objetivo;
    private NavMeshAgent agente;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        if (objetivo != null && agente != null)
        {
            agente.destination = objetivo.position;
        }
    }
}

