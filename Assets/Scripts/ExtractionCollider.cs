using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractionCollider : MonoBehaviour
{
    public EndingManager endingManager;
    private bool hasEntered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasEntered)
        {
            hasEntered = true;
            Debug.Log("SOLDADO: -Aqu� parece ser el punto de extracci�n...");

            if (endingManager.object1.activeSelf && endingManager.object2.activeSelf)
            {
                Time.timeScale = 0f;
                Debug.Log("CONDUCTOR: (por radio) -P�jaro grande, aqu� Bravo Seis, estamos saliendo.");
                Debug.Log("CONDUCTOR: (al soldado) -�De pie soldado! �NOS LARGAMOS!");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasEntered = false; // Permitir que se ejecute de nuevo al salir
            Debug.Log("SOLDADO: -Creo que ser� mejor liberar la zona...");
        }
    }
}