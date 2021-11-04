using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Điều khiển Car chung cho 3 chế độ đầu

public class CarControl : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float moveSpeed;
    public float tempMoveSpeed;
    public TargetJoint2D targetJoint;
    public int countToON = 0;

    //Để xác định con dốc nằm ở bên nào
    //Từ đó xác định di chuyển trái/phải là xuống dốc
    public float zRotation;

    UIControl uiControl;


    // Start is called before the first frame update
    void Start()
    {
        uiControl = GameObject.Find("MainUI").GetComponent<UIControl>();
        targetJoint = this.GetComponent<TargetJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    public void Move()
    {
        zRotation = this.transform.rotation.z;

        if (uiControl.moveLeft == true)
        {
            targetJoint.enabled = false;

            //Tốc độ tăng dần
            if (Mathf.Abs(tempMoveSpeed) < moveSpeed)
            {
                tempMoveSpeed -= 2;
            }
            if (zRotation > 0.02)
            {
                //Debug.Log("Xuống dốc phải");
            }
            else
            {
                if (countToON >= 1)
                {
                    rb2D.velocity = new Vector2(tempMoveSpeed * Time.deltaTime, 0f);
                }
                //Debug.Log("Lên dốc trái");
                //rb2D.velocity = new Vector2(tempMoveSpeed * Time.deltaTime, 0f);
            }
        }

        if (uiControl.moveRight == true)
        {
            targetJoint.enabled = false;

            //Tốc độ tăng dần
            if (Mathf.Abs(tempMoveSpeed) < moveSpeed)
            {
                tempMoveSpeed += 2;
            }
            if (zRotation < -0.02)
            {
                //Debug.Log("Xuống dốc trái");
            }
            else
            {
                if (countToON >= 1)
                {
                    rb2D.velocity = new Vector2(tempMoveSpeed * Time.deltaTime, 0f);
                }
                //Debug.Log("Lên dốc phải");
                //rb2D.velocity = new Vector2(tempMoveSpeed * Time.deltaTime, 0f);
            }
        }

        if(uiControl.moveLeft==false && uiControl.moveRight == false)
        {
            if (countToON == 2)
            {
                targetJoint.enabled = true;
            }
            else
            {
                targetJoint.enabled = false;
            }
            //targetJoint.enabled = true;
            tempMoveSpeed = 0;
        }
    }
}
