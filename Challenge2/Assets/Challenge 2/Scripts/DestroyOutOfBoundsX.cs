﻿/*
 * Kyle Manning
 * Challenge 2
 * Destroys objects once they go off screen
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -30;
    private float bottomLimit = -5;

    private GameObject healthSystem;

    private void Start()
    {
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem");
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            healthSystem.GetComponent<HealthSystem>().TakeDamage();
            Destroy(gameObject);
        }

    }
}
