using UnityEngine;

//this is an extension methods
//used anytime you need to check for a player or hitting from below
public static class Collision2DExtensions
{
    public static bool WasHitByPlayer(this Collision2D collision)
    {
        return collision.collider.GetComponent<PlayerMovementController>() != null;
    }

    public static bool WasHitFromBottomSide(this Collision2D collision)
    {
        return collision.contacts[0].normal.y > 0.5;
    }

    public static bool WasHitFromTop(this Collision2D collision)
    {
        return collision.contacts[0].normal.y < -0.5;
    }
}