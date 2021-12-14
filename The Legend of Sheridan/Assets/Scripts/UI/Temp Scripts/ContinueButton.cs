using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the continue button in the pause menu UI in the game scene
// This script is for resuming the game from pausing
public class ContinueButton : MonoBehaviour
{
    // The pause menu gameObject
    [SerializeField] GameObject pauseMenu;

    public void ContinueButtonPressed()
    {
        // Call the ContinueGame function
        ContinueGame();
    }
    void ContinueGame()
    {
        // Set the game time to 1, which means normal speed
        Time.timeScale = 1;
        // Set the pause menu to inactive
        pauseMenu.SetActive(false);
    }
}
