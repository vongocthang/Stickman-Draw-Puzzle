using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class GravityCar : MonoBehaviour
{
    UIControl uiControl;

    public Rigidbody2D thisRb;
    public int moveSpeed;
    public int tempMoveSpeed;

    public TargetJoint2D targetJoint;

    public GameObject forwardWheel;
    public GameObject backWheel;

    public SkeletonAnimation skeletonAnim;
    public int countAnim = 1;
    public float countTime;

    public float tempRotation;



    // Start is called before the first frame update
    void Start()
    {
        uiControl = GameObject.Find("MainUI").GetComponent<UIControl>();

        if (this.name == "CarLeft")
        {
            tempRotation = 90;
            forwardWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);
            backWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);
        }
        else
        {
            tempRotation = -90;
            forwardWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);
            backWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (uiControl.moveLeft == true)
        {
            targetJoint.enabled = false;
            //Animation
            countAnim = 1;
            if (this.name == "CarLeft")
            {
                skeletonAnim.AnimationName = "Forward";
                //Xoay động cơ
                tempRotation = Mathf.MoveTowards(tempRotation, 180, 10);
                forwardWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);
                backWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);
            }
            else
            {
                skeletonAnim.AnimationName = "Backward";
                //Xoay động cơ
                tempRotation = Mathf.MoveTowards(tempRotation, 0, 10);
                forwardWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);
                backWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);
            }
            //Tốc độ tăng dần
            if (Mathf.Abs(tempMoveSpeed) < moveSpeed)
            {
                tempMoveSpeed -= 3;
                thisRb.velocity = new Vector2(tempMoveSpeed * Time.deltaTime, 0f);
            } 
        }

        if (uiControl.moveRight == true)
        {
            targetJoint.enabled = false;
            //Animation
            countAnim = 1;
            if (this.name == "CarLeft")
            {
                skeletonAnim.AnimationName = "Backward";
                //Xoay động cơ
                tempRotation = Mathf.MoveTowards(tempRotation, 0, 10);
                forwardWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);
                backWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);

            }
            else
            {
                skeletonAnim.AnimationName = "Forward";
                //Xoay động cơ
                tempRotation = Mathf.MoveTowards(tempRotation, -180, 10);
                forwardWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);
                backWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);

            }
            //Tốc độ tăng dần
            if (Mathf.Abs(tempMoveSpeed) < moveSpeed)
            {
                tempMoveSpeed += 3;
                thisRb.velocity = new Vector2(tempMoveSpeed * Time.deltaTime, 0f);
            }
        }

        if (uiControl.moveUp == true)
        {
            targetJoint.enabled = false;
            countAnim = 1;
            skeletonAnim.AnimationName = "Forward";
            //Tốc độ tăng dần
            if (Mathf.Abs(tempMoveSpeed) < moveSpeed)
            {
                tempMoveSpeed += 3;
                thisRb.velocity = new Vector2(0f, tempMoveSpeed * Time.deltaTime);
            }
            if (this.name == "CarLeft")
            {
                //Xoay động cơ
                tempRotation = Mathf.MoveTowards(tempRotation, 90, 10);
                forwardWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);
                backWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);

            }
            else
            {
                //Xoay động cơ
                tempRotation = Mathf.MoveTowards(tempRotation, -90, 10);
                forwardWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);
                backWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);

            }
        }

        if (uiControl.moveDown == true)
        {
            targetJoint.enabled = false;
            countAnim = 1;
            skeletonAnim.AnimationName = "Forward";
            //Tốc độ tăng dần
            if (Mathf.Abs(tempMoveSpeed) < moveSpeed)
            {
                tempMoveSpeed -= 3;
                thisRb.velocity = new Vector2(0f, tempMoveSpeed * Time.deltaTime);
            }
            if (this.name == "CarLeft")
            {
                //Xoay động cơ
                tempRotation = Mathf.MoveTowards(tempRotation, -90, 10);
                forwardWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);
                backWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);

            }
            else
            {
                //Xoay động cơ
                tempRotation = Mathf.MoveTowards(tempRotation, 90, 10);
                forwardWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);
                backWheel.transform.rotation = Quaternion.Euler(0, 0, tempRotation);

            }
        }

        if (uiControl.moveLeft == false && uiControl.moveRight == false && uiControl.moveUp == false &&
            uiControl.moveDown == false)
        {
            targetJoint.enabled = true;
            tempMoveSpeed = 0;

            //Animation
            if (Time.time < countTime + 5)
            {
                skeletonAnim.AnimationName = "Idle " + countAnim.ToString();
            }
            else
            {
                if (countAnim == 3)
                {
                    countAnim = 1;
                    return;
                }
                countAnim++;
                countTime = Time.time;
            }
        }
    }
}
