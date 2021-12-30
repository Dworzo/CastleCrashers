using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Skrypt spawner.cs spawnuje 'EnemiesToSpawn' przeciwników w miejscu
    // obiektu, do którego został przyłączony

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float waveStartTime = 0f;
    [SerializeField] private float gameTime = 0f;
    [SerializeField] private float enemySpawnDelay = 0.5f;
    public int EnemiesToSpawn = 1;
    private int EnemiesSpawned = 0;

    private float timeElapsed = 0f;

    private void Update()
    {
        gameTime += Time.deltaTime;
        timeElapsed += Time.deltaTime;

        if (gameTime > waveStartTime && EnemiesSpawned < EnemiesToSpawn)
        {
            if (timeElapsed >= enemySpawnDelay)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
                timeElapsed = 0f;
                EnemiesSpawned++;
                OutputTime();
            }
        }
    }

    void OutputTime()
    {
        Debug.Log(Time.time);
    }


}