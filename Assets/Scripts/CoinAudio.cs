using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        //cached audio source reference
        _audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Start()
    {
        //play audio source 
        //this lambda expression necessitates a parameter but in this case, it is not used
        //this is an alternative way of registering an event? instead of creating a method  
        GameManager.Instance.OnCoinsChanged += (coins) => _audioSource.Play();
    }
}
