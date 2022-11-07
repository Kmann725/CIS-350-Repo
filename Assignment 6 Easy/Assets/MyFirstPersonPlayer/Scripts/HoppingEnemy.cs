/*
 * Kyle Manning
 * Assignment 6 Easy Mode
 * Child class of EnemyAbstract, contains movement and hopping behavior
 * and a function to use its claw weapon on collision with the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppingEnemy : EnemyAbstract
{
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    private Rigidbody rb;

    public float jumpHeight = 3f;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        health = 20f;
        claw.damage = 3f;
        claw.attackDistance = 1f;
    }

    protected override void Update()
    {
        Vector3 targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        Vector3 currentPos = transform.position;
        currentPos.y -= 0.5f;
        isGrounded = Physics.CheckSphere(currentPos, groundDistance, groundMask);

        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(claw.Attack(collision.gameObject));
        }
    }
}
