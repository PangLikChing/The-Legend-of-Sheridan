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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Key")
        {
            collision.gameObject.SetActive(false);
            Zelda.GetComponent<Inventory>().hasKey = true;
        }
        if (collision.transform.tag == "Weapon")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
