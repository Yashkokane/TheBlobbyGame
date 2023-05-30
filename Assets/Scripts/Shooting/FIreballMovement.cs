using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreballMovement : MonoBehaviour
{
    public int HurtValue;
    [SerializeField] private Vector2 projectileSpeed;
    //private Enemy Enemy;
    public Rigidbody2D rbody;
    private HealthManager _healthManager;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        _healthManager = GetComponent<HealthManager>();
    }
    // Update is called once per frame
    void Update()
    {
        rbody.velocity = projectileSpeed;
        Destroy(gameObject, 3f);
            
    }
    /*private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _healthManager.HurtPlayer(5);
            Destroy(gameObject);
            
            //Debug.Log("player hit");
        }
        else
        {
            Destroy(gameObject, 3f);
        }
        
        if (other.gameObject.tag == "invisHero" || other.gameObject.tag =="Hero_enemy1" ||other.gameObject.tag =="Hero_enemy2")
        {
            Physics.IgnoreCollision(player.GetComponent<Collider>(),GetComponent<Collider>());
        }
    }*/

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //_healthManager.HurtPlayer(HurtValue);
            Destroy(gameObject);
            
            //Debug.Log("player hit");
        }
        else
        {
            Destroy(gameObject, 3f);
        }
        
        if (other.gameObject.tag == "invisHero" || other.gameObject.tag =="Hero_enemy1" ||other.gameObject.tag =="Hero_enemy2")
        {
            Physics.IgnoreCollision(player.GetComponent<Collider>(),GetComponent<Collider>());
        }
    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }*/
}
