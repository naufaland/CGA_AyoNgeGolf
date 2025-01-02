using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] UnityEvent onEnterEvent;

    // Metode yang dipanggil saat objek memasuki trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Pastikan event tidak null sebelum dipanggil
        if (onEnterEvent != null)
        {
            onEnterEvent.Invoke();
        }
    }
}
