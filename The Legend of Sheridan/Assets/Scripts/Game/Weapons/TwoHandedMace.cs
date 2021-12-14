using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the player in the game scene
// This script is for getting the user input for attacking with a 2 handed mace

public class TwoHandedMace : MonoBehaviour
{
    void setIsAttackingToFalse()
    {
        transform.parent.GetComponent<Attack>().isAttacking = false;
    }

    void setIsAttackingToFTrue()
    {
        transform.parent.GetComponent<Attack>().isAttacking = true;
    }
}
