using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
  
    Collider2D _collider;
    Rigidbody2D _rigidbody2D;
    Vector2 direction = Vector2.left;
     float _speed = 1f;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    //better for physics objects
    private void FixedUpdate()
    {
        //this moves the rigidbody of this object 
        _rigidbody2D.MovePosition(_rigidbody2D.position + direction * (_speed * Time.fixedDeltaTime));
    }

 
}
