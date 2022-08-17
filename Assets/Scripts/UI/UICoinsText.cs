using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICoinsText : MonoBehaviour
{
    TextMeshProUGUI _tmproText;
    Animator _animator;

    void Awake()
    {
        _tmproText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        //registers the event
        GameManager.Instance.OnCoinsChanged += HandleOnCoinsChanged;
    }

    private void HandleOnCoinsChanged(int coins)
    {
        //sets the text of the coin UI
        _tmproText.text = coins.ToString();
    }

    
}
