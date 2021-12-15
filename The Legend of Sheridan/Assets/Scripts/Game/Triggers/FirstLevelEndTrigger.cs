using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the next level trigger in the game scene
// This script is for letting the player to proceed to the next level

public class FirstLevelEndTrigger : MonoBehaviour
{
    // Initialize
    GameManager gameManager;
    // sceneChanger is the game object playing the scene changing animation
    [SerializeField] GameObject sceneChanger;

    void Start()
    {
        // Find the game manager
        gameManager = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        // If the player hit the end game trigger
        if (other.gameObject.tag == "Player")
        {
            // Play the scene changing animation maybe
            // Play the scene changing animation by setting it to active
            sceneChanger.SetActive(true);

            // Save player stat
            gameManager.SaveData();
        }
    }
}
