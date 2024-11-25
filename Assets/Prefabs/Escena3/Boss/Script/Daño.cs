using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoContinuo : MonoBehaviour
{
    public float CantidadDaño = 10f; // Cantidad de daño que el Boss inflige
    public float intervaloDaño = 1f; // Intervalo de tiempo entre cada daño

    private Coroutine damageCoroutine; // Referencia a la corrutina de daño

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<SaludPlayer>())
        {
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(ApplyContinuousDamage(other.GetComponent<SaludPlayer>()));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    IEnumerator ApplyContinuousDamage(SaludPlayer playerSalud)
    {
        while (true)
        {
            playerSalud.RecibirDaño(CantidadDaño);
            Debug.Log("El jugador recibió daño: " + CantidadDaño);
            yield return new WaitForSeconds(intervaloDaño); // Daño cada intervalo especificado
        }
    }
}

/*using UnityEngine;

public class Daño : MonoBehaviour
{
    public float CantidadDaño;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<SaludPlayer>())
        {
            other.GetComponent<SaludPlayer>().RecibirDaño(CantidadDaño);
        }
    }
}*/

