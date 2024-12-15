using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Untuk mengelola scene
using UnityEngine.UI; // Untuk menggunakan UI

public class SceneOverManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool GameIsPaused = false;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
   
    public void RestartGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scenes/Main Menu");
    }
}
