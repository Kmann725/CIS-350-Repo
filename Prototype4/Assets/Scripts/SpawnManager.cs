/*
 * Kyle Manning
 * Prototype 4
 * Spawns waves of enemies
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public GameObject winText;
    private float spawnRange = 9;
    public int waveNumber = 1;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup(1);
    }

    private void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0 && waveNumber < 10)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup(1);
        }

        if (waveNumber == 10)
        {
            winText.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerup(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
}
