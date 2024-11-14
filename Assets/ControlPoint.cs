using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    float xRot, yRot = 0f;

    public Rigidbody ball;
    public float rotationSpeed = 5f;
    public float shootPower = 20f;
    public LineRenderer line;
    private bool isDraggingBall = false;
    private bool isRotatingCamera = false;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = ball.position;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == ball.gameObject)
                {
                    isDraggingBall = true;
                    isRotatingCamera = false;
                }
                else
                {
                    isDraggingBall = false;
                    isRotatingCamera = true;
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (isDraggingBall)
            {
                xRot += Input.GetAxis("Mouse X") * rotationSpeed;
                yRot += Input.GetAxis("Mouse Y") * rotationSpeed;
                yRot = Mathf.Clamp(yRot, -35f, 35f);
                transform.rotation = Quaternion.Euler(yRot, xRot, 0f);

                line.gameObject.SetActive(true);
                line.SetPosition(0, transform.position);
                line.SetPosition(1, transform.position + transform.forward * 4f);
            }
            else if (isRotatingCamera)
            {
                xRot += Input.GetAxis("Mouse X") * rotationSpeed;
                yRot += Input.GetAxis("Mouse Y") * rotationSpeed;
                yRot = Mathf.Clamp(yRot, -35f, 35f);
                transform.rotation = Quaternion.Euler(yRot, xRot, 0f);

                line.gameObject.SetActive(false);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDraggingBall)
            {
                ball.velocity = transform.forward * shootPower;
                isDraggingBall = false;
            }
            line.gameObject.SetActive(false);
            isRotatingCamera = false;
        }
    }
}
