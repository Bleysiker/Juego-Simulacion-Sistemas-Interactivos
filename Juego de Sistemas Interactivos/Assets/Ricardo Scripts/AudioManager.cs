using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] int cont;
    void Awake()
    {
        audio.mute = true;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cont++;
        if(cont > 1)
        {
            if (collision.tag == "Planeta")
            {
                audio.mute = false;
                audio.Play();
            }
       
        }
        
    } 
    }
