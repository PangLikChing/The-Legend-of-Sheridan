using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Victory : MonoBehaviour
{
    [SerializeField] GameObject victoryMenu;
    void OnTriggerEnter(Collider other)
    {
        // Show victory menu
        victoryMenu.SetActive(true);
        // Disable Control
        Time.timeScale = 0;
    }
}
