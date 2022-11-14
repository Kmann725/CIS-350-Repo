/*
 * Kyle Manning
 * Challenge 4
 * Keeps track of and displays the wave number
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTracker : MonoBehaviour
{
    private SpawnManagerX sm;
    private Text waveText;

    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();
        waveText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "Wave " + sm.waveCount;
    }
}
