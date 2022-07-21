using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//these components depend on each other so when one is added to an object, the other is added as well 
[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour, IMove
{
    [SerializeField] float moveSpeed = 2;
    [SerializeField] float jumpForce = 400;
    Rigidbody2D _rigidBody2D;
    CharacterGrounding _characterGrounding;

    //this is a member of the IMove interafce that can be used by other classes to get the Speed value set somewhere in this script
    public float Speed { get; private set; }
    void Awake()
    {
        //rigidbody2D reference
        _rigidBody2D = GetComponent<Rigidbody2D>();
        
        //characterGrounding script reference
        _characterGrounding = GetComponent<CharacterGrounding>();
    }

    void FixedUpdate()
    {
        //input on the x and y axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //absolute value of the horizontal input 
        Speed = horizontal;
        
        //movement vector
        Vector3 movement = new Vector3(horizontal, vertical);

        //movement in space based on a vector and multipliers
        transform.position += movement * (Time.deltaTime * moveSpeed);

        //if Fire1 is pressed this frame
        if (Input.GetButtonDown("Fire1") && _characterGrounding.IsGrounded)
        {
            //force added to the rigidbody in the up direction multiplied by a jump force that can be edited in the inspector
            _rigidBody2D.AddForce(Vector2.up * jumpForce);
        }

    }

    
}
