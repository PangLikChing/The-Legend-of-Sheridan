using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the player in the game scene
// This script is for getting the user input for attacking with a 2 handed mace

public class TwoHandedMace : MonoBehaviour
{
    SoundManager soundManager;

    void Start()
    {
        // Initialize
        soundManager = FindObjectOfType<SoundManager>();
    }

    void setIsAttackingToFalse()
    {
        transform.parent.GetComponent<Attack>().isAttacking = false;
    }

    void setIsAttackingToTrue()
    {
        transform.parent.GetComponent<Attack>().isAttacking = true;
        // Play the attacking sound
        soundManager.Play("Two hand sword");
    }
}
