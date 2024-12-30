using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootBall : MonoBehaviour
{
    public float maxPower;
    public float lineLength;
    public LineRenderer lineRenderer;
    public Rigidbody ball;
    public Slider powerSlider;
    public float angle;
    private float powerUpTime;
    private float power;

    void Awake()
    {
        ball = GetComponent<Rigidbody>();
        ball.maxAngularVelocity = 1000;
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Update(){
        if(Input.GetKeyUp(KeyCode.Space)){
            Putt();
        }
        if(Input.GetKey(KeyCode.Space)){
            PowerUp();
        }
    }
    private void UpdateLinePosition(){
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + Quaternion.Euler(0, angle, 0) * Vector3.forward * lineLength);
    }
    private void Putt(){
        ball.AddForce(Quaternion.Euler(0, angle, 0) * Vector3.forward * maxPower * power, ForceMode.Impulse);
    }
    private void PowerUp(){
        powerUpTime += Time.deltaTime;
        power = Mathf.PingPong(powerUpTime, 1);
        powerSlider.value = power;
    }
}
