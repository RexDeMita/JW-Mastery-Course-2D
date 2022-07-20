using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator _animator;
    PlayerMovementController _playerMovementController; 

    void Awake()
    {
        //animator reference
        _animator = GetComponent<Animator>();
        
        //playermovement controller reference
        _playerMovementController = GetComponent<PlayerMovementController>(); 
    }

    void Update()
    {
        //speed from player movement controller script
        float speed = _playerMovementController.Speed;
        
        //the parameter value is set. the run animation responds to this value by playing
        _animator.SetFloat("Speed", speed);    
    }
}
