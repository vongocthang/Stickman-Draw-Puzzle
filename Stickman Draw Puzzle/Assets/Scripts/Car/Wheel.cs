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
        //float carSpeed = carControl.tempMoveSpeed;

        //motor.motorSpeed = carSpeed * speed;
        //motor.motorSpeed = carControl.moveSpeed * speed;
        wheel.motor = motor;

        if (uiControl.moveLeft == true)
        {
            motor.motorSpeed = -carControl.moveSpeed * speed;
        }
        if (uiControl.moveRight == true)
        {
            motor.motorSpeed = carControl.moveSpeed * speed;
        }
        if(uiControl.moveLeft == false && uiControl.moveRight == false)
        {
            motor.motorSpeed = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        carControl.countToON++;
        if (collision.collider.tag != "Car")
        {
            
            //if (uiControl.moveLeft == false && uiControl.moveRight == false)
            //{
            //    carControl.targetJoint.enabled = true;
            //}
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        carControl.countToON--;
        if (collision.collider.tag != "Car")
        {
            
            //if (uiControl.moveLeft == false && uiControl.moveRight == false)
            //{
            //    carControl.targetJoint.enabled = true;
            //}
        }
    }
}
