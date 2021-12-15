using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the sentry gun in the game scene
// This script is for the sentry gun's behaviour

public class SentryGun : MonoBehaviour
{
    [SerializeField] float fireTimer = 2.5f;
    bool isFired = false;
    void Start()
    {
        // Initialize state
        isFired = false;
    }

    void Update()
    {
        // If isFired is false
        if (isFired == false)
        {
            // Start the fire timer
            StartCoroutine(Shot());
            // Set isFired back to true
            isFired = true;
        }
    }

    IEnumerator Shot()
    {
        // Wait for fireTimer amount of seconds
        yield return new WaitForSeconds(fireTimer);
        // Reset the position of the shot to the sentry gun's position
        transform.GetChild(0).transform.position = transform.position;
        // Fire the first projectile
        transform.GetChild(0).gameObject.SetActive(true);
        // Set isFired to false
        isFired = false;
    }
}
