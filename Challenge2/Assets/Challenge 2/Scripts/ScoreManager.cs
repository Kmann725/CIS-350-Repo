/*
 * Kyle Manning
 * Challenge 2
 * Displays the player's score in game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text textbox;

    public GameObject winText;

    public int score;

    private HealthSystem hs;

    // Start is called before the first frame update
    void Start()
    {
        hs = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();

        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Score: " + score;

        if (score >= 5)
        {
            winText.SetActive(true);
            hs.gameOver = true;
        }
    }
}
