using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCar : MonoBehaviour
{
    UIControl uiControl;

    public Rigidbody2D thisRb;
    public int moveSpeed;
    public int tempMoveSpeed;

    public TargetJoint2D targetJoint;

    // Start is called before the first frame update
    void Start()
    {
        uiControl = GameObject.Find("MainUI").GetComponent<UIControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (uiControl.moveLeft == true || Input.GetKey(KeyCode.LeftArrow))
        {
            targetJoint.enabled = false;

            //Tốc độ tăng dần
            if (Mathf.Abs(tempMoveSpeed) < moveSpeed)
            {
                tempMoveSpeed -= 3;
                thisRb.velocity = new Vector2(-moveSpeed * Time.deltaTime, 0f);
            }
        }

        if (uiControl.moveRight == true || Input.GetKey(KeyCode.RightArrow))
        {
            targetJoint.enabled = false;

            //Tốc độ tăng dần
            if (Mathf.Abs(tempMoveSpeed) < moveSpeed)
            {
                tempMoveSpeed += 3;
                thisRb.velocity = new Vector2(moveSpeed * Time.deltaTime, 0f);
            }
        }

        if (uiControl.moveUp == true || Input.GetKey(KeyCode.UpArrow))
        {
            targetJoint.enabled = false;

            //Tốc độ tăng dần
            if (Mathf.Abs(tempMoveSpeed) < moveSpeed)
            {
                tempMoveSpeed += 3;
                thisRb.velocity = new Vector2(0f, moveSpeed * Time.deltaTime);
            }
        }

        if (uiControl.moveDown == true || Input.GetKey(KeyCode.DownArrow))
        {
            targetJoint.enabled = false;

            //Tốc độ tăng dần
            if (Mathf.Abs(tempMoveSpeed) < moveSpeed)
            {
                tempMoveSpeed -= 3;
                thisRb.velocity = new Vector2(0f, -moveSpeed * Time.deltaTime);
            }
        }

        if (uiControl.moveLeft == false && uiControl.moveRight == false && uiControl.moveUp == false &&
            uiControl.moveDown == false)
        {
            //targetJoint.enabled = true;
            tempMoveSpeed = 0;
        }

        
    }
}
