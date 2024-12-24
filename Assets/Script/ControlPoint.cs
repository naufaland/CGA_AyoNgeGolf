using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlPoint : MonoBehaviour
{
    float xRot, yRot = 0f;
    public Rigidbody ball;
    public float rotateSpeed = 5f;
    public LineRenderer lineRenderer;
    public float shootPower = 10f;
    public float deceleration = 0.5f; 
    public TMP_Text hitCountText;
    public TMP_Text scoreText; // Tambahkan referensi untuk teks skor

    private bool isMoving = false;
    private int hitCount = 0;
    private int score = 0; // Variabel untuk menyimpan skor

    public float minYRotation = -10f; 
    public float maxYRotation = 10f;  

    private Vector3 initialBallPosition; // Menyimpan posisi awal bola

    void Start()
    {
        initialBallPosition = ball.position;
        UpdateScoreText(); // Perbarui teks skor di awal
    }

    void Update()
    {
        transform.position = ball.position;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        bool isMouseOverBall = Physics.Raycast(ray, out hit) && hit.collider.gameObject == ball.gameObject;

        if (Input.GetMouseButton(0))
        {
            xRot += Input.GetAxis("Mouse X") * rotateSpeed;
            yRot += Input.GetAxis("Mouse Y") * rotateSpeed;

            yRot = Mathf.Clamp(yRot, minYRotation, maxYRotation);
            transform.rotation = Quaternion.Euler(yRot, xRot, 0f);

            if (isMouseOverBall)
            {
                lineRenderer.gameObject.SetActive(true);
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, transform.position + transform.forward * 4f);
            }
            else
            {
                lineRenderer.gameObject.SetActive(false);
            }
        }

        if (Input.GetMouseButtonUp(0) && isMouseOverBall)
        {
            Vector3 shootDirection = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized;
            ball.velocity = shootDirection * shootPower;
            lineRenderer.gameObject.SetActive(false);
            hitCount++;
            UpdateHitCountText();
            UpdateScore(); // Hitung skor setiap kali bola ditembakkan
        }

        if (ball.velocity.magnitude > 0)
        {
            ball.velocity -= ball.velocity.normalized * deceleration * Time.deltaTime;

            if (ball.velocity.magnitude < 0.1f)
            {
                ball.velocity = Vector3.zero;
            }
        }
    }

    public void ResetBall()
    {
        ball.position = initialBallPosition; // Kembalikan bola ke posisi awal
        ball.velocity = Vector3.zero; // Hentikan bola
    }

    void UpdateHitCountText()
    {
        hitCountText.text = "Hits: " + hitCount; // Update the hit count text
    }

    void UpdateScore()
    {
        score = CalculateScore(); // Hitung skor berdasarkan hit count
        UpdateScoreText(); // Perbarui teks skor
    }

    int CalculateScore()
    {
        if (hitCount < 20)
        {
            return 1000; // Skor jika hitCount di bawah 20
        }
        else if (hitCount >= 21 && hitCount <= 30)
        {
            return 750; // Skor jika hitCount antara 21 dan 30
        }
        else if (hitCount >= 31 && hitCount <= 50)
        {
            return 500; // Skor jika hitCount antara 31 dan 50
        }
        else
        {
            return 200; // Skor jika hitCount lebih dari 50
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Update the score text
    }
}
