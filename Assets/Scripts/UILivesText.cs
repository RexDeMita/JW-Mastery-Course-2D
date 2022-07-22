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


    void Update()
    {
        //assigns a converted string of the value of Lives to tmproText
        _tmproText.text = GameManager.Instance.Lives.ToString();
    }
}
