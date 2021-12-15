using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the flying enemies' projectile
// This script is for the flying enemies' projectile's behaviour

public class Poop : MonoBehaviour
{
    // Initialize
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        // If the poop hit the player
        if (other.gameObject.tag == "Player")
        {
            // Decrease the number of health by damage, aka 1
            other.gameObject.GetComponent<PlayerStat>().health -= 1;
            // Ask the game manager to check health and update UI
            gameManager.CheckHealth();
        }
        // If the poop hit the death zone
        else if (other.gameObject.name == "Death Zone")
        {
            // offset is what the distance difference between the bird and the poop should be
            Vector3 offset = new Vector3(0, -0.5f, 0);
            // Reset Velocity to 0
            GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);
            // Reset poop's position to the bird
            transform.position = transform.parent.position + offset;
        }
    }
}
