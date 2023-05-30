using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Invisiblity : MonoBehaviour
{
    public static Invisiblity instance;
    //public bool active;
    //public float startTime;
    private Text theText;
    private PlayerMovement pM;
    
    [SerializeField] float startTime = 10;
    public float timer = 10;

    public GameObject blob;
    public GameObject player;
    public GameObject hero;
    //public GameObject Timetext;
    public SpriteRenderer heroS;
    public SpriteRenderer heroB;
    public bool canInvis;
    public static bool isInvis;
    //private Color colS;
    //private Color colB;
    public Animator anim_s;
    public Animator anim_B;
    
    private potionCollection pC;
    
    private void Start()
    {
        //heroS = GetComponentInChildren<SpriteRenderer>();
        //GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.2f);
        //colS = heroS.color;
        pC = FindObjectOfType<potionCollection>();
        pM = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        PotionCheck();
        if (isInvis)
        {
            startTimer();
        }
    }
    
    public void heroInvis()
    {
        if (canInvis && isInvis == false)
        {
            if (PlayerMovement.p_level1)
            {
                //Debug.Log("hit");
                anim_s.SetTrigger("GoInvis");
                player.tag = "invisHero";
                blob.tag = "invisHero";
                heroS.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.5f);
                heroS.GetComponent<SpriteRenderer>().sortingOrder = -1;
                //colS.a = 0.2f;
                //heroS.color = colS;
                //Debug.Log(heroS.color);
                isInvis = true;
                SetTimer();
                StartCoroutine(MyMethod());
            }
            else if (PlayerMovement.p_level2)
            {
                anim_B.SetTrigger("GoInvis");
                player.tag = "invisHero";
                hero.tag = "invisHero";
                //gameObject.layer = 13;
                heroB.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.5f);;
                isInvis = true;
                SetTimer();
                StartCoroutine(MyMethod());
            }
        }
        else if (pM.active == false)
        {
            isInvis = false;
            canInvis = false;
            gameObject.tag = "Player";
        }
        else if(canInvis == false && isInvis == false)
        {
            if (PlayerMovement.p_level1)
            {
                anim_s.SetTrigger("OverInvis") ;
                heroS.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
                heroS.GetComponent<SpriteRenderer>().sortingOrder = 0;
                isInvis = false;
                player.tag = "Player";
                blob.tag ="Player";
           
            }
            else if (PlayerMovement.p_level2)
            {
                /*colB.a = 1f;
                heroB.color = colB;*/
                anim_B.SetTrigger("OverInvis");
                heroB.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
                isInvis = false;
                player.tag = "Player";
                hero.tag = "Player";
                //gameObject.layer = 8;
            }
        }
    }

    public void PotionCheck()
    {
        if (potionCollection.potion_B_Count >= 30)
        {
            canInvis = true;
        }
        else if (isInvis)
        {
            canInvis = true;
        }
        else
        {
            canInvis = false;
        }
    }

    public void startTimer()
     {
         if (timer >= 0)
         {
             timer -= Time.deltaTime;
         }
         else if (timer <= 0)
         {
             isInvis = false;
             canInvis = false;
             heroInvis();
         }
     }
    
    
    IEnumerator MyMethod() {
        
        for (float i = timer; i >= 0; i--)
        {
            if (isInvis)
            {
                potionCollection.BReduceCount();
                yield return new WaitForSeconds(1);
            }
            else
            {
                break;
            }
            
        }
        
    }
    public void SetTimer()
    {
        timer = startTime;
    }

   
}
