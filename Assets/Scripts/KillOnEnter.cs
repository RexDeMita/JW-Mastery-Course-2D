using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnEnter : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        //player movement controller script reference
        var playerMovementController = GetComponent<PlayerMovementController>();
        
        //if the player movement controller exists
        if (playerMovementController != null)
        {
            //load the scene at index 0
            SceneManager.LoadScene(0);
        }
            


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
