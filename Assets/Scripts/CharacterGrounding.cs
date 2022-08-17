using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] Transform[] _positions;
    [SerializeField] float _maxDistance;
    [SerializeField] LayerMask _layerMask;

    Transform groundedObject;

    //this vector3 could be null. that is what the ? is checking for
    Vector3? groundedObjectLastPosition; 
    
    //other classes can get the value, but not set it
    public bool IsGrounded { get; private set; }
    
    public Vector2 GroundedDirection { get; private set; }

    void Update()
    {
        //for each position in the array _positions, check to see if they are grounded
        foreach (var position in _positions)
        {
            CheckFootForGrounding(position);
            if (IsGrounded)
                break; 
        }
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

    void CheckFootForGrounding(Transform foot)
    {
        //ray cast hit on a collider that recognizes colliders that have the layer mask that is set in the inspector 
        var rayCastHit = Physics2D.Raycast(foot.position, foot.forward, _maxDistance, _layerMask);
        
        //debug ray that can be seen in the scene view
        Debug.DrawRay(foot.position, foot.forward * _maxDistance, Color.red);
        
        //if the ray cast hits a collider, especially the collider of the ground, the player is on the ground
        if (rayCastHit.collider != null)
        {
            //if the transform of the grounded object does not equal the transform of the collider from the ray cast collision
            //if there is a new object under the character
            if (groundedObject != rayCastHit.collider.transform)
            {
                IsGrounded = true;
                
                //get the transform of the collider that this raycast hit
                //this sets the new object as the grounded Object
                groundedObject = rayCastHit.collider.transform;
                    
                //set the last position of the grounded object to the 
                groundedObjectLastPosition = groundedObject.position;
            }
            
            //this sets the direction of the vector using the transform getting us the grounding
            GroundedDirection = foot.forward; 
        }
        else
        {
            //there is no grounded object anymore
            groundedObject = null;
            IsGrounded = false;
        }
    }
}
