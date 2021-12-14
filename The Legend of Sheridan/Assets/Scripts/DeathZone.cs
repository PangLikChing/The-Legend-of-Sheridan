using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject gameOverMenu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.GetComponent<PauseMenu>().isGameOver = true;
            gameOverMenu.SetActive(true);
        }
    }
}
