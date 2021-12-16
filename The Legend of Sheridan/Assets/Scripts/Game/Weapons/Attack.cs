using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the player in the game scene
// This script is for getting the user input for attacking

public class Attack : MonoBehaviour
{
    // Temp key. Change when using gamepad
    [SerializeField] KeyCode attack;
    public bool isAttacking = false;

    SoundManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Play("Main theme");
    }
        void Update()
    {
        // If the player press the attack button
        if (Input.GetKeyDown(attack))
        {
            // Loop though the weapon child list
            for (int i = 0; i < transform.childCount; i++)
            {
                // If a weapon is currently active
                if (transform.GetChild(i).gameObject.activeSelf == true)
                {
                    // If that weapon is not a bow
                    if (transform.GetChild(i).gameObject.tag != "Bow")
                    {
                        // Play the weapon attack animation
                        transform.GetChild(i).gameObject.GetComponent<Animation>().Play();
                        // If it is not attacking currently and if it is attacking with 1 handed sword
                        if (isAttacking == false && transform.GetChild(i).gameObject.tag == "OneHandedSword")
                        {
                            // Play the attack sound
                            soundManager.Play("Two hand sword");
                        }
                    }
                    // If that is a bow
                    else
                    {
                        soundManager.Play("Arrow");
                        soundManager = FindObjectOfType<SoundManager>();

                        // If there are still arrows avalible
                        if (transform.GetChild(i).gameObject.transform.childCount != 0)
                        {
                            // Set the next arrow to active
                            transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        }
                    }
                    // Break out of the for loop
                    break;
                }
            }

            // Attack with the weapon
            Debug.Log("Attack");
        }
    }
}
