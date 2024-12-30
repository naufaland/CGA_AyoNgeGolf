using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Add this for UI components

public class ControlPoint : MonoBehaviour
{
    public float maxPower = 10f; // Maximum power for the putt
    public float lineLength = 4f; // Length of the line renderer
    public Rigidbody ball;
    public float rotateSpeed = 5f;
    public LineRenderer lineRenderer;
    public float deceleration = 0.5f; 
    public TMP_Text hitCountText;
    public TMP_Text scoreText; 
    public Slider powerSlider; // Reference to the power slider
    public float angle = 0f; // Angle for the putt

    private int hitCount = 0;
    private int score = 0; 

    public float minYRotation = -10f; 
    public float maxYRotation = 10f;  

    private Vector3 initialBallPosition; 
    private float powerUpTime;
    private float power;
    private float xRot, yRot = 0f;

    void Start()
    {
        initialBallPosition = ball.position;
        UpdateScoreText(); 
        powerSlider.value = 0; // Initialize slider value
        lineRenderer.gameObject.SetActive(false); // Initially hide the line renderer
    }

    void Update()
    {
        // Update the position of the control point to match the ball's position
        transform.position = ball.position;

        // Handle camera rotation with mouse movement
        xRot += Input.GetAxis("Mouse X") * rotateSpeed;
        yRot += Input.GetAxis("Mouse Y") * rotateSpeed;
        yRot = Mathf.Clamp(yRot, minYRotation, maxYRotation);
        transform.rotation = Quaternion.Euler(yRot, xRot, 0f);

        // Show line renderer
        lineRenderer.gameObject.SetActive(true);
        UpdateLinePosition();

        // Power up when the spacebar is held down
        if (Input.GetKey(KeyCode.Space))
        {
            PowerUp();
        }

        // Putt the ball when the spacebar is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Putt();
            lineRenderer.gameObject.SetActive(false);
            hitCount++;
            UpdateHitCountText();
            UpdateScore(); 
        }

        // Decelerate the ball if it is moving
        if (ball.velocity.magnitude > 0)
        {
            ball.velocity -= ball.velocity.normalized * deceleration * Time.deltaTime;

            if (ball.velocity.magnitude < 0.1f)
            {
                ball.velocity = Vector3.zero;
            }
        }

        UpdatePowerText(); // Update power text every frame
    }

    private void UpdateLinePosition()
    {
        // Get the mouse position in the world
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position + Vector3.up * 0.1f); // Plane above the ball
        float hitDistance;

        if (plane.Raycast(ray, out hitDistance))
        {
            Vector3 mouseWorldPosition = ray.GetPoint(hitDistance);
            Vector3 direction = (mouseWorldPosition - transform.position).normalized;

            // Set the line renderer positions
            lineRenderer.SetPosition(0, transform.position + Vector3.up * 0.5f); // Position above the ball
            lineRenderer.SetPosition(1, transform.position + Vector3.up * 0.5f + direction * lineLength);
        }
    }

    private void Putt()
    {
        // Calculate the shoot direction based on the control point's forward direction
        Vector3 shootDirection = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized;
        // Apply force to the ball in the shoot direction
        ball.AddForce(shootDirection * maxPower * power, ForceMode.Impulse);
        powerUpTime = 0; // Reset power-up time after shooting
    }

    private void PowerUp()
    {
        powerUpTime += Time.deltaTime;
        power = Mathf.PingPong(powerUpTime, 1);
        powerSlider.value = power; // Update the power slider
    }

    public void ResetBall()
    {
        ball.position = initialBallPosition; 
        ball.velocity = Vector3.zero; 
    }

    void UpdateHitCountText()
    {
        hitCountText.text = "Hits: " + hitCount; 
    }

    void UpdateScore()
    {
        score = CalculateScore(); 
        UpdateScoreText(); 
    }

    int CalculateScore()
    {
        if (hitCount < 20)
        {
            return 1000; 
        }
        else if (hitCount >= 21 && hitCount <= 30)
        {
            return 750; 
        }
        else if (hitCount >= 31 && hitCount <= 50)
        {
            return 500; 
        }
        else
        {
            return 200; 
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; 
    }

    void UpdatePowerText()
    {
        // Update the power text if you have a UI element for it
        // powerText.text = "Power: " + powerSlider.value.ToString("F1"); // Uncomment if you have a power text UI
    }
}
