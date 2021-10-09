using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class miniBoss : MonoBehaviour
{
    public Transform target;
    public Transform StartPos;//set target from inspector 
    public Transform player;
    public float speed = 3f;
    public float range;
    public int enemyHealth = 10;
    public PlayerMovement Dash; 
    public float minDistance = 2f;
    public Slider slider;

    public SpriteRenderer sR;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(transform.position, target.position);
        BossmMovement();
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void BossmMovement()
    {
        if (range > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            enemyHealth -= 2;
            setHealth(enemyHealth);
        }
        if (other.gameObject.tag == "Player" && Dash.Dashing == true)
        {
            enemyHealth -= 1;
            setHealth(enemyHealth);
        }
    }

    private void setHealth(int health)
    {
            slider.value = health;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.Rotate(new Vector3(0, 180, 0));
            target = StartPos;
            sR.color = Color.white;
            speed = 3f;
        }
        if (other.gameObject.tag == "BossStartPos")
        {
            transform.Rotate(new Vector3(0, 180, 0));
            sR.color = Color.red;
            target = player;
            speed = 6f;
        }
        
    }
}

