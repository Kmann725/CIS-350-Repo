/*
 * Kyle Manning
 * Prototype 1
 * Handles player loss condition
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PlayerLoseOnFall : MonoBehaviour
{
    //public Text textbox;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1)
        {
            //textbox.text = "You Lose!";
            ScoreManager.gameOver = true;
        }
    }
}
