using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if remaining coins is greater than 0 and there is a player and the collision is coming from below
        if (WasHitByPlayer(collision) && WasHitFromBottomSide(collision))
        {
            Destroy(gameObject);
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