/*
 * Kyle Manning
 * Assignment 6 Easy Mode
 * Example class for composition
 */
using System.Collections;
using UnityEngine;

[System.Serializable]
public class Weapon : MonoBehaviour
{
    public int damageBonus;

    public Enemy enemyHoldingWeapon;

    private void Awake()
    {
        enemyHoldingWeapon = gameObject.GetComponent<Enemy>();
        EnemyEatsWeapon(enemyHoldingWeapon);
    }

    protected void EnemyEatsWeapon(Enemy enemy)
    {
        Debug.Log("enemy eats weapon");
    }

    public void Recharge()
    {
        Debug.Log("Recharging weapon");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}