using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float waveStartTime = 10f;
    [SerializeField] private float gameTime = 0f;
    [SerializeField] private float enemySpawnDelay = 0.5f;

    private float timeElapsed = 0f;

    private void Update()
    {
        gameTime += Time.deltaTime;
        timeElapsed += Time.deltaTime;

        if (gameTime > waveStartTime)
        {
            if (timeElapsed >= enemySpawnDelay)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-5f, 5f), Random.Range(1f, 1f), 1), Quaternion.identity);
                timeElapsed = 0f;
                OutputTime();
            }
        }
    }

    void OutputTime()
    {
        Debug.Log(Time.time);
    }


}