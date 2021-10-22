using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    WheelJoint2D wheel;
    JointMotor2D motor;
    public CarControl carControl;

    public float speed;

    // Start is called before the first frame update 
    void Start()
    {
        wheel = GetComponent<WheelJoint2D>();
        motor = wheel.motor;
    }

    // Update is called once per frame
    void Update()
    {
        WheelRotate();
    }

    public void WheelRotate()
    {
        float carSpeed = carControl.tempMoveSpeed;

        motor.motorSpeed = carSpeed * speed;
        wheel.motor = motor;
    }
}
