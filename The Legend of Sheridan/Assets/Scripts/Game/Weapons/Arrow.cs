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

    void OnEnable()
    {
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

    private void OnTriggerEnter(Collider other)
    {
        // Set the arrow to inactive
        gameObject.SetActive(false);
        Debug.Log("trigger");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Set the arrow to inactive
        gameObject.SetActive(false);
        Debug.Log("enter");
    }
}
