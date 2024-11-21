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
        //Usar Invoke para generar el primer enegmigo luego de un tiempo específico.
        Invoke("SpawnEnemy", initialDelay);

        //Usar InvokeRepeating para generar más enemigos en un intervalo específico.
        InvokeRepeating("SpawnEnemy", initialDelay + repeatInterval, repeatInterval);
    }

    void SpawnEnemy()
    {
        //Instanciar el enemigo en la posición actual del spawner.
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
