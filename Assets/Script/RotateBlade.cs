using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlade : MonoBehaviour
{
    public float rotationSpeed = 30f; // Kecepatan rotasi

    void Update()
    {
        // Memutar objek di tempat pada sumbu Y
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
