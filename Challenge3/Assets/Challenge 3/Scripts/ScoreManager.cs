/*
 * Kyle Manning
 * Challenge 3
 * Updates score counter, displays win and lose messages, and allows the player
 * to restart on game over
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    private PlayerControllerX pcx;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        pcx = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!pcx.gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        if (pcx.gameOver)
        {
            scoreText.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }

        if (score >= 15)
        {
            pcx.gameOver = true;

            scoreText.text = "You Win!" + "\n" + "Press R to Try Again!";
        }

        if (pcx.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
