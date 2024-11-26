using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : ICommand
{
    private GameObject bulletPrefab;
    private float bulletSpeed = 10f;
    private Transform soldierTransform;
    private int maxAmmo = 30; //Tamaño del cargador
    private int currentAmmo;  //Balas actuales en el cargador
    private int totalAmmo;    //Balas restantes en el inventario

    private AudioSource audioSource;
    private AudioClip shotSound;
    private AudioClip emptySound;
    private AudioClip reloadSound;

    public ShootCommand(GameObject bulletPrefab, Transform soldierTransform, int startingAmmo, AudioSource audioSource, AudioClip shotSound, AudioClip emptySound, AudioClip reloadSound)
    {
        this.bulletPrefab = bulletPrefab;
        this.soldierTransform = soldierTransform;
        this.currentAmmo = maxAmmo;
        this.totalAmmo = startingAmmo;
        this.audioSource = audioSource;
        this.shotSound = shotSound;
        this.emptySound = emptySound;
        this.reloadSound = reloadSound;
    }

    public void Execute()
    {
        if (currentAmmo > 0)
        {
            //Calcular la posición de disparo en torno a la posición del soldado
            Vector3 shootPosition = soldierTransform.position + soldierTransform.forward + new Vector3(0, 2f, 0);

            //Instanciar la bala y asignarle un componente Rigidbody para su movimiento
            GameObject bullet = Object.Instantiate(bulletPrefab, shootPosition, soldierTransform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = soldierTransform.forward * bulletSpeed;

            currentAmmo--;
            Debug.Log($"AYUDA: Balas restantes en el cargador: {currentAmmo}. Balas totales en el inventario: {totalAmmo}.");

            //Reproducir sonido de disparo
            audioSource.PlayOneShot(shotSound);
        }
        else
        {
            Debug.Log("SOLDADO: -¡Mierda! ¡Cargador vacío, necesito recargar balas!");
            Debug.Log("AYUDA: Presiona la tecla R para recargar municiones.");

            //Reproducir sonido de cargador vacío
            audioSource.PlayOneShot(emptySound);
        }
    }

    public void Reload()
    {
        if (totalAmmo > 0)
        {
            int neededAmmo = maxAmmo - currentAmmo;
            int ammoToReload = Mathf.Min(neededAmmo, totalAmmo);

            currentAmmo += ammoToReload;
            totalAmmo -= ammoToReload;

            Debug.Log($"AYUDA: Cargador recargado. Balas en el cargador: {currentAmmo}. Balas restantes en el inventario: {totalAmmo}.");

            //Reproducir sonido de recarga
            audioSource.PlayOneShot(reloadSound);
        }
        else
        {
            Debug.Log("SOLDADO: -¡No puede ser! ¡Me he quedado sin municiones!");
            Debug.Log("AYUDA: Dirígete a la caja de municiones más cercana para conseguir más balas.");
        }
    }

    public void AddAmmo(int amount)
    {
        //Agregar balas desde la caja de municiones
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
