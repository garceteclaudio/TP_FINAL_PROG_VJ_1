using UnityEngine;
using UnityEngine.AI;

public class NavMeshBossController : MonoBehaviour
{
    public Transform objetivo;
    private NavMeshAgent agente;
    private Boss boss;
    private bool isDead = false;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        boss = GetComponent<Boss>();

        if (agente == null)
        {
            Debug.LogError("NavMeshAgent no encontrado.");
        }

        if (boss == null)
        {
            Debug.LogError("Boss no encontrado.");
        }
    }

    void Update()
    {
        if (isDead)
        {
            agente.isStopped = true;
            agente.velocity = Vector3.zero;
            agente.destination = transform.position;
            return;
        }

        if (objetivo != null && agente != null)
        {
            agente.destination = objetivo.position;
        }
    }

    public void RecibirImpacto()
    {
        if (boss != null)
        {
            boss.RecibirImpacto(true);
            if (boss.GetComponent<Boss>().impactosRecibidos >= boss.maxImpactos)
            {
                isDead = true;
                Debug.Log("El Boss ha muerto.");
            }
        }
    }
}

