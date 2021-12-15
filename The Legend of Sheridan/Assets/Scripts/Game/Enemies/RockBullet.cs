using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBullet : MonoBehaviour
{
    // Initialize
    Vector3 direction;
    Transform walkingEnemy;
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform rockBulletPile, player;

    void Awake()
    {
        // Get the game manager
        gameManager = FindObjectOfType<GameManager>();
        // Set game object to inactive
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        // If the parent of the rock is an walking enemy
        if (transform.parent.tag == "WalkingEnemy")
        {
            // Set the walking enemy to be the parent of the rock
            walkingEnemy = transform.parent;
        }
        // offset is the distance between the rock and the walking enemy should be
        Vector3 offset = walkingEnemy.forward;
        // Set the position of the rock
        transform.position = walkingEnemy.position + offset;
        // Bug here
        // Turn the rock to walking enemy's
        transform.rotation = walkingEnemy.rotation;
        // Bug here
        // Change the parent to something outside of the walking enemy
        transform.SetParent(rockBulletPile);
        // Remembers the original direction
        direction = (player.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
        // Move the rock to the direction that they should go
        gameObject.transform.position += transform.forward * 0.5f;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        // If the rock hits the player
        if (other.gameObject.tag == "Player")
        {
            // Decrease the number of health by damage, aka 1
            other.gameObject.GetComponent<PlayerStat>().health -= 1;
            // Ask the game manager to check health and update UI
            gameManager.CheckHealth();
            // Set the gameObject to inactive
            gameObject.SetActive(false);
        }
        // If the rock hits the enemy
        else if (other.gameObject.tag == "WalkingEnemy")
        {
            // Do nothing
        }
        // If it hits the mace or bow
        else if (other.gameObject.tag == "TwoHandedMace" || other.gameObject.tag == "bow")
        {
            // Do nothing
        }
        // Remarks: one handed sword can parry
        else
        {
            // Set the gameObject to inactive
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the rock hits the player
        if (collision.gameObject.tag == "Player")
        {
            // Decrease the number of health by damage, aka 1
            collision.gameObject.GetComponent<PlayerStat>().health -= 1;
            // Ask the game manager to check health and update UI
            gameManager.CheckHealth();
            // Set the gameObject to inactive
            gameObject.SetActive(false);
        }
        // If the rock hits the enemy
        else if (collision.gameObject.tag == "WalkingEnemy")
        {
            // Do nothing
        }
        // If it hits anything else
        else
        {
            // Set the gameObject to inactive
            gameObject.SetActive(false);
        }
    }
}
