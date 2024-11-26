using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoriaAdmin : MonoBehaviour
{
    public Boss boss;
    public string escenaVictoria = "Victoria";

    void Update()
    {
        if (boss == null)
        {
            Debug.Log("¡El Boss ha sido derrotado! Cargando escena de victoria...");
            SceneManager.LoadScene(escenaVictoria);
        }
    }
}

