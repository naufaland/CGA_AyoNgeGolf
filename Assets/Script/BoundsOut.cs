using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsOut : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.tag);
        if (other.CompareTag("Ball"))
        {
            HandleBallOutOfBounds(other);
        }
        else if (other.CompareTag("OutOfBounds"))
        {
            HandleBallOutOfBounds(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Object is staying in the trigger: " + other.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Object has exited the trigger: " + other.tag);
    }

    private void HandleBallOutOfBounds(Collider ball)
    {
        Debug.Log("Ball has entered the bounds or hit Out of Bounds.");
        ControlPoint controlPoint = FindObjectOfType<ControlPoint>();
        if (controlPoint != null)
        {
            controlPoint.ResetBall(); // Kembalikan bola ke posisi terakhir
            Debug.Log("Resetting ball position.");
        }
        else
        {
            Debug.Log("ControlPoint not found.");
        }
    }
}