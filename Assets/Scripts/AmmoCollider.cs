using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("AYUDA: Presiona la tecla E para recoger munición para tu arma.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("AYUDA: Te has alejado de la caja de municiones. ¡Suerte en tu misión!");
        }
    }
}
