using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    Animator _animator;
    IMove _mover;
    SpriteRenderer _spriteRenderer;

    void Awake()
    {
        //animator reference
        _animator = GetComponent<Animator>();
        
        //IMove interface reference
        _mover = GetComponent<IMove>(); 
        
        //sprite renderer reference
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //speed from player movement controller script
        float speed = _mover.Speed;
        
        //the parameter value is set. the run animation responds to this value by playing
        _animator.SetFloat("Speed", Mathf.Abs(speed));

        //if the speed is not 0, then flip. if there is movement, flip. otherwise, face the direction you are currently facing
        if(speed != 0)
            _spriteRenderer.flipX = speed > 0; 
    }
}
