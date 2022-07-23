using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public int Lives { get; private set; }

    //c sharp event of type int
    public event Action<int> OnLivesChanged;  

    private void Awake()
    {
        //if there is an instance that exists, destroy this game object, otherwise
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            //create an instance
            Instance = this;
            
            //restart the game
            RestartGame();
            
            //this will not allow this game object to be destroyed on load
            DontDestroyOnLoad(gameObject);
        }
    }


    public void KillPlayer()
    {
        //decrement the lives
        Lives--; 
        
        //calling any registered events if they exist
        if(OnLivesChanged != null)
            OnLivesChanged(Lives); 
        
        //if Lives are less than or equal to 0, restart the game
        if (Lives <= 0)
            RestartGame();
    }

    void RestartGame()
    {
        //set the lives 
        Lives = 3;
        
        
        //load the scene at index 0
        SceneManager.LoadScene(0);
    }
}
