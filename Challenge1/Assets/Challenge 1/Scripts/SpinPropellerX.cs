/*
 * Kyle Manning
 * Challenge 1
 * Makes the plane's propeller rotate
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    public float propRotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * propRotateSpeed);
    }
}
