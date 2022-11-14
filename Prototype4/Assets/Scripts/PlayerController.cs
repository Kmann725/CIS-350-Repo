/*
 * Kyle Manning
 * Prototype 4
 * Handles player movement and powerups
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    public bool hasPowerup;
    public bool gameOver = false;

    public GameObject powerupIndicator;
    public GameObject infoText;
    public GameObject loseText;

    private float forwardInput;
    private float powerupStrength = 15.0f;

    private GameObject focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (Input.GetKeyDown(KeyCode.Space) && infoText)
        {
            Time.timeScale = 1f;
            infoText.SetActive(false);
        }

        if (transform.position.y < -10)
        {
            Time.timeScale = 0;
            loseText.SetActive(true);
            gameOver = true;
        }

        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void FixedUpdate()
    {
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("Player collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);

            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
}
