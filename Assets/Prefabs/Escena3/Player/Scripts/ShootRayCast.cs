using UnityEngine;

public class ShootRayCast : MonoBehaviour
{
    public float maxDistance = 50f; // Distancia máxima del raycast

    void Update()
    {
        // Dibujar una línea de depuración para visualizar el raycast
        Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.position + Camera.main.transform.forward * maxDistance, Color.red);

        RaycastHit hit;
        // Lanzar un raycast desde la cámara principal hacia adelante
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
        {
            // Verificar si el objeto impactado tiene el tag "Boss"
            if (hit.collider.CompareTag("Boss"))
            {
                Debug.Log($"Apuntando al Boss: {hit.collider.name}, Distancia: {hit.distance:F2} metros");

                // Obtener el componente "Boss" del objeto impactado
                Boss boss = hit.collider.GetComponent<Boss>();
                if (boss != null)
                {
                    // Llamar al método RecibirImpacto() sólo si se presiona el botón de disparo
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        boss.RecibirImpacto(true); // Llamada actualizada con el parámetro booleano
                        Debug.Log("Impacto registrado en el Boss.");
                    }
                }
            }
        }
        else
        {
            Debug.Log("Sin impacto detectado.");
        }
    }
}




/*using UnityEngine;

public class ShootRayCast : MonoBehaviour
{
    public float maxDistance = 50f; // Distancia máxima del raycast

    void Update()
    {
        // Dibujar una línea de depuración para el raycast
        Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.position + Camera.main.transform.forward * maxDistance, Color.red);

        RaycastHit hit;
        // Lanzar un raycast desde la MainCamera hacia adelante
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
        {
            // Verificar si impacta con el "boss"
            if (hit.collider.CompareTag("Boss"))
            {
                float distanceToBoss = hit.distance; // Distancia al "boss"
                Debug.Log($"Apuntando al Boss: {hit.collider.name}, Distancia: {distanceToBoss:F2} metros");
            }
            else
            {
                Debug.Log($"Impacto en: {hit.collider.name}, pero no es el Boss.");
            }
        }
        else
        {
            Debug.Log("Sin impacto detectado.");
        }
    }
}*/





