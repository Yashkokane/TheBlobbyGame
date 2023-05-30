using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Hero_enemy1" ||other.gameObject.tag == "Hero_enemy2"||other.gameObject.tag == "invisHero")
        {
            HealthManager.instance.ResetHealth();
        }
    }
}
