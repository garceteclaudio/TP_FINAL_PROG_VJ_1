using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoContinuo : MonoBehaviour
{
    public float CantidadDaño = 10f;
    public float intervaloDaño = 1f;

    private Coroutine damageCoroutine;

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
            yield return new WaitForSeconds(intervaloDaño);
        }
    }
}

