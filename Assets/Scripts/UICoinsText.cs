using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICoinsText : MonoBehaviour
{
    TextMeshProUGUI tmproText;

    void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        //registers the event
        GameManager.Instance.OnCoinsChanged += HandleOnCoinsChanged;
    }

    private void HandleOnCoinsChanged(int coins)
    {
        //sets the text of the coin UI
        tmproText.text = coins.ToString();
    }

    
}
