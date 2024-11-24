using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : ICommand
{
    private GameObject bulletPrefab;
    private float bulletSpeed = 10f;
    private Transform soldierTransform;

    private int maxAmmo = 30; // Tamaño del cargador
    private int currentAmmo;  // Balas actuales en el cargador
    private int totalAmmo;    // Balas restantes en el inventario

    public ShootCommand(GameObject bulletPrefab, Transform soldierTransform, int startingAmmo)
    {
        this.bulletPrefab = bulletPrefab;
        this.soldierTransform = soldierTransform;
        this.currentAmmo = maxAmmo;  // El cargador inicia lleno
        this.totalAmmo = startingAmmo; // Inventario inicial
    }

    public void Execute()
    {
        if (currentAmmo > 0)
        {
            //Calcular la posición de disparo en torno en la posición del soldado
            Vector3 shootPosition = soldierTransform.position + soldierTransform.forward + new Vector3(0, 2f, 0);

            //Instanciar la bala y asignarle un componente Rigidbody para su movimiento
            GameObject bullet = Object.Instantiate(bulletPrefab, shootPosition, soldierTransform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = soldierTransform.forward * bulletSpeed;
            currentAmmo--;
            Debug.Log($"AYUDA: Balas restantes en el cargador: {currentAmmo}. Balas totales en el inventario: {totalAmmo}.");
        }
        else
        {
            Debug.Log("SOLDADO: -¡Mierda! ¡Cargador vacío, necesito recargar balas!");
            Debug.Log("AYUDA: Presiona la tecla R para recargar munciciones.");
        }
    }

    public void Reload()
    {
        if (totalAmmo > 0)
        {
            int neededAmmo = maxAmmo - currentAmmo; // Cantidad necesaria para llenar el cargador
            int ammoToReload = Mathf.Min(neededAmmo, totalAmmo); // Cuánto podemos recargar
            currentAmmo += ammoToReload;
            totalAmmo -= ammoToReload;
            Debug.Log($"AYUDA: Cargador recargado. Balas en el cargador: {currentAmmo}. Balas restantes en el inventario: {totalAmmo}.");
        }
        else
        {
            Debug.Log("SOLDADO: -¡No puede ser! ¡Me he quedado sin municiones!");
            Debug.Log("AYUDA: Dirígete a la caja de municiones más cercana para conseguir más balas.");
        }
    }

    public void AddAmmo(int amount)
    {
        totalAmmo += amount;
        Debug.Log($"AYUDA: Has recogido {amount} balas. Ahora tienes {totalAmmo} en el inventario.");
    }
    
    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }

    public int GetTotalAmmo()
    {
        return totalAmmo;
    }
}