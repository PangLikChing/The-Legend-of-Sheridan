using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the destructable box
// This script is for checking if the box should be destructed or not
public class DestructableBox : MonoBehaviour
{
    // On every triiger enter
    private void OnTriggerEnter(Collider other)
    {
        // If the trigger object is a Two handed Mace and the player is currently attacking
        if (other.gameObject.tag == "TwoHandedMace" && other.transform.parent.GetComponent<Attack>().isAttacking == true)
        {
            // Break the box
            gameObject.SetActive(false);
            // Play box destroy sound effect
        }
    }
}
