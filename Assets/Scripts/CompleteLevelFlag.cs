using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevelFlag : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        GameManager.Instance.MoveToNextLevel();
    }
}
