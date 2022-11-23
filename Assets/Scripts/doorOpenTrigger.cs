using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpenTrigger : MonoBehaviour
{
    [SerializeField] private GameObject door2;
    [SerializeField] private GameObject door1;
    [SerializeField] private AudioClip doorMoveSound;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {   if (other.tag == "Player")
        {
            playSound();
            door1.GetComponent<Animation>().Play("openDoor1");
            door2.GetComponent<Animation>().Play("openDoor2");
        }
    
    }
    private void playSound()
    {
        audioSource.PlayOneShot(doorMoveSound);
    }

    private void OnTriggerExit(Collider other)
     {
       
      
            if (other.tag == "Player")
            {
            if (audioSource.isPlaying) Invoke("playSound", 0.2f);
            else
            {   playSound();
                
            }
            door1.GetComponent<Animation>().PlayQueued("closeDoor1");
            door2.GetComponent<Animation>().PlayQueued("closeDoor2");
        }
      
     }
}
