using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class activateObjects : MonoBehaviour
{

    public GameObject cs;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            cs.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        cs.SetActive(false);
    }
}
