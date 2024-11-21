using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCollider : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Comprobar si el objeto con el que colisiona el soldado tiene la etiqueta "Enemy".
        if (hit.gameObject.CompareTag("Enemy"))
        {
            //En caso de colisionar con un "Enemy" pausar el juego y mostrar el mensaje de derrota.
            Time.timeScale = 0f;

            Debug.Log("SOLDADO: (por radio) -�Aqu� Sombra Nueve a Bravo Seis, me superan en n�mero! �Abandonen la zona de inmediato! ");
            Debug.Log("SOLDADO: (por radio) -Copiado Sombra Nueve, recordaremos tu valent�a... Cambio y fuera.  ");
        }
    }
}