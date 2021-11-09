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
    public GameObject forward;
    public GameObject back;
    public GameObject emptyObject;

    // Start is called before the first frame update
    void Start()
    {
        uiControl = GameObject.Find("MainUI").GetComponent<UIControl>();

        //Debug.Log(forwardWheel.transform.rotation.z);
        //forwardWheel.transform.rotation = new Vector3(0, 0, 90);
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
            }
            else
            {
                skeletonAnim.AnimationName = "Backward";
            }
            //Tốc độ tăng dần
            if (Mathf.Abs(tempMoveSpeed) < moveSpeed)
            {
                tempMoveSpeed -= 3;
                thisRb.velocity = new Vector2(tempMoveSpeed * Time.deltaTime, 0f);
            }

            if (forward == null && back == null)
            {
                forward = Instantiate(emptyObject, this.transform);
                Vector3 temp1 = forward.transform.position;
                temp1.x += 10;
                forward.transform.position = temp1;

                Quaternion qua1 = Quaternion.LookRotation(Vector3.forward, forward.transform.position -
                    forwardWheel.transform.position);
                qua1 = Quaternion.Euler(0, 0, qua1.eulerAngles.z - 90);
                forwardWheel.transform.rotation = Quaternion.RotateTowards(forwardWheel.transform.rotation,
                    qua1, 100);
                ////////////////////////////////////////////////////////////
                back = Instantiate(emptyObject, this.transform);
                Vector3 temp2 = back.transform.position;
                temp2.x += 10;
                back.transform.position = temp2;

                Quaternion qua2 = Quaternion.LookRotation(Vector3.forward, forward.transform.position -
                    backWheel.transform.position);
                qua2 = Quaternion.Euler(0, 0, qua2.eulerAngles.z - 90);
                backWheel.transform.rotation = Quaternion.RotateTowards(backWheel.transform.rotation,
                    qua2, 100);
            }

            //Vector3 temp1 = emptyObject.transform.position;
            //temp1.x += 10;
            //emptyObject.transform.position = temp1;

            //forwardWheel.transform.localRotation = emptyObject.transform.localRotation;
        }

        if (uiControl.moveRight == true)
        {
            targetJoint.enabled = false;
            //Animation
            countAnim = 1;
            if (this.name == "CarLeft")
            {
                skeletonAnim.AnimationName = "Backward";
            }
            else
            {
                skeletonAnim.AnimationName = "Forward";
            }
            //Tốc độ tăng dần
            if (Mathf.Abs(tempMoveSpeed) < moveSpeed)
            {
                tempMoveSpeed += 3;
                thisRb.velocity = new Vector2(tempMoveSpeed * Time.deltaTime, 0f);
            }

            if (forward == null && back == null)
            {
                forward = Instantiate(emptyObject, this.transform);
                Vector3 temp1 = forward.transform.position;
                temp1.x -= 10;
                forward.transform.position = temp1;

                Quaternion qua1 = Quaternion.LookRotation(Vector3.forward, forward.transform.position -
                    forwardWheel.transform.position);
                qua1 = Quaternion.Euler(0, 0, qua1.eulerAngles.z - 90);
                forwardWheel.transform.rotation = Quaternion.RotateTowards(forwardWheel.transform.rotation,
                    qua1, 100);
                ////////////////////////////////////////////////////////////
                back = Instantiate(emptyObject, this.transform);
                Vector3 temp2 = back.transform.position;
                temp2.x -= 10;
                back.transform.position = temp2;

                Quaternion qua2 = Quaternion.LookRotation(Vector3.forward, forward.transform.position -
                    backWheel.transform.position);
                qua2 = Quaternion.Euler(0, 0, qua2.eulerAngles.z - 90);
                backWheel.transform.rotation = Quaternion.RotateTowards(backWheel.transform.rotation,
                    qua2, 100);
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

            if (forward == null && back == null)
            {
                forward = Instantiate(emptyObject, forwardWheel.transform);
                Vector3 temp1 = forward.transform.position;
                temp1.y += 10;
                forward.transform.position = temp1;

                Quaternion qua1 = Quaternion.LookRotation(Vector3.forward, forward.transform.position -
                    forwardWheel.transform.position);
                qua1 = Quaternion.Euler(0, 0, qua1.eulerAngles.z + 90);
                forwardWheel.transform.rotation = Quaternion.RotateTowards(forwardWheel.transform.rotation,
                    qua1, 100);
                ////////////////////////////////////////////////////////////
                back = Instantiate(emptyObject, this.transform);
                Vector3 temp2 = back.transform.position;
                temp2.y += 10;
                back.transform.position = temp2;

                Quaternion qua2 = Quaternion.LookRotation(Vector3.forward, forward.transform.position -
                    backWheel.transform.position);
                qua2 = Quaternion.Euler(0, 0, qua2.eulerAngles.z + 90);
                backWheel.transform.rotation = Quaternion.RotateTowards(backWheel.transform.rotation,
                    qua2, 100);
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

            if (forward == null && back == null)
            {
                forward = Instantiate(emptyObject, this.transform);
                Vector3 temp1 = forward.transform.position;
                temp1.y -= 10;
                forward.transform.position = temp1;

                Quaternion qua1 = Quaternion.LookRotation(Vector3.forward, forward.transform.position -
                    forwardWheel.transform.position);
                qua1 = Quaternion.Euler(0, 0, qua1.eulerAngles.z - 90);
                forwardWheel.transform.rotation = Quaternion.RotateTowards(forwardWheel.transform.rotation,
                    qua1, 100);
                ////////////////////////////////////////////////////////////
                back = Instantiate(emptyObject, this.transform);
                Vector3 temp2 = back.transform.position;
                temp2.y -= 10;
                back.transform.position = temp2;

                Quaternion qua2 = Quaternion.LookRotation(Vector3.forward, forward.transform.position -
                    backWheel.transform.position);
                qua2 = Quaternion.Euler(0, 0, qua2.eulerAngles.z - 90);
                backWheel.transform.rotation = Quaternion.RotateTowards(backWheel.transform.rotation,
                    qua2, 100);
            }
        }

        if (uiControl.moveLeft == false && uiControl.moveRight == false && uiControl.moveUp == false &&
            uiControl.moveDown == false)
        {
            targetJoint.enabled = true;
            tempMoveSpeed = 0;
            //
            Destroy(back.gameObject);
            Destroy(forward.gameObject);
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
