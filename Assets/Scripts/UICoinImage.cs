using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICoinImage : MonoBehaviour
{
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        //when a coin is added, an event is registered
        GameManager.Instance.OnCoinsChanged += Pulse; 
    }

    void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= Pulse;
    }

    void Pulse(int coins)
    {
        //animation trigger activated
        _animator.SetTrigger("CoinAdded");
    }
}
