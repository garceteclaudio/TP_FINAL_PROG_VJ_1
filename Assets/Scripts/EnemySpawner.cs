using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector3 spawnPosition;
    public float initialDelay;
    public float repeatInterval;

    void Start()
    {
        //Usar Invoke para generar el primer enegmigo luego de un tiempo espec�fico.
        Invoke("SpawnEnemy", initialDelay);

        //Usar InvokeRepeating para generar m�s enemigos en un intervalo espec�fico.
        InvokeRepeating("SpawnEnemy", initialDelay + repeatInterval, repeatInterval);
    }

    void SpawnEnemy()
    {
        //Instanciar el enemigo en la posici�n actual del spawner.
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
