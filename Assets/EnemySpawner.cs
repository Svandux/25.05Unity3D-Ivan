using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float spawnInternal = 5f;
    public int maxEnemies = 10;

    private float timer;
    private int currentEnemies = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >=spawnInternal && currentEnemies < maxEnemies)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
        currentEnemies++;
    }
    Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(-45f, 45f);
        float z = Random.Range(-45f, 45f);

        if (Random.value > 0.5f)
            x = (Random.value > 0.5f) ? 45f : -45f;
        else
            z = (Random.value > 0.5f) ? 45f : -45f;

        return new Vector3(x, 0.5f, z);
    }
}
