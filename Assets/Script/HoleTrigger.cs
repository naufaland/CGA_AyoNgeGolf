using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas; // Referensi ke Canvas Game Over

    void Start()
    {
        // Pastikan Canvas Game Over tidak terlihat pada awal permainan
        gameOverCanvas.SetActive(false);
    }

    // Panggil metode ini untuk menampilkan Game Over
    public void ShowGameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0; // Menghentikan permainan
    }

    // Metode untuk restart permainan
    public void RestartGame()
    {
        Time.timeScale = 1; // Mengaktifkan kembali permainan
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Memuat ulang scene saat ini
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
