/*
 * Kyle Manning
 * Assignment 6 Easy Mode
 * Acts as enemy weapon and deals damage, contains polymorphism
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClaw : MonoBehaviour
{
    public float damage;
    public float attackDistance;

    public EnemyAbstract enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<EnemyAbstract>();
    }

    public IEnumerator Attack(GameObject target)
    {
        Debug.Log("Attacking");
        yield return new WaitForSeconds(1.5f);

        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < attackDistance)
        {
            enemy.DealDamage(damage, target);
        }
    }
}
