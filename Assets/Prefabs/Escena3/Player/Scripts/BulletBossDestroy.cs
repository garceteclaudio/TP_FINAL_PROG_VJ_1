using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletDestroyBoss : MonoBehaviour
{
    public float speed = 10f;
    public float duration = 5f;
    public int impactosParaDestruir = 3;

    private int contadorImpactos = 0;

    void Start()
    {
        Destroy(gameObject, duration);
    }

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Boss"))
        {
            contadorImpactos++;
            Debug.Log("El boss ha sido herido: " + contadorImpactos);

            Boss boss = other.GetComponent<Boss>();
            if (boss != null)
            {
                boss.RecibirImpacto();
            }

            Destroy(gameObject);
        }
    }
}


