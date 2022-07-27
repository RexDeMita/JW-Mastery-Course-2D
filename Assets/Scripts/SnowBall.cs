using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] Transform snowballSprite;
    
    float positionPercent;
    int direction = 1; 

    void Update()
    {
        //increment or decrement the position percent every frame based on the current direction
        positionPercent += Time.deltaTime * direction; 
        
        //linear interpolation of the position of the sprite and collider from start position to the end position
        snowballSprite.position = Vector3.Lerp(start.position, end.position, positionPercent);
        
        //if the position percent is greater than or equal to 1 and the snowball is moving to the right
        if (positionPercent >= 1 && direction == 1)
            //flip the direction
            direction = -1; 
        //if the position percent is less than or equal to 0 and the snowball is moving to the left
        else if (positionPercent <= 0 && direction == -1)
            direction = 1; 
    }
}
