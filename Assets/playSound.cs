using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    public GameObject Dialogue;
    public AudioSource Dragon;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Dialogue.SetActive(true);
            if (!Dragon.isPlaying)
            {
                Dragon.Play();
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Dialogue.SetActive(false);
        }
    }
}
