using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

//Điều khiển Car chung cho 3 chế độ đầu

public class CarControl : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float moveSpeed;
    //public float tempMoveSpeed;
    public TargetJoint2D targetJoint;
    public int countToON = 0;

    public SkeletonAnimation skeletonAnim;

    //Để xác định con dốc nằm ở bên nào
    //Từ đó xác định di chuyển trái/phải là xuống dốc
    public float zRotation;

    UIControl uiControl;

    public float countTime;//Đếm thời gian chuyển Anim Idle 1-4;

    public int countAnim = 1;//Thứ tự Animation đang hiển thị

    public AudioSource backLoop;

    // Start is called before the first frame update
    void Start()
    {
        uiControl = GameObject.Find("MainUI").GetComponent<UIControl>();
        targetJoint = this.GetComponent<TargetJoint2D>();

        backLoop = GameObject.Find("Truck_back_loop").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Debug.Log(countToON);
    }

    public void Move()
    {
        zRotation = this.transform.rotation.z;

        if (uiControl.moveLeft == true)
        {
            targetJoint.enabled = false;
            //Animation
            countAnim = 1;
            if (this.name == "CarLeft")
            {
                skeletonAnim.AnimationName = "Forward";
                backLoop.enabled = false;
            }
            else
            {
                skeletonAnim.AnimationName = "Backward";
                backLoop.enabled = true;
            }

            if (zRotation > 0.02)
            {
                //Debug.Log("Xuống dốc phải");
            }
            else
            {
                if (countToON >= 2)
                {
                    //rb2D.velocity = new Vector2(tempMoveSpeed * Time.deltaTime, 0f);
                    rb2D.velocity = new Vector2(-moveSpeed * Time.deltaTime, 0f);
                }
                //Debug.Log("Lên dốc trái");
                //rb2D.velocity = new Vector2(tempMoveSpeed * Time.deltaTime, 0f);
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
                backLoop.enabled = true;
            }
            else
            {
                skeletonAnim.AnimationName = "Forward";
                backLoop.enabled = false;
            }

            if (zRotation < -0.02)
            {
                //Debug.Log("Xuống dốc trái");
            }
            else
            {
                if (countToON >= 2)
                {
                    //rb2D.velocity = new Vector2(tempMoveSpeed * Time.deltaTime, 0f);
                    rb2D.velocity = new Vector2(moveSpeed * Time.deltaTime, 0f);
                }
                //Debug.Log("Lên dốc phải");
                //rb2D.velocity = new Vector2(tempMoveSpeed * Time.deltaTime, 0f);
            }
        }

        if(uiControl.moveLeft==false && uiControl.moveRight == false)
        {
            //Nếu cả 2 bánh xe chạm vào bề mặt thì bật targetJoint để xe dứng yên ngay lập tức
            if (countToON == 2)
            {
                targetJoint.enabled = true;
            }
            else
            {
                targetJoint.enabled = false;
            }

            //Animation
            if(Time.time < countTime + 5)
            {
                skeletonAnim.AnimationName = "Idle " + countAnim.ToString();
            }
            else
            {
                if (countAnim == 4)
                {
                    countAnim = 1;
                    return;
                }
                countAnim++;
                countTime = Time.time;
            }

            backLoop.enabled = false;
        }
    }
}
