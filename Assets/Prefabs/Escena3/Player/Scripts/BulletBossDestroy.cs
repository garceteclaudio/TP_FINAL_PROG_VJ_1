using System.Collections;
using UnityEngine;

public class BulletDestroyBoss : MonoBehaviour
{
    public float speed = 10f; //Velocidad de la bala
    public float duration = 5f; //Tiempo de duración de la bala
    public int impactosParaDestruir; //Cantidad de impactos para destruir al Boos

    private int contadorImpactos = 0; //Cuenta los impactos que recibe el Boss

    void Start()
    {
        Destroy(gameObject, duration); //Destruye la bala si no impacta con nada despues de 5 segundos
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //Mueve la bala continuamente para adelante
    }

    private void OnTriggerEnter(Collider other) //Metodo que llama a la bala cuando colisiona con el Boss
    {
        if (other.CompareTag("Boss")) //Verifica si la bala colisionó con el Boss mediante su tag
        {
            contadorImpactos++; //Incrementa el contador por cada impacto
            Debug.Log("El boss ha sido herido: " + contadorImpactos);
            Boss boss = other.GetComponent<Boss>(); //Llama al componente Boss
            if (boss != null) //Verifica si el Boss existe
            {
                boss.RecibirImpacto(true); //Verifica que el impacto en el Boss
            }

            NavMeshBossController navController = other.GetComponent<NavMeshBossController>(); //Llama al NavMeshController del Boss 
            if (navController != null) //Verifica si el navController existe
            {
                navController.RecibirImpacto(); //Verifica el impacto
            }

            Destroy(gameObject); //Destruye la bala despues de impactar con el Boss
        }
    }
}
