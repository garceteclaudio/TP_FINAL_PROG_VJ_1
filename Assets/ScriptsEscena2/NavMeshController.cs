using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class NavMeshController : MonoBehaviour
{
    public Transform objetivo; // Corregido: "Transform" estaba mal escrito
    private NavMeshAgent agente; // Corregido: "NavMeshAgent" estaba mal escrito

    void Start()
    {
        agente = GetComponent<NavMeshAgent>(); // Corregido: el componente NavMeshAgent
    }

    void Update()
    {
        if (objetivo != null) // Verificar que el objetivo no sea nulo
        {
            agente.destination = objetivo.position;
        }
    }
}
