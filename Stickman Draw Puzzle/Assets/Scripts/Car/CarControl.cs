using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float moveSpeed;
    public float tempMoveSpeed;

    //Để xác định con dốc nằm ở bên nào
    //Từ đó xác định di chuyển trái/phải là xuống dốc
    public float zRotation;

    UIControl uiControl;


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
        zRotation = this.transform.rotation.z;

        if (uiControl.moveLeft == true)
        {
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
                //Debug.Log("Lên dốc trái");
                rb2D.velocity = new Vector2(tempMoveSpeed * Time.deltaTime, 0f);
            }
        }

        if (uiControl.moveRight == true)
        {
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
                //Debug.Log("Lên dốc phải");
                rb2D.velocity = new Vector2(tempMoveSpeed * Time.deltaTime, 0f);
            }
        }

        if(uiControl.moveLeft==false && uiControl.moveRight == false)
        {
            tempMoveSpeed = 0;
        }
    }
}
