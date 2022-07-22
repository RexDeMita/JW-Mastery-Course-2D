using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnEnter : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collider info from the player movement controller script reference
        var playerMovementController = collision.collider.GetComponent<PlayerMovementController>();
        
        //if the player movement controller exists
        if (playerMovementController != null)
        {
            Debug.Log("there is a player");
            //call the killPlayer method in the game manager class
            GameManager.Instance.KillPlayer();
        }
    }
}
