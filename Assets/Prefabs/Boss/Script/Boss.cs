using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxImpactos = 10; // Máximo de impactos antes de morir
    private int impactosRecibidos = 0; // Contador de impactos recibidos
    public Animator animator; // Componente Animator
    public float tiempoDestruccion = 3f; // Tiempo antes de destruir el objeto después de la animación de muerte

    void Start()
    {
       
        // Verificar y configurar la posición inicial del Boss
        Transform bossTransform = this.transform;
        Debug.Log("Posición inicial del Boss: " + bossTransform.position);

        // Asegúrate de que la posición inicial es correcta
        bossTransform.position = new Vector3(bossTransform.position.x, 0f, bossTransform.position.z);

        animator = GetComponent<Animator>(); // Obtener el componente Animator

        if (animator == null)
        {
            Debug.LogError("Animator no encontrado en el Boss.");
        }
    }

    public void RecibirImpacto()
    {
        impactosRecibidos++;
        Debug.Log("Impactos recibidos por el Boss: " + impactosRecibidos);

        if (impactosRecibidos >= maxImpactos)
        {
            Debug.Log("El Boss ha sido derrotado");
            animator.SetTrigger("isDead"); // Activar la animación de muerte
            Debug.Log("isDead activado en el Animator.");
            StartCoroutine(DestruirDespuesDeTiempo(tiempoDestruccion)); // Iniciar corrutina para destruir después de la animación
        }
    }

    IEnumerator DestruirDespuesDeTiempo(float tiempo)
    {
        Debug.Log("Iniciando corrutina para destruir el Boss después de " + tiempo + " segundos.");
        yield return new WaitForSeconds(tiempo); // Esperar el tiempo especificado
        Debug.Log("Derrotamos al Boss.");
        Destroy(gameObject); // Destruir el objeto
    }
}

