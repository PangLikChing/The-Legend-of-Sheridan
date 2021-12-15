using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    int health = 1;

    private void Start()
    {
        // Initialize the stat at start
        health = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        // If the trigger object is an arrow
        if (other.gameObject.tag == "Arrow")
        {
            // Reduct the health of the enemy by damage from the weapon aka the 1
            gameObject.GetComponent<FlyingEnemy>().health -= 1;
            // Play box destroy sound effect

            // If the remaining health is lower than or equal to 0
            if (gameObject.GetComponent<FlyingEnemy>().health <= 0)
            {
                // Set the gameObject to inactive
                gameObject.SetActive(false);
            }
        }
    }
}
