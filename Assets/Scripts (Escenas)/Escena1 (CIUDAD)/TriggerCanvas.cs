using UnityEngine;

public class TriggerCanvas : MonoBehaviour
{
    // Arrastra tu Canvas desde la jerarquía a esta variable en el Inspector
    public GameObject canvas;

    // Función que se ejecuta cuando un objeto entra en el Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica que el objeto que entra al Trigger sea el jugador
        if (other.CompareTag("Player"))
        {
            // Activa el Canvas cuando el jugador entra en el Trigger
            canvas.SetActive(true);
        }
    }

    // Función que se ejecuta cuando un objeto sale del Trigger (opcional)
    private void OnTriggerExit(Collider other)
    {
        // Verifica que el objeto que sale del Trigger sea el jugador
        if (other.CompareTag("Player"))
        {
            // Desactiva el Canvas cuando el jugador sale del Trigger (opcional)
            canvas.SetActive(false);
        }
    }
}
