using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoverY : MonoBehaviour
{
    public float speed = 2.0f; // Kecepatan pergerakan
    public float range = 5.0f; // Jarak maksimum pergerakan dari posisi awal

    private Vector3 startPosition;

    void Start()
    {
        // Simpan posisi awal objek
        startPosition = transform.position;
    }

    void Update()
    {
        // Gerakan naik dan turun menggunakan fungsi Mathf.PingPong pada sumbu Y
        float movement = Mathf.PingPong(Time.time * speed, range * 2) - range;
        transform.position = new Vector3(startPosition.x, startPosition.y + movement, startPosition.z);
    }
}
