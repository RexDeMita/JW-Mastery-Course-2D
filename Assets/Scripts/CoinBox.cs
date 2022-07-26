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
    void Awake()
    {
        remainingCoins = _totalCoins; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if remaining coins is greater than 0 and there is a player
        if (remainingCoins > 0 && collision.collider.GetComponent<PlayerMovementController>() != null)
        {
            //add a coin
            GameManager.Instance.AddCoin();
            
            //decrement remaining coins 
            remainingCoins--;

            //if remaining coins are less than or equal to 0
            if (remainingCoins <= 0)
            {
                //swap the sprite
                _enabledSprite.enabled = false;
                _disabledSprite.enabled = true;
            }
        }
    }
}
