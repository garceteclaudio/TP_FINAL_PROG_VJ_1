using UnityEngine;
using UnityEngine.SceneManagement;

public class SoldierDerrota : MonoBehaviour
{
    public string escenaDerrota = "Derrota"; //Nombre de la escena de derrota

    void Update()
    {
        SaludPlayer saludPlayer = GetComponent<SaludPlayer>(); //Llama al componente SaludPlayer

        if (saludPlayer != null && saludPlayer.salud <= 0) //Verifica si el componente SaludPlayer existe y su salud es 0 o menor
        {
            Time.timeScale = 0f; //Detiene el juego

            Debug.Log("SOLDADO: (por radio) -¡Aqui Sombra Nueve a Bravo Seis, me superan en numero! ¡Abandonen la zona de inmediato!");
            Debug.Log("SOLDADO: (por radio) -Copiado Sombra Nueve, recordaremos tu valentia... Cambio y fuera.");

            SceneManager.LoadScene(escenaDerrota); //Carga la escena de derrota
        }
    }
}




