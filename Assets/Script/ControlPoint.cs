using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Add this to use UI components

public class ControlPoint : MonoBehaviour
{
    float xRot, yRot = 0f;
    public Rigidbody ball;
    public float rotateSpeed = 5f;
    public LineRenderer lineRenderer;
    public float shootPower = 10f;
    public float deceleration = 0.5f; // Deceleration rate (magnitude of negative acceleration)
    public TMP_Text hitCountText; // Reference to the UI Text component

    private bool isMoving = false; // Track if the ball is moving
    private int hitCount = 0; // Track the number of hits

    void Update()
    {
        transform.position = ball.position;

        if (Input.GetMouseButton(0))
        {
            xRot += Input.GetAxis("Mouse X") * rotateSpeed;
            yRot += Input.GetAxis("Mouse Y") * rotateSpeed;

            yRot = Mathf.Clamp(yRot, -35f, 35f);
            transform.rotation = Quaternion.Euler(yRot, xRot, 0f);

            lineRenderer.gameObject.SetActive(true);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * 4f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            ball.velocity = transform.forward * shootPower;
            isMoving = true; // Mark the ball as moving
            lineRenderer.gameObject.SetActive(false);
            hitCount++; // Increment the hit count
            UpdateHitCountText(); // Update the UI text
        }

        // Apply deceleration if the ball is moving
        if (isMoving)
        {
            ApplyDeceleration();
        }
    }

    void ApplyDeceleration()
    {
        // Reduce the ball's velocity by applying deceleration
        if (ball.velocity.magnitude > 0)
        {
            Vector3 decelerationVector = -ball.velocity.normalized * deceleration * Time.deltaTime;

            // Ensure the velocity does not reverse direction
            if (decelerationVector.magnitude > ball.velocity.magnitude)
            {
                ball.velocity = Vector3.zero;
                isMoving = false; // Stop tracking movement
            }
            else
            {
                ball.velocity += decelerationVector;
            }
        }
        else
        {
            ball.velocity = Vector3.zero;
            isMoving = false; // Stop tracking movement
        }
    }

    void UpdateHitCountText()
    {
        hitCountText.text = "Hits: " + hitCount;
    }
}
