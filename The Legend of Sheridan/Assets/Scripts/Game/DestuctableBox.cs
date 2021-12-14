using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestuctableBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TwoHandedMace")
        {
            gameObject.SetActive(false);
        }
    }
}
