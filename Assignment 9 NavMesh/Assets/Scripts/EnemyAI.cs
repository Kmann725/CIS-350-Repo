/*
 * Kyle Manning
 * Assignment 9
 * Moves the enemy towards the player when they are within a certain distance
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyAI : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public float chaseDistance;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<ThirdPersonCharacter>();
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        chaseDistance = 8.0f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        float distanceFromTarget = Vector3.Distance(transform.position, player.transform.position);

        if (distanceFromTarget > agent.stoppingDistance && distanceFromTarget < chaseDistance)
        {
            agent.SetDestination(player.transform.position);
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            agent.SetDestination(transform.position);
            character.Move(Vector3.zero, false, false);
        }
    }
}
