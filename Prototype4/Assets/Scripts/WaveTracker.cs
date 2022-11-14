/*
 * Kyle Manning
 * Prototype 4
 * Keeps track of and displays wave number
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTracker : MonoBehaviour
{
    private SpawnManager sm;
    private Text waveText;

    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        waveText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "Wave " + sm.waveNumber;
    }
}
