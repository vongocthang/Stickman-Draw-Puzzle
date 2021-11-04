using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    WheelJoint2D wheel;
    JointMotor2D motor;
    public CarControl carControl;

    public float speed;

    UIControl uiControl;

    // Start is called before the first frame update 
    void Start()
    {
        wheel = GetComponent<WheelJoint2D>();
        motor = wheel.motor;

        uiControl = GameObject.Find("MainUI").GetComponent<UIControl>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Car")
        {
            carControl.countToON++;
            //if (uiControl.moveLeft == false && uiControl.moveRight == false)
            //{
            //    carControl.targetJoint.enabled = true;
            //}
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag != "Car")
        {
            carControl.countToON--;
            //if (uiControl.moveLeft == false && uiControl.moveRight == false)
            //{
            //    carControl.targetJoint.enabled = true;
            //}
        }
    }
}
