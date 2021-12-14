using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// This script should be put on the walking enemies in the game scene
// This script is for allowing the enemy AI to chase the player
public class WalkingEnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 playerPosition;
    GameObject player;

    void Start()
    {
        // Initialize the agent, player and the player's position
        agent = gameObject.GetComponent<NavMeshAgent>();
        // Set the player to Zelda. The gmaeObject name of Zelda cannot be changed
        player = GameObject.Find("Zelda");
        playerPosition = player.GetComponent<Rigidbody>().position;
    }

    void FixedUpdate()
    {
        // Update the player's position
        playerPosition = player.GetComponent<Rigidbody>().position;
        // Ask the agent to go to the new playerPosition
        agent.SetDestination(playerPosition);
    }
}
