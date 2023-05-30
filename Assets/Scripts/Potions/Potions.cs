using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{
    private potionCollection Pc;
    public AudioSource Drink;
    private void Start()
    {
        Pc = GetComponent<potionCollection>();
        //DontDestroyOnLoad(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        switch (gameObject.tag)
        {
            case "PotionRed":
                potionCollection.UpdateRedCount();
                if (!Drink.isPlaying)
                {
                    Drink.Play();
                }
                Destroy(gameObject);
                break;
            case "PotionBlue":
                potionCollection.UpdateBlueCount();
                if (!Drink.isPlaying)
                {
                    Drink.Play();
                }
                Destroy(gameObject);
                break;
        }
    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player hit");
          
        }
    }*/
}
