using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public GameObject gameOverCanvas; // Referensi ke canvas Game Over

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0; // Hentikan permainan
        }
    }
}