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
        Debug.Log(direction);
    }

    void LateUpdate()
    {
        if (ReachedEdge())
            SwitchDirections();
    }

    bool ReachedEdge()
    {
        //if direction is -1, use the min x bound, otherwise, use the max x bound
        float x = direction.x == -1 ? _collider.bounds.min.x - 0.1f : _collider.bounds.max.x + 0.1f;
        
        //this is the value of the min bound of a collider in the y direction
        float y = _collider.bounds.min.y;
        
        //origin of the ray
        Vector2 origin = new Vector2(x, y); 
        
        //the raycast seen in the editor
        Debug.DrawRay(origin, Vector2.down * 0.1f);
        
        //the raycast itself
        var hit = Physics2D.Raycast(origin, Vector2.down, 0.1f);
        
        Debug.Log(hit.collider);
        
        if (hit.collider == null)
            return true;
        return false; 
    }
    
    void SwitchDirections()
    {
        //direction is flipped
        direction *= -1; 
        
    }
}
