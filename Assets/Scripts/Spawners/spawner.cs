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
    [SerializeField] private float enemySpawnDelay = 1.5f;
    public int EnemiesToSpawn = 1;
    private int EnemiesSpawned = 0;

    private float timeElapsed = 0f;

    void Start()
    {
        EnemyEntity.EnemiesLeft += EnemiesToSpawn;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        timeElapsed += Time.deltaTime;

        if (gameTime > waveStartTime && EnemiesSpawned < EnemiesToSpawn)
        {
            if (timeElapsed >= enemySpawnDelay)
            {
                //if (Physics.Raycast(gameObject.transform.position, Vector3.down, out RaycastHit hit))
                //{
                //    GameObject newEnemy = Instantiate(enemyPrefab, hit.point, Quaternion.identity);
                //}
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