/*
 * Kyle Manning
 * Prototype 3
 * Allows the player to jump when they press the space bar and checks
 * for obstacle collisions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource playerAudio;
    public Animator playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();

        playerAnimator.SetFloat("Speed_f", 1.0f);

        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;

            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);

            playerAnimator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("Game Over!");
            gameOver = true;

            playerAudio.PlayOneShot(crashSound, 1.0f);
            dirtParticle.Stop();
            explosionParticle.Play();

            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
        }
    }
}
