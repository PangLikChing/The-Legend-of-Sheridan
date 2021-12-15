using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// This script should be put on the walking enemies in the game scene
// This script is for allowing the enemy AI to chase the player
public class WalkingEnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 playerPosition, rockPosition;
    GameObject player;
    [SerializeField] GameObject rocks;

    void Start()
    {
        // Initialize the agent, player and the player's position
        agent = gameObject.GetComponent<NavMeshAgent>();
        // Set the player to Zelda. The gmaeObject name of Zelda cannot be changed
        player = GameObject.Find("Zelda");
        playerPosition = player.GetComponent<Rigidbody>().position;

        // Set the first rock's position
        rockPosition = rocks.transform.GetChild(0).GetComponent<Rigidbody>().position;
    }

    void FixedUpdate()
    {
        // If the enemy has a rock
        if (gameObject.GetComponent<WalkingEnemy>().hasRock == true)
        {
            // Update the player's position
            playerPosition = player.GetComponent<Rigidbody>().position;
            // Ask the agent to go to the new playerPosition
            agent.SetDestination(playerPosition);
        }
        // If the enemy doesn't have a rock
        else
        {
            // rockActive is the first rock in the rocks list that is still active
            int rockActive = -1;
            // Loop through the rocks list
            for (int i = 0; i < rocks.transform.childCount; i++)
            {
                // If the children is active
                if (rocks.transform.GetChild(i).gameObject.activeSelf == true)
                {
                    // Set rockActive to that rock
                    rockActive = i;
                    // Break out of the for loop
                    break;
                }
            }

            // If there is still a rock
            if (rockActive >= 0)
            {
                // Update the rock's position
                rockPosition = rocks.transform.GetChild(rockActive).gameObject.GetComponent<Rigidbody>().position;
                // Move to the rock
                agent.SetDestination(rockPosition);
            }
            // If there is no rock left
            else
            {
                // Update the player's position
                playerPosition = player.GetComponent<Rigidbody>().position;
                // Ask the agent to go to the new playerPosition
                agent.SetDestination(playerPosition);
            }
        }
    }
}
