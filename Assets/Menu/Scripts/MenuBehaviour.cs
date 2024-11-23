using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    public void EmpezarNivel(string NombreNivel) {
        SceneManager.LoadScene(NombreNivel);
    }

    public void Salir() { 
        Application.Quit();
        Debug.Log("El juego ha salido");
    }
}
