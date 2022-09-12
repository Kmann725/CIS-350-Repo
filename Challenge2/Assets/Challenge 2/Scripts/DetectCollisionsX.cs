/*
 * Kyle Manning
 * Challenge 2
 * Destroys balls when they collide with dogs and increments the score
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private ScoreManager score;

    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        score.score++;
        Destroy(gameObject);
    }
}
