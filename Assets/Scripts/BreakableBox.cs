using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : MonoBehaviour, ITakeShellHits
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        //collision is a parameter of methods in an extension class
        //if remaining coins is greater than 0 and there is a player and the collision is coming from below
        if (collision.WasHitByPlayer() && collision.WasHitFromBottomSide())
        {
            Destroy(gameObject);
        }

    }

    public void HandleShellHit(ShellFlipped shellFlipped)
    {
        Destroy(gameObject);
    }
}