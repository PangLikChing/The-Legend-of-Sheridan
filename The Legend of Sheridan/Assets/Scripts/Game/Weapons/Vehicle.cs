using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] GameObject cameraFollow, player, vehiclePlayer;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Mount the player
            // Set player to inactive
            player.SetActive(false);
            // Set vehiclePlayer to active
            vehiclePlayer.SetActive(true);
            // Set the camera to follow the vehicle
            cameraFollow.GetComponent<FollowPlayer>().Player = vehiclePlayer;
            // Set gameObject to inactive
            gameObject.SetActive(false);
        }
    }
}
