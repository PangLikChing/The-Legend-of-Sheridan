using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the walking enemies in the game scene
// This script is for agent's behaviour except moving
public class WalkingEnemy : MonoBehaviour
{
    // Initialize
    int health = 1;

    void Start()
    {
        // Initialize the stat at start
        health = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        // If the trigger object is a Two handed Mace and the player is currently attacking
        if (other.gameObject.tag == "TwoHandedMace" && other.transform.parent.GetComponent<Attack>().isAttacking == true)
        {
            // Reduct the health of the enemy by damage from the weapon aka the 1
            gameObject.GetComponent<WalkingEnemy>().health -= 1;
            // Play box destroy sound effect

            // If the remaining health is lower than or equal to 0
            if (gameObject.GetComponent<WalkingEnemy>().health <= 0)
            {
                // Set the gameObject to inactive
                gameObject.SetActive(false);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // If the enemy hits the player
        if (collision.gameObject.tag == "Player")
        {
            // Decrease the number of health by damage, aka 1
            collision.gameObject.GetComponent<PlayerStat>().health -= 1;
        }
    }
}
