using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2;
    [SerializeField] float jumpForce = 400;
    Rigidbody2D _rigidBody2D;

    void Awake()
    {
        //rigidbody2D reference
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //input on the x and y axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        //movement vector
        Vector3 movement = new Vector3(horizontal, vertical);

        //movement in space based on a vector and multipliers
        transform.position += movement * (Time.deltaTime * moveSpeed);

        //if Fire1 is pressed this frame
        if (Input.GetButtonDown("Fire1"))
        {
            //force added to the rigidbody in the up direction multiplied by a jump force that can be edited in the inspector
            _rigidBody2D.AddForce(Vector2.up * jumpForce);
        }

    }
}
