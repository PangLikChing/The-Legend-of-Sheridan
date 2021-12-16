using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script should be put on the play in the game scene
// This script is to manage all pickups for the player

public class PlayerPickItems : MonoBehaviour
{
    GameObject player;
    SoundManager soundManager;
    [SerializeField] TMP_Text pickupText;

    void PickUpItems(string _itemName)
    {
        // Play the pickup item sound
        soundManager.Play("Pick up item");
        // Show the pickup item text
        pickupText.text = "Picked up:\n" + _itemName;
        // Reset the gameObject just in case
        pickupText.gameObject.SetActive(false);
        // Set the gameObject to active, which will play the animation
        pickupText.gameObject.SetActive(true);
    }

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
            // Play the effects for picking up items
            PickUpItems(other.gameObject.name);
        }
        // If the player reaches a rock
        if (other.gameObject.tag == "Rock")
        {
            // Set the rock to inactive
            other.gameObject.SetActive(false);
            // Play the effects for picking up items
            PickUpItems("Rock");
        }
        // If the player hits the one handed sword
        if (other.gameObject.tag == "OneHandedSword")
        {
            // Set the weapon to inactive
            other.gameObject.SetActive(false);
            // Put the weapon to the inventory
            player.GetComponent<Inventory>().has1HandedSword = true;
            // Play the effects for picking up items
            PickUpItems(other.gameObject.name);
        }
        // If the player hits the bow
        if (other.gameObject.tag == "Bow")
        {
            // Set the weapon to inactive
            other.gameObject.SetActive(false);
            // Put the weapon to the inventory
            player.GetComponent<Inventory>().hasbow = true;
            // Play the effects for picking up items
            PickUpItems(other.gameObject.name);
        }
    }
}
