using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int maxImpactos; //Impactos maximos que puede recibir el Boss
    public Animator animator; //Componente para realizar las animaciones del Boss
    public float tiempoDestruccion; //Tiempo de espera en el que se destruye el GameObject del Boss
    public int impactosRecibidos; //Cantidad de impactos en el que se destruye al Boos

    void Start()
    {
        Transform bossTransform = this.transform; //Otiene la posicion del Boss
        animator = GetComponent<Animator>(); //Llama al componente de animacion
    }

    public void RecibirImpacto(bool isShot) //Metodo para verificar y registrar los impactos
    {
        impactosRecibidos++; //Incrementa el contador por cada impacto
        Debug.Log("Impactos recibidos por el Boss: " + impactosRecibidos);

        if (impactosRecibidos >= maxImpactos) // Verificar si se alcanzo el numero de impactos maximos
        {
            animator.SetTrigger("isDead"); //Activa la animacion de muerte
            StartCoroutine(DestruirDespuesDeTiempo(tiempoDestruccion)); //Inicia la corrutina de destruir despues de tiempo
        }
    }

    IEnumerator DestruirDespuesDeTiempo(float tiempo) //Corrutina que espera un tiempo determinado para destruir el GameObject
    {
        yield return new WaitForSeconds(tiempo); //Espera unos segundos antes de destruirlo
        Debug.Log("Derrotamos al Boss.");
        Destroy(gameObject); //Despues de que pasa el tiempo destruye al Boss de la escena
        SceneManager.LoadScene("Victoria"); //Se cambia a la escena de victoria cuando el Boss ya no existe en la escena
    }
}




