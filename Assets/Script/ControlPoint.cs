using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    float xRot, yRot = 0f;
    public Rigidbody ball;
    public float rotateSpeed = 5f;
    public LineRenderer lineRenderer;
    public float shootPower = 10f;

    void Update()
    {
        // Update the position of the camera holder to the ball's position
        transform.position = ball.position;

        // Rotate the camera holder based on mouse movement
        if (Input.GetMouseButton(0))
        {
            xRot += Input.GetAxis("Mouse X") * rotateSpeed;
            yRot += Input.GetAxis("Mouse Y") * rotateSpeed;

            // Clamp the vertical rotation
            yRot = Mathf.Clamp(yRot, -35f, 35f);
            transform.rotation = Quaternion.Euler(yRot, xRot, 0f);

            // Activate the line renderer and set its positions
            lineRenderer.gameObject.SetActive(true);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * 4f);
        }

        // Shoot the ball when the mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            ball.velocity = transform.forward * shootPower;
            lineRenderer.gameObject.SetActive(false);
        }
    }
}
