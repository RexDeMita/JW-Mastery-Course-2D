using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] Transform _leftFoot;
    [SerializeField] Transform _rightFoot;
    [SerializeField] float _maxDistance;
    [SerializeField] LayerMask _layerMask;
    
    //other classes can get the value, but not set it
    public bool IsGrounded { get; private set; }

    void Update()
    {
        CheckFoodForGrounding(_leftFoot);
        if(IsGrounded == false)
            CheckFoodForGrounding(_rightFoot);

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
        }
        else
        {
            IsGrounded = false;
        }
    }
}
