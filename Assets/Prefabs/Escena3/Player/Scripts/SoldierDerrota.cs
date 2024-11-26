using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class SoldierDerrota : MonoBehaviour
{
    public string escenaDerrota = "Derrota"; // Nombre de la escena de derrota

    void Update()
    {
        // Obtener el componente SaludPlayer
        SaludPlayer saludPlayer = GetComponent<SaludPlayer>();

        if (saludPlayer != null && saludPlayer.salud <= 0)
        {
            // Detener el tiempo del juego (opcional)
            Time.timeScale = 0f;

            // Mostrar mensajes de derrota
            Debug.Log("SOLDADO: (por radio) -¡Aquí Sombra Nueve a Bravo Seis, me superan en número! ¡Abandonen la zona de inmediato!");
            Debug.Log("SOLDADO: (por radio) -Copiado Sombra Nueve, recordaremos tu valentía... Cambio y fuera.");

            // Cargar la escena de derrota
            SceneManager.LoadScene(escenaDerrota);
        }
    }
}



