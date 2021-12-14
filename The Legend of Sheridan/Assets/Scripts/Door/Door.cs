using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform DoorLeft;
    public Transform DoorRight;

    float doorLeftPosZ;
    float doorRightPosZ;

    bool openDoor = false;

    // Start is called before the first frame update
    void Start()
    {
        doorLeftPosZ = DoorLeft.position.z;
        doorRightPosZ = DoorRight.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoor)
        {
            DoorLeft.position = Vector3.Lerp(DoorLeft.transform.position, new Vector3(DoorLeft.transform.position.x, DoorLeft.transform.position.y, doorLeftPosZ - 1.5f), 10f);
            DoorRight.position = Vector3.Lerp(DoorRight.transform.position, new Vector3(DoorRight.transform.position.x, DoorRight.transform.position.y, doorRightPosZ + 1.5f), 10f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Zelda")
        {
            if (other.gameObject.GetComponent<Inventory>().hasKey == true)
            {
                openDoor = true;
            }
        }
    }
}
