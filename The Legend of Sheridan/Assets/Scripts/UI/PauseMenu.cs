using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the game manager in the game scene
// This script is for getting the user input for pausing the game
// and pause the game when the player hit the pause the game
public class PauseMenu : MonoBehaviour
{
    // Initialize
    // Set pause key here. Change it to gamepad later
    [SerializeField] KeyCode pause;
    // The pause menu gameObject
    [SerializeField] GameObject pauseMenu;

    public bool isGameOver = false;

    void Start()
    {
        // Initalize PauseMenu state at start to inactive
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        // If the pause key is pressed and the pause menu is not currently active
        if (Input.GetKeyDown(pause) && pauseMenu.activeSelf == false && isGameOver == false)
        {
            // Call the PauseGame function
            PauseGame();
        }
        // If the pause key is pressed and the pause menu is currently active
        else if (Input.GetKeyDown(pause) && pauseMenu.activeSelf == true && isGameOver == false)
        {
            // Call the ContinueGame function
            ContinueGame();
        }
    }

    void PauseGame()
    {
        // Set the game time to 0, which means pausing the game time
        Time.timeScale = 0;
        // Set the pause menu to active
        pauseMenu.SetActive(true);
    }

    void ContinueGame()
    {
        // Set the game time to 1, which means normal speed
        Time.timeScale = 1;
        // Set the pause menu to inactive
        pauseMenu.SetActive(false);
    }
}
