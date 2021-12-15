using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the sentry gun's projectile in the game scene
// This script is for the sentry gun's projectile's behaviour

public class SentryGunShots : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 0.5f;

    //void Start()
    //{
    //    // Set the projectile as same as sentry gun's rotation
    //    transform.rotation = transform.parent.rotation;
    //}

    void FixedUpdate()
    {
        // Move the bullet to the direction that they should go
        gameObject.transform.position += transform.parent.right * projectileSpeed;
    }

    // If the bullet hit anything
    void OnTriggerEnter(Collider other)
    {
        // If that is not the sentry gun itself
        if (transform.parent != other.transform)
        {
            // Set the bullet to inactive
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If that is not the sentry gun itself, just to be safe, should not hit this at all time
        if (transform.parent != collision.transform)
        {
            // Set the bullet to inactive
            gameObject.SetActive(false);
        }
    }
}
