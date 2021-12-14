using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Initialize
    [SerializeField] GameObject heart1, heart2, heart3, gameOverMenu;
    [SerializeField] PlayerStat playerStat;
    int health;

    void Start()
    {
        // Initialize the health amount
        health = playerStat.health;
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
