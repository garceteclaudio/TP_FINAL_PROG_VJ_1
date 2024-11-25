using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyBoss : MonoBehaviour
{
    public float speed = 10f;
    public float duration = 5f;
    public int impactosParaDestruir = 3;

    private int contadorImpactos = 0;

    void Start()
    {
        Destroy(gameObject, duration);  // Destruir la bala despu�s de un tiempo.
    }

    void Update()
    {
        // Mover la bala hacia adelante.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)  // Aseg�rate de usar Collider y no Collision
    {
        Debug.Log("Colisi�n detectada con: " + other.name); // Depuraci�n de colisiones

        if (other.CompareTag("Boss"))  // Verificar si la colisi�n fue con el Boss
        {
            contadorImpactos++;
            Debug.Log("Impactado por bala. Contador: " + contadorImpactos);

            // Llamar al m�todo RecibirImpacto del Boss
            Boss boss = other.GetComponent<Boss>();
            if (boss != null)
            {
                boss.RecibirImpacto();
            }

            Destroy(gameObject);  // Destruir la bala
        }
    }
}


