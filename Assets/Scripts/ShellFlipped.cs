using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ShellFlipped : MonoBehaviour
{
    float shellSpeed = 5f; 
    Collider2D _collider;
    Rigidbody2D _rigidbody2D;
    Vector2 direction;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //this movement is determined by the direction in the x given by the shell launch method, shell speed float, and the inherent velocity in the y axis
        _rigidbody2D.velocity = new Vector2(direction.x * shellSpeed, _rigidbody2D.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if the shell collides with the player
        if (collision.WasHitByPlayer())
        {
            HandlePlayerCollision(collision);
        }
        else
        {
            //if the collision is from the side, launch the shell
            if (collision.WasSide())
            {
                LaunchShell(collision);
                
                //get a reference to the interface on the item to be broken
                var takeShellHits = collision.collider.GetComponent<ITakeShellHits>();
                
                //if that reference exists, destroy the game object that that component is attached to by calling the method in the item 
                if (takeShellHits != null)
                    takeShellHits.HandleShellHit(this);
            }
                
        }
    }

    void HandlePlayerCollision(Collision2D collision)
    {
        //get player reference
        var playerMovementController = collision.collider.GetComponent<PlayerMovementController>();

        //if the shell is not moving. vector magnitude is 0
        if (direction.magnitude == 0)
        {
            //launch the shell based on the collision data
            LaunchShell(collision);

            //if the collision is from the top, call the bounce method in the player script
            if (collision.WasHitFromTop())
                playerMovementController.Bounce();
        }
        else
        {
            //if the collision is from the top
            if (collision.WasHitFromTop())
            {
                //stop the shell movement, set the vector to 0,0
                direction = Vector2.zero;

                //call the bounce method in the player script
                playerMovementController.Bounce();
            }
            else
            {
                //kill the player and send then back to the last checkpoint
                GameManager.Instance.KillPlayer();
            }
        }
    }

    //this sets the shell direction in the opposite direction from where it was hit
    void LaunchShell(Collision2D collision)
    {
        //if the collision is from the left (x > 0), set floatDirection to 1f or positive x direction, otherwise set it to negative x direction
        float floatDirection = collision.contacts[0].normal.x > 0 ? 1f : -1f;
        
        //this sets the direction 
        direction = new Vector2(floatDirection, 0);
    }
}
