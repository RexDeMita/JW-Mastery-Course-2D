using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] Transform sprite;
    
    float positionPercent;
    int direction = 1;
    [SerializeField] [Range(0.1f, 10f)] float _speed;

    void Update()
    {
        //distance variable to calculate the right speed
        float distance = Vector3.Distance(start.position, end.position);
        
        //speed divided by the distance. this will decide how small or large each step of the interpolation will be. 
        //if this number is small the interpolations will also be small and the interpolation will take longer
        float speedForDistance = _speed / distance; 
        
        //increment or decrement the position percent every frame based on the current direction and the speed/distance variable
        positionPercent += Time.deltaTime * direction * speedForDistance; 
        
        //linear interpolation of the position of the sprite and collider from start position to the end position
        sprite.position = Vector3.Lerp(start.position, end.position, positionPercent);
        
        //if the position percent is greater than or equal to 1 and the snowball is moving to the right
        if (positionPercent >= 1 && direction == 1)
            //flip the direction
            direction = -1; 
        //if the position percent is less than or equal to 0 and the snowball is moving to the left
        else if (positionPercent <= 0 && direction == -1)
            direction = 1; 
    }
}
