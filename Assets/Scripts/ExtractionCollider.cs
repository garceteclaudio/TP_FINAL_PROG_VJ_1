using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtractionCollider : MonoBehaviour
{
    public EndingManager endingManager;
    private bool hasEntered = false;
    public string sceneBossFight;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soldier") && !hasEntered)
        {
            hasEntered = true;
            Debug.Log("SOLDADO: -Aquí parece ser el punto de extracción...");

            if (endingManager.object1.activeSelf && endingManager.object2.activeSelf)
            {
                Debug.Log("CONDUCTOR: (por radio) -Pájaro grande, aquí Bravo Seis, estamos saliendo.");
                Debug.Log("CONDUCTOR: (al soldado) -¡Rápido soldado! ¡NOS LARGAMOS!");
                SceneManager.LoadScene(sceneBossFight);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Soldier"))
        {
            hasEntered = false;
            Debug.Log("SOLDADO: -Creo que será mejor liberar la zona...");
        }
    }
}