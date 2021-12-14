using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the player in the game scene
// This script is for managing the player's inventory

public class Inventory : MonoBehaviour
{
    // Initialize
    public bool hasKey = false;
    public bool has1HandedSword = false;
    public bool has2HandedMace = true;
    public bool hasbow = false;
    public int arrowCount = 0;

    void Start()
    {
        // Initialize the state of inventory on start just to be safe
        hasKey = false;
        has1HandedSword = false;
        has2HandedMace = true;
        hasbow = false;
        arrowCount = 0;
    }
}
