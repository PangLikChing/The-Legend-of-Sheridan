using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the next level trigger in the game scene
// This script is for letting the player to proceed to the next level

public class FirstLevelEndTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // If the player hit the end game trigger
        if (other.gameObject.tag == "Player")
        {
            // Play some animation maybe

            // Load next level
            Debug.Log("Next level");
        }
    }
}
