using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script should be put on the restart button in the gameober menu UI in the game scene
// This script is for reloading the scene
public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        // Get the current scene number
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneNumber);

        // Reload the current scene
        SceneManager.LoadScene(sceneNumber);
    }
}
