using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the player in the game scene
// This script is for managing the player's inventory

public class Inventory : MonoBehaviour
{
    // Initialize
    public bool hasKey = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the state of inventory on start
        hasKey = false;   
    }
}
