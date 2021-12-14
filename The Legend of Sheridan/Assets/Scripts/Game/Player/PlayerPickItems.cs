using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickItems : MonoBehaviour
{
    GameObject Zelda;
    // Start is called before the first frame update
    void Start()
    {
        Zelda = GameObject.Find("Zelda");
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player hits the key
        if (other.transform.tag == "Key")
        {
            // Set the key gameObject to inactive
            other.gameObject.SetActive(false);
            // Put the key to the inventory
            Zelda.GetComponent<Inventory>().hasKey = true;
        }
        // If the player hits the one handed sword
        if (other.transform.tag == "OneHandedSword")
        {
            // Set the weapon to inactive
            other.gameObject.SetActive(false);
            // Put the weapon to the inventory
            Zelda.GetComponent<Inventory>().has1HandedSword = true;
        }
    }
}
