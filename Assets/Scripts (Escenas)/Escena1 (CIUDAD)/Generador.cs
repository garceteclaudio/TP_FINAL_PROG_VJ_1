using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    [SerializeField] private GameObject enemigo;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private int cantidadMaxima = 5; // Número máximo de veces que se generarán enemigos
    private int cantidadGenerada = 0; // Contador de veces que se han generado enemigos

    // Start is called before the first frame update
    void Start()
    {
        //un invoke repeating que llama a un metodo despues de 2 segundos y inicia un bucle de 5 seg
        InvokeRepeating("GenerarEnemigos", 2f, 5f);
    }

    private void GenerarEnemigos()
    {
        if (cantidadGenerada < cantidadMaxima)
        {
            // Calcula la posición de spawn sumando un vector al transform actual (puedes personalizar este offset)
            Vector3 spawnPos = transform.position + new Vector3(0, 0, 0);
            // Instancia un nuevo enemigo en la posición calculada con rotación 
            Instantiate(enemigo, spawnPos, Quaternion.identity);
            cantidadGenerada++; // Incrementar el contador
        }
        else
        {
            CancelInvoke("GenerarEnemigos"); // Detener el InvokeRepeating cuando se haya alcanzado el máximo
        }
    }
}
