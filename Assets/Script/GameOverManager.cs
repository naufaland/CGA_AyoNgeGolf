using UnityEngine;
using UnityEngine.SceneManagement; // Untuk mengelola scene
using UnityEngine.UI; // Untuk menggunakan UI

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas;

    void Start()
    {
        gameOverCanvas.SetActive(false);
    }
    public void ShowGameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    // Metode untuk restart permainan
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Metode untuk kembali ke menu utama
    public void MainMenu()
    {
        Time.timeScale = 1; // Mengaktifkan kembali permainan
        SceneManager.LoadScene("Scenes/Main Menu"); // Memuat scene menu utama
    }

    // Metode untuk keluar dari permainan
    public void ExitGame()
    {
        Application.Quit(); // Keluar dari aplikasi
    }
}
