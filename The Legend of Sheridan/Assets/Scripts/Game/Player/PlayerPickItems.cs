using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the play in the game scene
// This script is to manage all pickups for the player

public class PlayerPickItems : MonoBehaviour
{
    GameObject player;
    
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Play("Main theme");

        player = gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player hits the key
        if (other.gameObject.tag == "Key")
        {
            // Set the key gameObject to inactive
            other.gameObject.SetActive(false);
            // Put the key to the inventory
            player.GetComponent<Inventory>().hasKey = true;
            soundManager.Play("Pick up item");
        }
        // If the player reaches a rock
        if (other.gameObject.tag == "Rock")
        {
            // Set the rock to inactive
            other.gameObject.SetActive(false);
            soundManager.Play("Pick up item");
        }
        // If the player hits the one handed sword
        if (other.gameObject.tag == "OneHandedSword")
        {
            // Set the weapon to inactive
            other.gameObject.SetActive(false);
            // Put the weapon to the inventory
            player.GetComponent<Inventory>().has1HandedSword = true;
            soundManager.Play("Pick up item");
        }
        // If the player hits the bow
        if (other.gameObject.tag == "Bow")
        {
            // Set the weapon to inactive
            other.gameObject.SetActive(false);
            // Put the weapon to the inventory
            player.GetComponent<Inventory>().hasbow = true;
            soundManager.Play("Pick up item");
        }
    }
}
