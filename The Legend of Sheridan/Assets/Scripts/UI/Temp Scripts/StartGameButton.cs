using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script should be put on the start button in the main menu scene
// This script is for allowing the player to start the game
public class StartGameButton : MonoBehaviour
{
    // Initialize
    [SerializeField] KeyCode start;

    void Update()
    {
        if (Input.GetKeyDown(start))
        {
            // This should be the game scene
            SceneManager.LoadScene(1);
        }
    }
}
