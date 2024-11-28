using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   public void chooseLevel(int levelId)
    {
        string level = "Stage" + " " + levelId;
        SceneManager.LoadScene(level);
    }
   public void Exit()
   {
       Debug.Log("Thanks For Playing Our Game!");
       Application.Quit();
   }
}
