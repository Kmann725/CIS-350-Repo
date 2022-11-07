/*
 * Kyle Manning
 * Assignment 6 Easy Mode
 * Parent class for enemies, contains functions for attacking and taking damage
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbstract : MonoBehaviour, EnemyInterface
{
    protected float health = 30f;
    protected float damage = 5f;
    protected float moveSpeed = 5;
    private EnemyCounter ec;

    protected BoxClaw claw;

    void Awake()
    {
        ec = GameObject.Find("enemy counter").GetComponent<EnemyCounter>();
        ec.enemyCount++;

        claw = gameObject.AddComponent<BoxClaw>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Vector3 targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            ec.enemyCount--;
            Destroy(gameObject);
        }
    }

    public void DealDamage(float amount, GameObject target)
    {
        target.GetComponent<PlayerMovement>().health -= amount;
    }
}
