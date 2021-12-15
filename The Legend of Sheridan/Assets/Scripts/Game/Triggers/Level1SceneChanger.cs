using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script should be put on the Scene Changer in the game scene
// This script is for checking loading other level

public class Level1SceneChanger : MonoBehaviour
{
    // Function for loading a level
    // _index is the build index for the target level
    void LoadLevel(int _index)
    {
        // Load next level
        SceneManager.LoadScene(_index);
    }
}
