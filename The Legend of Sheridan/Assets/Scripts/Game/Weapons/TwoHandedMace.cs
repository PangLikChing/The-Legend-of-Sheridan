using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the player in the game scene
// This script is for getting the user input for attacking with a 2 handed mace

public class TwoHandedMace : MonoBehaviour
{
    // Temp key. Change when using gamepad
    [SerializeField] KeyCode attack;

    void Update()
    {
        // If the player press the attack button
        if (Input.GetKeyDown(attack))
        {
            // Play the attack animation
            transform.GetComponent<Animation>().Play();

            // Attack with the weapon
            Debug.Log("Attack");
        }
    }
}
