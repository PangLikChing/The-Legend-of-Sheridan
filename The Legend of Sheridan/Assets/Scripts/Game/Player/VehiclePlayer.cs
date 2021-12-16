using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclePlayer : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DungeonRock")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
