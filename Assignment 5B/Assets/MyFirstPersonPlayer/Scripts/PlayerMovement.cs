/*
 * Kyle Manning
 * Assignment 5B
 * Handles player movement and jumping
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 12f;

    public Vector3 velocity;
    public float gravity = -9.81f;
    public float gravityMultiplier = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    public float jumpHeight = 3f;

    public GameObject victoryScreen;
    private bool hasWon = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasWon)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MyFirstPersonPlayer");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("goal"))
        {
            victoryScreen.SetActive(true);
            hasWon = true;
        }
    }
}
