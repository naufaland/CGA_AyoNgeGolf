using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillRotator : MonoBehaviour
{
    public float rotationSpeed = 50f; // Kecepatan rotasi (derajat per detik)

    void Update()
    {
        // Putar objek di sumbu Z (atau ganti sesuai kebutuhan)
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
