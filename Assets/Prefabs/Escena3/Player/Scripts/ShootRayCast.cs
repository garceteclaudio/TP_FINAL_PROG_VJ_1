using UnityEngine;

public class ShootRayCast : MonoBehaviour
{
    public float maxDistance = 50f;

    void Update()
    {
        Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.position + Camera.main.transform.forward * maxDistance, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
        {
            if (hit.collider.CompareTag("Boss"))
            {
                Debug.Log($"Apuntando al Boss: {hit.collider.name}, Distancia: {hit.distance:F2} metros");

                Boss boss = hit.collider.GetComponent<Boss>();
                if (boss != null)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        boss.RecibirImpacto(true);
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





