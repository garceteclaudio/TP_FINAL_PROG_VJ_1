using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoContinuo : MonoBehaviour
{
    public float CantidadDaño = 10f; //Cantidad de daño que se hará
    public float intervaloDaño = 1f; //Intervalo de tiempo entre cada daño

    private Coroutine damageCoroutine; //Corrutina de daño

    private void OnTriggerEnter(Collider other) //Metodo que llama a otro collider cuando entra en el trigger
    {
        if (other.CompareTag("Player") && other.GetComponent<SaludPlayer>()) //Verifica que el objeto Player tenga un componente SaludPlayyer
        {
            if (damageCoroutine == null) //Inicia la corrutina si no está activa
            {
                damageCoroutine = StartCoroutine(ApplyContinuousDamage(other.GetComponent<SaludPlayer>()));
            }
        }
    }

    private void OnTriggerExit(Collider other) //Metodo que llama a otro collider cuando sale del trigger
    {
        if (other.CompareTag("Player") && damageCoroutine != null) //Verifica si Player sale del trigger y si la corrutina está activada
        {
            StopCoroutine(damageCoroutine); //Detiene la corrutina
            damageCoroutine = null; //Reinicia la referencia de la corrutina
        }
    }

    IEnumerator ApplyContinuousDamage(SaludPlayer playerSalud) //Corrutina que hace daño continuo al jugador
    {
        while (true) // Bucle donde se aplica el daño
        {
            playerSalud.RecibirDaño(CantidadDaño); //Aplica el daño
            yield return new WaitForSeconds(intervaloDaño); //Intervalo de tiempo entre cada daño
        }
    }
}

