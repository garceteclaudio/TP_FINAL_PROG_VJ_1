using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    private void Start()
    {
        // Asegurar que el cursor sea visible y desbloqueado al iniciar la escena del menú
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EmpezarNivel(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("El juego ha salido");
    }
}
