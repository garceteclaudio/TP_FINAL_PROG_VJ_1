using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    [SerializeField] private GameObject enemigo;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private int cantidadMaxima = 5; // N�mero m�ximo de veces que se generar�n enemigos
    private int cantidadGenerada = 0; // Contador de veces que se han generado enemigos

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerarEnemigos", 2f, 5f);
    }

    private void GenerarEnemigos()
    {
        if (cantidadGenerada < cantidadMaxima)
        {
            Vector3 spawnPos = transform.position + new Vector3(0, 0, 0);
            Instantiate(enemigo, spawnPos, Quaternion.identity);
            cantidadGenerada++; // Incrementar el contador
        }
        else
        {
            CancelInvoke("GenerarEnemigos"); // Detener el InvokeRepeating cuando se haya alcanzado el m�ximo
        }
    }
}
