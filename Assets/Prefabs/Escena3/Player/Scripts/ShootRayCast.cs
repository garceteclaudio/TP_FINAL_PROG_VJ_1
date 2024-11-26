using UnityEngine;

public class ShootRayCast : MonoBehaviour
{
    public float maxDistance = 50f; //Distancia maxima del raycast

    void Update()
    {
        Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.position + Camera.main.transform.forward * maxDistance, Color.red); //Dibuja una linea para visualizar el raycast

        RaycastHit hit; //Almacena la info de lo que golpea el raycast

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance)) //Lanza un raycast desde la camara principal hacia adelante
        {
            if (hit.collider.CompareTag("Boss")) //Verificar si el objeto impactado es el Boss
            {
                Debug.Log($"Apuntando al Boss: {hit.collider.name}, Distancia: {hit.distance:F2} metros");

                Boss boss = hit.collider.GetComponent<Boss>(); //Llama a Boss si se ha impactado
                if (boss != null) //Verificar que Boss exista en el objeto impactado
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0)) //Verificar si se presiona el boton de disparo
                    {
                        boss.RecibirImpacto(true); //Llamar al metodo RecibirImpacto del Boss
                        Debug.Log("Impacto registrado en el Boss.");
                    }
                }
            }
        }
    }
}






