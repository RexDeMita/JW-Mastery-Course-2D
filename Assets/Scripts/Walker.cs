using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] GameObject spawnOnStompPrefab;
    
    float _speed = 1f;
    Collider2D _collider;
    Rigidbody2D _rigidbody2D;
    Vector2 direction = Vector2.left;
    SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    //better for physics objects
    void FixedUpdate()
    {
        //this moves the rigidbody of this object 
        _rigidbody2D.MovePosition(_rigidbody2D.position + direction * (_speed * Time.fixedDeltaTime));
    }

    void LateUpdate()
    {
        if (ReachedEdge() || HitNotPlayer())
            SwitchDirections();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if the walker collides with a player
        if (collision.WasHitByPlayer())
        {
            //if the collision was from the top
            if (collision.WasHitFromTop())
                //run the code for stomping on the walker
                HandleWalkerStomped();
            else
            {
                //kill the player
                GameManager.Instance.KillPlayer();
            }
        }
            
    }

    void HandleWalkerStomped()
    {
        //if there is a prefab, instantiate it
        if (spawnOnStompPrefab != null)
            Instantiate(spawnOnStompPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    
    bool HitNotPlayer()
    {
        var x = GetForwardX();
        
        //this is the center y, not the bottom y
        float y = transform.position.y; 
        
        //origin of the ray
        Vector2 origin = new Vector2(x, y); 
        
        //the raycast seen in the editor pointing in the direction the walker is moving
        Debug.DrawRay(origin, direction * 0.1f);
        
        //the raycast itself
        var hit = Physics2D.Raycast(origin, direction, 0.1f);
        
        //if the raycast hits nothing at all, return false
        if (hit.collider == null)
            return false;
        
        //if the raycast hits a trigger, return false
        if (hit.collider.isTrigger)
            return false; 
        
        //if the raycast hits a player, return false
        if (hit.collider.GetComponent<PlayerMovementController>())
            return false; 

        return true;
    }

    bool ReachedEdge()
    {
        var x = GetForwardX();

        //this is the value of the min bound of a collider in the y direction
        float y = _collider.bounds.min.y;
        
        //origin of the ray
        Vector2 origin = new Vector2(x, y); 
        
        //the raycast seen in the editor
        Debug.DrawRay(origin, Vector2.down * 0.1f);
        
        //the raycast itself
        var hit = Physics2D.Raycast(origin, Vector2.down, 0.1f);

        if (hit.collider == null)
            return true;
        return false; 
    }

    float GetForwardX()
    {
        //if direction is -1, use the min x bound, otherwise, use the max x bound
        float x = direction.x == -1 ? _collider.bounds.min.x - 0.1f : _collider.bounds.max.x + 0.1f;
        return x;
    }

    void SwitchDirections()
    {
        //direction is flipped
        direction *= -1; 
        
        //flip the sprite
        _spriteRenderer.flipX = !_spriteRenderer.flipX; 
    }
}
