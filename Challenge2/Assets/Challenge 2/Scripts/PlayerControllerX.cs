/*
 * Kyle Manning
 * Challenge 2
 * Allows the player to spawn dogs at a certain rate
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private bool canFire = true;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            StartCoroutine(DogReload());
        }
    }

    IEnumerator DogReload()
    {
        canFire = false;

        yield return new WaitForSeconds(0.5f);

        canFire = true;
    }
}
