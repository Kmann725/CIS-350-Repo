/*
 * Kyle Manning
 * Assignment 6 Easy Mode
 * Child class of EnemyAbstract, contains movement behavior
 * and a function to use its claw weapon on collision with the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : EnemyAbstract
{
    private void Start()
    {
        claw.damage = 5f;
        claw.attackDistance = 1.5f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(claw.Attack(collision.gameObject));
        }
    }
}
