using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be put on the arrow in the game scene
// This script is for managing the arrows' behaviour

public class Arrow : MonoBehaviour
{
    // direction is for getting the original direction
    Vector3 direction;
    // arrows should be a empty game object that is not a child of the player
    [SerializeField] Transform quiver;
    Transform bow;

    void Awake()
    {
        // If the parent of the arrow is a bow
        if (transform.parent.tag == "Bow")
        {
            // Set the bow to be the parent of the arrow
            bow = transform.parent;
        }
    }

    void OnEnable()
    {
        // offset is the distance between the bow and the arrow should be
        Vector3 offset = bow.forward;
        // Set the position of the arrow
        transform.position = bow.position + offset;
        // Remembers the original direction
        direction = transform.forward;
        // Change the parent to something outside of the bow
        transform.SetParent(quiver);
    }

    void FixedUpdate()
    {
        // Move the arrow to the direction that they should go
        gameObject.transform.Translate(direction * -0.5f, Space.Self);
    }

    // If the arrow hits anything other than the player and the bow
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bow" || other.gameObject.tag == "RockBullet")
        {
            // Do nothing
        }
        else
        {
            // Set the arrow to inactive
            gameObject.SetActive(false);
        }
    }

    // If the arrow hits anything other than the player and the bow
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bow")
        {
            // Do nothing
        }
        else
        {
            // Set the arrow to inactive
            gameObject.SetActive(false);
        }
    }
}
