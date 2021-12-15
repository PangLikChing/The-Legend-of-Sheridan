using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelChecker : MonoBehaviour
{
    void Awake()
    {
        PlayerPrefs.SetInt("fromBeginning", 1);
    }
}
