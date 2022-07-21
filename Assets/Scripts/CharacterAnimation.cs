using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator _animator;
    IMove _mover; 

    void Awake()
    {
        //animator reference
        _animator = GetComponent<Animator>();
        
        //IMove interface reference
        _mover = GetComponent<IMove>(); 
    }

    void Update()
    {
        //speed from player movement controller script
        float speed = _mover.Speed;
        
        //the parameter value is set. the run animation responds to this value by playing
        _animator.SetFloat("Speed", speed);    
    }
}
