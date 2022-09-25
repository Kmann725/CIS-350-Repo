/*
 * Kyle Manning
 * Prototype 3
 * Increases score by 1 when the player enters the trigger zone
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterAddScore : MonoBehaviour
{
    private UIManager uIManager;

    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            uIManager.score++;
        }
    }
}
