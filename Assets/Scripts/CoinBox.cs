using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    [SerializeField] SpriteRenderer _enabledSprite;
    [SerializeField] SpriteRenderer _disabledSprite;
    [SerializeField] int _totalCoins = 1;
    
    int remainingCoins;
    Animator _animator;

    void Awake()
    {
        remainingCoins = _totalCoins;
        _animator = GetComponent<Animator>(); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if remaining coins is greater than 0 and there is a player and the collision is coming from below
        if (remainingCoins > 0 && WasHitByPlayer(collision) && WasHitFromBottomSide(collision))
        {
            //add a coin
            GameManager.Instance.AddCoin();
            
            //decrement remaining coins 
            remainingCoins--;
            
            //activate the trigger in the animator 
            _animator.SetTrigger("FlipCoin");
            
            //if remaining coins are less than or equal to 0
            if (remainingCoins <= 0)
            {
                //swap the sprite
                _enabledSprite.enabled = false;
                _disabledSprite.enabled = true;
            }
        }
    }

    static bool WasHitByPlayer(Collision2D collision)
    {
        return collision.collider.GetComponent<PlayerMovementController>() != null;
    }

    static bool WasHitFromBottomSide(Collision2D collision)
    {
        return collision.contacts[0].normal.y > 0.5;
    }
}
