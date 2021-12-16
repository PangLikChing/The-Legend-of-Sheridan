using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the sentry gun's projectile in the game scene
// This script is for the sentry gun's projectile's behaviour

public class SentryGunShots : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] float projectileSpeed = 0.5f;

    void Start()
    {
        // Find the game manager
        gameManager = FindObjectOfType<GameManager>();
    }

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
        // Should not hit this, here just to be safe
        else if (other.gameObject.tag == "Player")
        {
            // Decrease the number of health by damage, aka 1
            other.gameObject.GetComponent<PlayerStat>().health -= 1;
            // Ask the game manager to check health and update UI
            gameManager.CheckHealth();
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
        // If the shot hits the player
        if (collision.gameObject.tag == "Player")
        {
            // Decrease the number of health by damage, aka 1
            collision.gameObject.GetComponent<PlayerStat>().health -= 1;
            // Ask the game manager to check health and update UI
            gameManager.CheckHealth();
        }
    }
}
