using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public int Lives { get; private set; }

    int _coins;

    int currentLevelIndex; 

    //c sharp event of type int for when the life value changes
    public event Action<int> OnLivesChanged;  
    
    //c sharp event 
    public event Action<int> OnCoinsChanged; 
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
        if (OnLivesChanged != null)
            OnLivesChanged(Lives); 
        
        //if Lives are less than or equal to 0, restart the game
        if (Lives <= 0)
            RestartGame();
        else
            SendPlayerToCheckpoint(); 
    }

    void SendPlayerToCheckpoint()
    {
        //make sure there is a default checkpoint for the level so that the player does not have to collide with a checkpoint for this to work

        //find and set a local variable with the checkpoint manager
        var checkpointManager = FindObjectOfType<CheckpointManager>();
        
        //have the checkpoint manager get the last checkpoint passed
        var checkpoint = checkpointManager.GetLastCheckpointThatWasPassed();
        
        //find and move the player
        var player = FindObjectOfType<PlayerMovementController>();
        player.transform.position = checkpoint.transform.position; 
    }

    public void AddCoin()
    {
        //increment coins
        _coins++;
        
        //call any registered events if they exist with _coins as the input
        if (OnCoinsChanged != null)
            OnCoinsChanged(_coins);
    }

    public void MoveToNextLevel()
    {
        //increment to the next index
        currentLevelIndex++;
        
        //load the scene indicated by current level index
        SceneManager.LoadScene(currentLevelIndex); 
    }
    
    void RestartGame()
    {
        //set the lives 
        Lives = 3;
        
        //initialize coin value when the game restarts
        _coins = 0;
        
        //call any registered events if they exist
        if (OnCoinsChanged != null)
            OnCoinsChanged(_coins);
        
        //load the scene at index 0
        SceneManager.LoadScene(0);
    }

   
}
