using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI

public class CoinBehaviour : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotación en grados por segundo
    private static int coinsCollected = 0; // Contador estático para monedas recolectadas
    public Text coinsText; // Referencia al texto UI para mostrar las monedas recolectadas
    public AudioClip collectSound; // Clip de sonido para la recolección
    private AudioSource audioSource; // Componente para reproducir sonidos

    void Start()
    {
        // Inicializa el texto si está configurado
        if (coinsText != null)
        {
            UpdateCoinText();
        }

        // Obtén o agrega el AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotar alrededor del eje Z
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    // Detecta colisiones
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            coinsCollected++; // Incrementa el contador
            Debug.Log("Monedas recolectadas: " + coinsCollected); // Muestra el total en la consola
            UpdateCoinText(); // Actualiza el texto UI

            // Reproducir el sonido de recolección
            if (collectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            Destroy(gameObject); // Destruye la moneda
        }
    }

    // Actualiza el texto con el número de monedas
    void UpdateCoinText()
    {
        if (coinsText != null)
        {
            coinsText.text = "Monedas: " + coinsCollected;
            coinsText.color = Color.yellow; // Cambia el color del texto a amarillo
        }
    }
}