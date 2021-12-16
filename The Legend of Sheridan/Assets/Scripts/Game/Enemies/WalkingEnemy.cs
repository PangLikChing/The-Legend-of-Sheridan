using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the walking enemies in the game scene
// This script is for agent's behaviour except moving

public class WalkingEnemy : MonoBehaviour
{
    // Initialize
    GameManager gameManager;
    int health = 1;
    public bool hasRock = false;
    [SerializeField] float attackDistance = 10;
    [SerializeField] GameObject rockPile, player;

    SoundManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Play("Main theme");

        // Find the game manager
        gameManager = FindObjectOfType<GameManager>();
        // Initialize the stat at start
        health = 1;
        hasRock = false;
    }

    void FixedUpdate()
    {
        // Calculate the distance between the player and this walking enemy
        float distance = Vector3.Distance(player.transform.position, transform.position);
        // If the distance between the player and this walking enemy is less than the attacking distance and has a rock
        if (distance <= attackDistance && hasRock == true)
        {
            // Throw the rock
            ThrowRock();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If the enemy reached the rock
        if (other.gameObject.tag == "Rock")
        {
            // Pick up the rock
            hasRock = true;
            // Get a rock from rock pile and set the parent to the walking enemy
            rockPile.transform.GetChild(0).transform.SetParent(transform);
            // Set the rock to inactive
            other.gameObject.SetActive(false);
        }

        // If the trigger object is a One Handed Sword and the player is currently attacking
        if (other.gameObject.tag == "OneHandedSword" && other.transform.parent.GetComponent<Attack>().isAttacking == true)
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
                soundManager.Play("Monster dying");
            }
        }
        // If the trigger object is an arrow
        if (other.gameObject.tag == "Arrow")
        {
            // Reduct the health of the enemy by damage from the weapon aka the 1
            gameObject.GetComponent<WalkingEnemy>().health -= 1;
            // Play box destroy sound effect

            // If the remaining health is lower than or equal to 0
            if (gameObject.GetComponent<WalkingEnemy>().health <= 0)
            {
                // Set the gameObject to inactive
                gameObject.SetActive(false);
                soundManager.Play("Monster dying");
            }
        }
    }

    // Attacking
    void OnCollisionEnter(Collision collision)
    {
        // If the enemy hits the player
        if (collision.gameObject.tag == "Player")
        {
            // Decrease the number of health by damage, aka 1
            collision.gameObject.GetComponent<PlayerStat>().health -= 1;
            // Ask the game manager to check health and update UI
            gameManager.CheckHealth();
        }
    }

    // Function to throw a rock
    void ThrowRock()
    {
        // Set hasRock to false
        hasRock = false;
        // Throw the rock
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
