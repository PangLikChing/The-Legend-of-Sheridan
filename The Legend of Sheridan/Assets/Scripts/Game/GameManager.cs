using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Initialize
    [SerializeField] Inventory playerInventory;
    [SerializeField] GameObject heart1, heart2, heart3, gameOverMenu;
    [SerializeField] Transform bow;
    [SerializeField] PlayerStat playerStat;
    int health;

    void Start()
    {
        // Initialize the health amount
        health = playerStat.health;
        // test
        Debug.Log("Health: " + PlayerPrefs.GetInt("Health"));
        Debug.Log("Has1HandedSword: " + PlayerPrefs.GetInt("Has1HandedSword"));
        Debug.Log("Has2HandedMace: " + PlayerPrefs.GetInt("Has2HandedMace"));
        Debug.Log("hasbow: " + PlayerPrefs.GetInt("hasbow"));
        Debug.Log("ArrowCount: " + PlayerPrefs.GetInt("ArrowCount"));
        Debug.Log("hasKey: " + PlayerPrefs.GetInt("hasKey"));
        // test
    }

    // Function to save player's stat
    public void SaveData()
    {
        // Set the health to the remaining health of the player
        PlayerPrefs.SetInt("Health", health);

        // If the player has 1 handed sword
        if (playerInventory.has1HandedSword == true)
        {
            // Set Has1HandedSword to true
            PlayerPrefs.SetInt("Has1HandedSword", 1);
        }
        // If the player doesn't have 1 handed sword
        else
        {
            // Set Has1HandedSword to false
            PlayerPrefs.SetInt("Has1HandedSword", 0);
        }

        // If the player has 2 handed mace
        if (playerInventory.has2HandedMace == true)
        {
            // Set Has2HandedMace to true
            PlayerPrefs.SetInt("Has2HandedMace", 1);
        }
        // If the player doesn't have 2 handed mace
        else
        {
            // Set Has2HandedMace to false
            PlayerPrefs.SetInt("Has2HandedMace", 0);
        }

        // If the player has bow
        if (playerInventory.hasbow == true)
        {
            // Set bow to true
            PlayerPrefs.SetInt("hasbow", 1);
        }
        // If the player doesn't have bow
        else
        {
            // Set hasbow to false
            PlayerPrefs.SetInt("hasbow", 0);
        }

        // Save the remaining arrow count of the player
        PlayerPrefs.SetInt("ArrowCount", bow.childCount);

        // If the player has the key
        if (playerInventory.hasKey == true)
        {
            // Set hasKey to true
            PlayerPrefs.SetInt("hasKey", 1);
        }
        // If the player doesn't have the key
        else
        {
            // Set hasbow to false
            PlayerPrefs.SetInt("hasKey", 0);
        }

        // Save all of the modified data
        PlayerPrefs.Save();
    }

    // Function to update the health UI
    public void CheckHealth()
    {
        // Get the current health amount
        health = playerStat.health;

        // If 2 health remaining
        if (health == 2)
        {
            // Set the first heart to inactive but the last 2 active
            heart1.SetActive(false);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        // If 1 health remaining
        if (health == 1)
        {
            // Set the 2 hearts to inactive but the last one active
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(true);
        }
        // If below 0 remaining
        if (health <= 0)
        {
            // Set the all hearts to inactive
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);

            // Display Gameover menu
            gameOverMenu.SetActive(true);
            // Play death animation
        }
    }
}
