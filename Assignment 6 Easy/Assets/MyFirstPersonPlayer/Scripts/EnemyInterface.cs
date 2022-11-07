/*
 * Kyle Manning
 * Assignment 6 Easy Mode
 * Interface for enemies, ensures they always have methods for attacking and taking damage
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyInterface
{
    void TakeDamage(float amount);

    void DealDamage(float amount, GameObject target);
}
