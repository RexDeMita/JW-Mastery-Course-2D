using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] Transform _leftFoot;
    [SerializeField] Transform _rightFoot;
    [SerializeField] float _maxDistance;
    [SerializeField] LayerMask _layerMask;

    Transform groundedObject;

    //this vector3 could be null. that is what the ? is checking for
    Vector3? groundedObjectLastPosition; 
    
    //other classes can get the value, but not set it
    public bool IsGrounded { get; private set; }

    void Update()
    {
        CheckFoodForGrounding(_leftFoot);
        if(IsGrounded == false)
            CheckFoodForGrounding(_rightFoot);

        StickToMovingObjects();
    }

    void StickToMovingObjects()
    {
        //is the player grounded 
        if (groundedObject != null)
        {
            //if the grounded object's last position exists and the current and last positions of the object do not equal each other
            if (groundedObjectLastPosition.HasValue && groundedObjectLastPosition.Value != groundedObject.position)
            {
                //figure out the different between the current position of the grounded object and the last position of the grounded object
                Vector3 delta = groundedObject.position - groundedObjectLastPosition.Value; 
                
                //this sets the player's position in relation to the object moving
                transform.position += delta;
            }
            //this sets the last position of the grounding object to the current position of the grounded object 
            groundedObjectLastPosition = groundedObject.position;
        }
        else
        {
            groundedObjectLastPosition = null; 
        }
    }

    void CheckFoodForGrounding(Transform foot)
    {
        //ray cast hit on a collider
        var rayCastHit = Physics2D.Raycast(foot.position, Vector2.down, _maxDistance, _layerMask);
        
        //debug ray that can be seen in the scene view
        Debug.DrawRay(foot.position, Vector3.down * _maxDistance, Color.red);
        
        //if the ray cast hits a collider, especially the collider of the ground, the player is on the ground
        if (rayCastHit.collider != null)
        {
            IsGrounded = true;
            //get the transform of the collider that this raycast hit
            groundedObject = rayCastHit.collider.transform; 
            
            
        }
        else
        {
            //there is no grounded object anymore
            groundedObject = null;
            IsGrounded = false;
        }
    }
}
