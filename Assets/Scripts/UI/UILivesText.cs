using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    TextMeshProUGUI _tmproText;


    void Awake()
    {
        //reference to the TMPro object
        _tmproText = GetComponent<TextMeshProUGUI>();
    }


    void Start()
    {
        //registers an event
        GameManager.Instance.OnLivesChanged += HandleOnLivesChanged;
        
        //this initializes the text to the correct value in Game Manager
        _tmproText.text = GameManager.Instance.Lives.ToString(); 
    }

    void HandleOnLivesChanged(int livesRemaining)
    {
        //this updates the lives text 
        _tmproText.text = livesRemaining.ToString(); 
    }
}
