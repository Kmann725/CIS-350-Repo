/*
 * Kyle Manning
 * Prototype 1
 * Handles player win condition
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PlayerEnterTrigger : MonoBehaviour
{
    //public Text textbox;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger Zone"))
        {
            //textbox.text = "You Win!";
            ScoreManager.score++;
        }
    }
}
