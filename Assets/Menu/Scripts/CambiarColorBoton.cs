using UnityEngine;
using UnityEngine.UI;

public class CambiarColorBoton : MonoBehaviour
{
    private Image imagenBoton; // Referencia al componente Image del botón
    private Color colorOriginal; // Almacena el color original del botón
    private Color colorHover = Color.yellow; // Color al pasar el mouse

    private void Start()
    {
        // Obtiene el componente Image del botón
        imagenBoton = GetComponent<Image>();
        if (imagenBoton != null)
        {
            colorOriginal = imagenBoton.color; // Guarda el color original
        }
    }

    public void CambiarColorAmarillo()
    {
        if (imagenBoton != null)
        {
            imagenBoton.color = colorHover; // Cambia el color a amarillo
        }
    }

    public void RestaurarColorOriginal()
    {
        if (imagenBoton != null)
        {
            imagenBoton.color = colorOriginal; // Restaura el color original
        }
    }
}
