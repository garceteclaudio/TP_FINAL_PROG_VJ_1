using UnityEngine;
using UnityEngine.SceneManagement;

public class SoldierDerrota : MonoBehaviour
{
    public string escenaDerrota = "Derrota";

    void Update()
    {
        SaludPlayer saludPlayer = GetComponent<SaludPlayer>();

        if (saludPlayer != null && saludPlayer.salud <= 0)
        {
            Time.timeScale = 0f;

            Debug.Log("SOLDADO: (por radio) -�Aqu� Sombra Nueve a Bravo Seis, me superan en n�mero! �Abandonen la zona de inmediato!");
            Debug.Log("SOLDADO: (por radio) -Copiado Sombra Nueve, recordaremos tu valent�a... Cambio y fuera.");

            SceneManager.LoadScene(escenaDerrota);
        }
    }
}



