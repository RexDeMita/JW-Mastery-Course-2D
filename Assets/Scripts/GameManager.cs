using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int Lives;//{ get; private set; }
    public static GameManager Instance { get; set; }
    private void Awake()
    {
        //if there is an instance that exists, destroy this game object, otherwise
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            //create an instance and set the lives
            Lives = 3;
            Instance = this;
            
            //this will not allow this game object to be destroyed on load
            DontDestroyOnLoad(gameObject);
        }
    }


    public void KillPlayer()
    {
        //decrement the lives
        Lives--; 
        
        //load the scene at index 0
        SceneManager.LoadScene(0);
    }
}
