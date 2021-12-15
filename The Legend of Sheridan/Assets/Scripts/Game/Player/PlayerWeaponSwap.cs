using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script should be added to the player in the game scene
// This script is for managing the player's weapon swapping

public class PlayerWeaponSwap : MonoBehaviour
{
    //test key
    [SerializeField] KeyCode swapRight, swapLeft;
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject player;
    [SerializeField] Image weaponImage;
    [SerializeField] List<Sprite> weaponSprites;
    int currentWeapon = 0;
    // The order of this list cannot be changed. Should be the same order as the player's weapon in the scene
    bool[] weapons = new bool[3];


    // Function to get the current weapon list
    void GetWeaponList()
    {
        weapons[0] = inventory.has1HandedSword;
        weapons[1] = inventory.has2HandedMace;
        weapons[2] = inventory.hasbow;
    }

    void SwapWeapon(int _index)
    {
        // Set the old weapon to inactive
        player.transform.GetChild(currentWeapon).gameObject.SetActive(false);
        // Set the new weapon to active
        player.transform.GetChild(_index).gameObject.SetActive(true);
        // Swap to the sprite of that weapon
        weaponImage.sprite = weaponSprites[_index];
    }

    void Start()
    {
        // Initialize the array
        GetWeaponList();
    }

    void Update()
    {
        // If the player hits the swap left key
        if (Input.GetKeyDown(swapLeft))
        {
            // Get the new bool
            GetWeaponList();

            // Hardcoding this...i don't know how to do this
            // This is to get the current using weapon
            for (int i = 0; i < player.transform.childCount; i++)
            {
                // If that weapon is active
                if (player.transform.GetChild(i).gameObject.activeSelf == true)
                {
                    // Get that weapon index
                    currentWeapon = i;
                }
                // If that weapon is inactive
                else
                {
                    // Do nothing
                }
            }

            // If current weapon is the last weapon in weapons list
            if (currentWeapon == weapons.Length - 1)
            {
                // Check until the first element in weapons list
                for (int i = currentWeapon - 1; i > -1; i--)
                {
                    // If that weapon is in the inventory
                    if (weapons[i] == true)
                    {
                        // Swap to waepon i
                        SwapWeapon(i);
                        // Break out of the loop
                        break;
                    }
                }
            }
            // If the current weapon is not the last wepaon in the list
            else
            {
                // Making a temporary bool to check if the weapon is swapped
                bool swapped = false;
                // Starting from itself, check the previous weapon and see if it is active
                for (int i = currentWeapon - 1; i > -1; i--)
                {
                    // If it is active
                    if (weapons[i] == true)
                    {
                        // Swap to waepon i
                        SwapWeapon(i);
                        // Set the temporary bool to true
                        swapped = true;
                        // Break out of the loop
                        break;
                    }
                }
                // If the weapon is not swapped after the first for loop
                if (swapped == false)
                {
                    // Check from the last of weapons until itself
                    for (int i = weapons.Length - 1; i > currentWeapon; i--)
                    {
                        // If it is active
                        if (weapons[i] == true)
                        {
                            // Swap to waepon i
                            SwapWeapon(i);
                            // Break out of the loop
                            break;
                        }
                    }
                }
            }
        }

        // If the player hits the swap right key
        if (Input.GetKeyDown(swapRight))
        {
            // Get the new bool
            GetWeaponList();

            // Hardcoding this...i don't know how to do this
            // This is to get the current using weapon
            for (int i = 0; i < player.transform.childCount; i++)
            {
                // If that weapon is active
                if (player.transform.GetChild(i).gameObject.activeSelf == true)
                {
                    // Get that weapon index
                    currentWeapon = i;
                }
                // If that weapon is inactive
                else
                {
                    // Do nothing
                }
            }

            // If the current weapon is the last weapon in the list
            if (currentWeapon == weapons.Length - 1)
            {
                // Check first
                for (int i = 0; i < weapons.Length; i++)
                {
                    if (weapons[i] == true)
                    {
                        // Swap to waepon i
                        // Set the old weapon to inactive
                        SwapWeapon(i);
                        // Break out of the loop
                        break;
                    }
                }
            }
            // If the current weapon is not the last wepaon in the list
            else
            {
                // Making a temporary bool to check if the weapon is swapped
                bool swapped = false;
                // starting from itself, check the next weapon and see if it is active
                for (int i = currentWeapon + 1; i < weapons.Length; i++)
                {
                    // If it is active
                    if (weapons[i] == true)
                    {
                        // Swap to waepon i
                        SwapWeapon(i);
                        // Set the temporary bool to true
                        swapped = true;
                        // Break out of the loop
                        break;
                    }
                }
                // If the weapon is not swapped after the first for loop
                if (swapped == false)
                {
                    // Check from the start of weapons until itself
                    for (int i = 0; i < currentWeapon; i++)
                    {
                        // If it is active
                        if (weapons[i] == true)
                        {
                            // Swap to waepon i
                            SwapWeapon(i);
                            // Break out of the loop
                            break;
                        }
                    }
                }
            }
        }
    }
}
