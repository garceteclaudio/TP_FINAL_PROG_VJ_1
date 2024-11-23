using UnityEngine;

public class SonidoBoton : MonoBehaviour
{
    private AudioSource audioSource; // Referencia al AudioSource

    private void Start()
    {
        // Obtiene el componente AudioSource del botón
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirSonido()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Reproduce el sonido
        }
    }
}
