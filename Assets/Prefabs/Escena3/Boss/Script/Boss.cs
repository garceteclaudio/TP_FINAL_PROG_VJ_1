using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxImpactos = 10; // M�ximo de impactos antes de morir
    private int impactosRecibidos = 0; // Contador de impactos recibidos
    public Animator animator; // Componente Animator
    public float tiempoDestruccion = 3f; // Tiempo antes de destruir el objeto despu�s de la animaci�n de muerte

    void Start()
    {
       
        // Verificar y configurar la posici�n inicial del Boss
        Transform bossTransform = this.transform;
        Debug.Log("Posici�n inicial del Boss: " + bossTransform.position);

        // Aseg�rate de que la posici�n inicial es correcta
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
            animator.SetTrigger("isDead"); // Activar la animaci�n de muerte
            Debug.Log("isDead activado en el Animator.");
            StartCoroutine(DestruirDespuesDeTiempo(tiempoDestruccion)); // Iniciar corrutina para destruir despu�s de la animaci�n
        }
    }

    IEnumerator DestruirDespuesDeTiempo(float tiempo)
    {
        Debug.Log("Iniciando corrutina para destruir el Boss despu�s de " + tiempo + " segundos.");
        yield return new WaitForSeconds(tiempo); // Esperar el tiempo especificado
        Debug.Log("Derrotamos al Boss.");
        Destroy(gameObject); // Destruir el objeto
    }
}

