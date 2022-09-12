/*
 * Kyle Manning
 * Prototype 2
 * Fires a food item from the player's position
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPrefab : MonoBehaviour
{
    public GameObject prefabToShoot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabToShoot, transform.position, prefabToShoot.transform.rotation);
        }
    }
}
