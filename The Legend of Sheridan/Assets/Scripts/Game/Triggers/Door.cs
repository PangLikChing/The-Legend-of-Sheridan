using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the Door Trigger in the game scene
// This script is for checking if the player has a key and open the door for the player

public class Door : MonoBehaviour
{
    // Initialize
    [SerializeField] Transform DoorLeft;
    [SerializeField] Transform DoorRight;

    float doorLeftPosZ;
    float doorRightPosZ;

    bool openDoor = false;

    void Start()
    {
        // Initialize the left and right doors' position Z
        doorLeftPosZ = DoorLeft.position.z;
        doorRightPosZ = DoorRight.position.z;
    }

    void Update()
    {
        // If openDoor is true
        if (openDoor == true)
        {
            // "Open" the door for player with change in positions
            DoorLeft.position = Vector3.Lerp(DoorLeft.transform.position, new Vector3(DoorLeft.transform.position.x, DoorLeft.transform.position.y, doorLeftPosZ - 1.5f), 10f);
            DoorRight.position = Vector3.Lerp(DoorRight.transform.position, new Vector3(DoorRight.transform.position.x, DoorRight.transform.position.y, doorRightPosZ + 1.5f), 10f);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // If Zelda hits the trigger zone
        if (other.gameObject.name == "Zelda")
        {
            // If Zelda has the key in his inventory
            if (other.gameObject.GetComponent<Inventory>().hasKey == true)
            {
                // Set openDoor to true
                openDoor = true;
            }
        }
    }
}
