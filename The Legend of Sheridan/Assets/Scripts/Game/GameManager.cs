using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Initialize
    [SerializeField] Inventory playerInventory;
    [SerializeField] GameObject heart1, heart2, heart3, gameOverMenu;
    [SerializeField] Transform bow, quiver;
    [SerializeField] PlayerStat playerStat;
    [SerializeField] Image weaponImage;
    [SerializeField] List<Sprite> weaponSprites;
    int health;
    // Bool for checking if the player is starting the game from the beginning or not
    [SerializeField] bool fromBeginning;

    SoundManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Play("Main theme");

        // If we are from the beginning
        if (fromBeginning == true)
        {
            // Do nothing
        }
        // If we are loading a level
        else
        {
            // Load the data
            LoadData();
            // Adjust the arrow number
            int currentArrowNumber = bow.childCount;
            // If the there are difference between the default arrow number
            if (currentArrowNumber != playerInventory.arrowCount)
            {
                // If current arrow number is larger
                if (currentArrowNumber > playerInventory.arrowCount)
                {
                    // Get the difference between the 2
                    int difference = currentArrowNumber - playerInventory.arrowCount;

                    // Remove that much amount of arrows
                    for (int i = 0; i < difference; i++)
                    {
                        bow.GetChild(0).SetParent(quiver);
                    }
                }
                // If the arrowCount in inverntory is larger
                else if (playerInventory.arrowCount > currentArrowNumber)
                {
                    // Get the difference between the 2
                    int difference = playerInventory.arrowCount - currentArrowNumber;

                    // Add that much arrows to the bow
                    for (int i = 0; i < difference; i++)
                    {
                        bow.GetChild(0).SetParent(quiver);
                    }
                }
            }
        }
        health = playerStat.health;
    }

    void LoadData()
    {
        // Load data
        // Health
        playerStat.health = PlayerPrefs.GetInt("Health");
        // Set the current health UI to match the current health
        health = playerStat.health;
        CheckHealth();

        // Sword
        // If the player has 1 handed sword
        if (PlayerPrefs.GetInt("Has1HandedSword") == 1)
        {
            // Set has1HandedSword to true
            playerInventory.has1HandedSword = true;
        }
        // If they don't
        else
        {
            // Set has1HandedSword to false
            playerInventory.has1HandedSword = false;
        }

        // Mace
        // If the player has 2 handed mace
        if (PlayerPrefs.GetInt("Has2HandedMace") == 1)
        {
            // Set has2HandedMace to true
            playerInventory.has2HandedMace = true;
        }
        // If they don't
        else
        {
            // Set has2HandedMace to false
            playerInventory.has2HandedMace = false;
        }

        // Bow
        // If the player has a bow
        if (PlayerPrefs.GetInt("hasbow") == 1)
        {
            // Set hasbow to true
            playerInventory.hasbow = true;
        }
        // If they don't
        else
        {
            // Set hasbow to false
            playerInventory.hasbow = false;
        }

        // Arrow Count
        // Set the arrowCount as same as the data
        playerInventory.arrowCount = PlayerPrefs.GetInt("ArrowCount");

        // Key
        // If the player has the key
        if (PlayerPrefs.GetInt("hasKey") == 1)
        {
            // Set hasKey to true
            playerInventory.hasKey = true;
        }
        // If they don't
        else
        {
            // Set hasKey to false
            playerInventory.hasKey = false;
        }

        // Set weapon to the one previously used
        // Set the new weapon to active
        playerInventory.transform.GetChild(PlayerPrefs.GetInt("currentWeapon")).gameObject.SetActive(true);
        // Swap to the sprite of that weapon
        weaponImage.sprite = weaponSprites[PlayerPrefs.GetInt("currentWeapon")];
    }

    // Function to save player's stat
    public void SaveData()
    {
        // Set the health to the remaining health of the player
        PlayerPrefs.SetInt("Health", playerStat.health);

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

        // Current using weapon index
        // Find the weapon that the player is currently using
        for (int i = 0; i < playerInventory.transform.childCount; i++)
        {
            // If that weapon is active
            if (playerInventory.transform.GetChild(i).gameObject.activeSelf == true)
            {
                // Save that index
                PlayerPrefs.SetInt("currentWeapon", i);
            }
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
            // Play death sound
            soundManager.Play("Hero dying");
            // Play death animation
        }
    }
}
