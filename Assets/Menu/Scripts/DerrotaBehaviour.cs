using UnityEngine;
using UnityEngine.SceneManagement;

public class DerrotaBehaviour : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Nombre de la escena a cargar

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Comprueba si se presiona la tecla R
        {
            LoadScene(sceneToLoad);
        }
    }

   
    private void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName)) // Verifica que el nombre no esté vacío
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("El nombre de la escena no está asignado.");
        }
    }
}
