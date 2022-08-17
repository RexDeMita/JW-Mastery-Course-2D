using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayButton : MonoBehaviour
{
   //this method will call a method on the game manager to reset the game
   public void StartGame()
   {
      GameManager.Instance.MoveToNextLevel();
   }
}
