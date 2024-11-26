using UnityEngine;
using UnityEngine.AI;

public class NavMeshBossController : MonoBehaviour
{
    public Transform objetivo; //Posicion del objetivo del Boss
    private NavMeshAgent agente; //Componente NavMeshAgent para la navegacion del Boss
    private Boss boss; //Referencia al componente Boss
    private bool isDead = false; //Estado para verificar si el Boss esta muerto

    void Start()
    {
        agente = GetComponent<NavMeshAgent>(); //Llama al componente NavMeshAgent del Boss
        boss = GetComponent<Boss>(); //Llama al componente Boss del Boss
    }

    void Update()
    {
        if (isDead) // Verificar si el Boss esta muerto
        {
            agente.isStopped = true; //Detiene al agente
            agente.velocity = Vector3.zero; //Establecer la velocidad del agente a cero
            agente.destination = transform.position; //Mantiene al agente en su posicion actual
            return; //Sale del metodo Update
        }

        if (objetivo != null && agente != null) //Verificar si el objetivo y el agente no son nulos
        {
            agente.destination = objetivo.position; //Establecer la posicion del objetivo como destino del agente
        }
    }
    public void RecibirImpacto() //Metodo de llama cuando el Boss recibe un impacto
    {
        if (boss != null) //Verificar si Boss existe en la escena
        {
            boss.RecibirImpacto(true); //Llamar al metodo RecibirImpacto del Boss
            if (boss.GetComponent<Boss>().impactosRecibidos >= boss.maxImpactos) //Verificar si el Boss recibio los impactos para ser destruido
            {
                isDead = true;
                Debug.Log("El Boss ha muerto.");
            }
        }
    }
}


