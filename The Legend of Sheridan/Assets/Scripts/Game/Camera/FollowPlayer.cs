using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    public Vector3 CameraInitialPosition;
    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + CameraInitialPosition;
    }
}
