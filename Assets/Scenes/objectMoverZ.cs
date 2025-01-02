using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoverZ : MonoBehaviour
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
        // Gerakan maju dan mundur menggunakan fungsi Mathf.PingPong pada sumbu Z
        float movement = Mathf.PingPong(Time.time * speed, range * 2) - range;
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z + movement);
    }
}
