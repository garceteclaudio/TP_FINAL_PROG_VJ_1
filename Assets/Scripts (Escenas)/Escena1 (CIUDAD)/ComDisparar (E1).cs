using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComDisparar : ICommand
{
    private GameObject bulletPrefab;
    private float bulletSpeed = 10f;
    private Transform soldierTransform;

    public ComDisparar(GameObject bulletPrefab, Transform soldierTransform)
    {
        this.bulletPrefab = bulletPrefab;
        this.soldierTransform = soldierTransform;
    }

    public void Execute()
    { 
        //Calcular la posición de disparo en torno en la posición del soldado
        Vector3 shootPosition = soldierTransform.position + soldierTransform.forward + new Vector3(0, 2f, 0);

        //Instanciar la bala y asignarle un componente Rigidbody para su movimiento
        GameObject bullet = Object.Instantiate(bulletPrefab, shootPosition, soldierTransform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = soldierTransform.forward * bulletSpeed;
    }
}