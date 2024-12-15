using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsOut : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Ball"))
    {
        Debug.Log("Ball has entered the bounds.");
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
}
