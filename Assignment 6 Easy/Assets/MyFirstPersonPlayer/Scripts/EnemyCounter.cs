/*
 * Kyle Manning
 * Assignment 6 Easy Mode
 * Keeps track of the number of enemies alive and shows the
 * victory message when they are all defeated
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public int enemyCount = 0;
    public GameObject victoryText;
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount == 0)
        {
            victoryText.SetActive(true);
            player.hasWon = true;
        }
    }
}
