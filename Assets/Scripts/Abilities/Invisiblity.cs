using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Invisiblity : MonoBehaviour
{
    private Invisiblity HeroInvis;
    //public bool active;
    //public float startTime;
    private Text theText;
    private PlayerMovement pM;
    
    [SerializeField] float startTime = 10;
    public float timer = 10;
    
    //public GameObject Timetext;
    public SpriteRenderer heroS;
    public bool canInvis;
    public bool isInvis;
    private Color colS;
    //[SerializeField] GameObject text;
    //[SerializeField] SpriteRenderer[] HeroB;
    //[SerializeField] Color[] colorB;
    
    private potionCollection pC;
    
    private void Start()
    {
        heroS = GetComponentInChildren<SpriteRenderer>();
        colS = heroS.color;
        /*for (int i = 0; i < HeroB.Length; i++)
        {
            colorB[i] = HeroB[i].color;
        }*/
        pC = FindObjectOfType<potionCollection>();
        pM = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        PotionCheck();
        if (isInvis == true)
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
                gameObject.tag = "invisHero";
                colS.a = 0.5f;
                heroS.color = colS;
                isInvis = true;
                SetTimer();
                StartCoroutine(MyMethod());
            }
            else if (PlayerMovement.p_level2)
            {
                gameObject.tag = "invisHero";
                /*for (int i = 0; i < HeroB.Length; i++)
                {
                    colorB[i].a = 0.5f;
                    HeroB[i].color = colorB[i];
                }
                colorB[1].a = 0.3f;
                HeroB[1].color = colorB[1];
                colorB[5].a = 0.3f;
                HeroB[5].color = colorB[5];*/
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
                colS.a = 1f;
                heroS.color = colS;
                isInvis = false;
                gameObject.tag = "Player";
                //Debug.Log("invis off"); 
            }
            else if (PlayerMovement.p_level2)
            {
                /*for (int i = 0; i < HeroB.Length; i++)
                {
                    colorB[i].a = 1f;
                    HeroB[i].color = colorB[i];
                }*/
                isInvis = false;
                gameObject.tag = "Player";
            }
        }
    }

    public void PotionCheck()
    {
        if (potionCollection.potion_B_Count >= 50)
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
                 //text.SetActive(true);
                 timer -= Time.deltaTime;
                 //theText.text = "Time: " + timer.ToString("F0");
             }
             else if (timer <= 0)
             {
                 //text.SetActive(false);
                 isInvis = false;
                 canInvis = false;
                 heroInvis();
                 //pM.active = false;
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
