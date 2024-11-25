using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaCollider : MonoBehaviour
{
    public float speed = 10f;
    public float duration = 5f;

    void Start()
    {
        //Destruir la bala después de un tiempo si no colisiona con un enemigo.
        Destroy(gameObject, duration);
    }

    void Update()
    {
        //Mover la bala hacia delante.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        //Verificar si la bala colisiona con un enemigo.
        if (other.CompareTag("Enemy"))
        {
            //Destruir al enemigo y a la bala.
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("SOLDADO: -Un enemigo menos, al menos no todas son malas noticias...");
        }
    }
}