using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar escenas

public class VictoriaAdmin : MonoBehaviour
{
    public Boss boss; // Referencia al script Boss
    public string escenaVictoria = "Victoria"; // Nombre de la escena de victoria

    void Update()
    {
        if (boss == null)
        {
            // Si el Boss ha sido destruido, cargamos la escena de victoria
            Debug.Log("¡El Boss ha sido derrotado! Cargando escena de victoria...");
            SceneManager.LoadScene(escenaVictoria);
        }
    }
}

