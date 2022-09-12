/*
 * Kyle Manning
 * Prototype 2
 * Spawns animals at random points at the top of the screen
 * and at varying intervals
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;

    public HealthSystem healthSystem;

    private float leftBound = -14;
    private float rightBound = 14;
    private float spawnPosZ = 20;

    public bool gameOver = false;

    private void Start()
    {
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();

        StartCoroutine(SpawnRandomPrefavWithCoroutine());
    }

    // Update is called once per frame
    private void SpawnRandomPrefab()
    {
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }

    IEnumerator SpawnRandomPrefavWithCoroutine()
    {
        yield return new WaitForSeconds(3f);

        while (!healthSystem.gameOver)
        {
            SpawnRandomPrefab();

            float randomDelay = Random.Range(0.8f, 2.0f);

            yield return new WaitForSeconds(randomDelay);
        }
    }
}
