using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float enemySpawnDelay = 1f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemySpawnDelay, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(1f, 1), Random.Range(1f, 1f), 1), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}