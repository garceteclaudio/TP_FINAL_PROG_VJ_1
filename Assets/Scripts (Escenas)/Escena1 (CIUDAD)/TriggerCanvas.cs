using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCanvas : MonoBehaviour
{
  

    // Función que se ejecuta cuando un objeto entra en el Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica que el objeto que entra al Trigger sea el jugador
        if (other.CompareTag("Player"))
        {
          
            // Cambiar a la escena llamada "victoria"
            SceneManager.LoadScene("Escena2 (EXTRACCIÓN)");
        }
    }

  
}
