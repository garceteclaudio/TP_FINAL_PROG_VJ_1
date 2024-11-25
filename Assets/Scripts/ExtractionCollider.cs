using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractionCollider : MonoBehaviour
{
    public EndingManager endingManager;
    private bool hasEntered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soldier") && !hasEntered)
        {
            hasEntered = true;
            Debug.Log("SOLDADO: -Aquí parece ser el punto de extracción...");

            if (endingManager.object1.activeSelf && endingManager.object2.activeSelf)
            {
                Time.timeScale = 0f;
                Debug.Log("CONDUCTOR: (por radio) -Pájaro grande, aquí Bravo Seis, estamos saliendo.");
                Debug.Log("CONDUCTOR: (al soldado) -¡Rápido soldado! ¡NOS LARGAMOS!");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Soldier"))
        {
            hasEntered = false; // Permitir que se ejecute de nuevo al salir
            Debug.Log("SOLDADO: -Creo que será mejor liberar la zona...");
        }
    }
}