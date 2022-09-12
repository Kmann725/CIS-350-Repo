/*
 * Kyle Manning
 * Challenge 2
 * Spawns balls from the top of the screen at random points
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private HealthSystem hs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        hs = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();

        StartCoroutine(SpawnBallAtRandom());
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        int randomBall = Random.Range(0, 3);

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomBall], spawnPos, ballPrefabs[0].transform.rotation);
    }

    IEnumerator SpawnBallAtRandom()
    {
        yield return new WaitForSeconds(1f);

        while(!hs.gameOver)
        {
            SpawnRandomBall();

            float randomWait = Random.Range(3f, 5f);

            yield return new WaitForSeconds(randomWait);
        }
    }
}
