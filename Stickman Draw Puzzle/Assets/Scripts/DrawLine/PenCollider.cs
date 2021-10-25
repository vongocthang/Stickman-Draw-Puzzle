﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dùng để tăng giảm tốc độ của Pen khi tiếp xúc với các đôi tượng không thể vẽ xuyên qua
//Giảm tốc để không vẽ xuyên qua + tính năng vẽ men theo cạnh của đối tượng
//Khi hết tiếp xúc thì tăng tốc để Pen không bị delay khi follow Con trỏ
public class PenCollider : MonoBehaviour
{
    public DrawLine pen;
    //Đếm số đối tượng đang tiếp xúc với Pen
    //Tránh khi Pen thoát khỏi đối tượng 1 mà đối tượng 2 quá gần
    //Tăng tốc phát 1 dẫn tới xuyên qua đối tượng 2
    public int countCollision = 0;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Wall" || collision.tag == "Line"
    //        || collision.tag == "Barrier" || collision.tag == "Wheel" || collision.tag == "Box"
    //        || collision.tag == "Wood")
    //    {
    //        //Debug.Log("Bị chặn bởi "+collision.gameObject.name);
    //        countCollision++;
    //        pen.penMoveSpeed = 0f;
            
    //        //Làm đối tượng không bị tác dụng lực bởi Pen khi tiếp xúc
    //        collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    //    }

    //    //Car riêng vì có nhiều bộ phận ghép thành
    //    if (collision.tag == "Car")
    //    {
    //        //Debug.Log("Bị chặn bởi " + collision.gameObject.name);
    //        countCollision++;
    //        pen.penMoveSpeed = 0f;

    //        //Làm đối tượng không bị tác dụng lực bởi Pen khi tiếp xúc
    //        collision.gameObject.GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{

    //    //if (collision.tag == "Wall" || collision.tag == "Car" || collision.tag == "Line"
    //    //    || collision.tag == "Barrier" || collision.tag == "Wheel" || collision.tag == "Box"
    //    //    || collision.tag == "Wood")
    //    //{
    //    //    if (pen.penMoveSpeed < 2f)
    //    //    {
    //    //        pen.penMoveSpeed += 0.5f;
    //    //    }
    //    //}

    //    if (collision.tag == "Wall" || collision.tag == "Line"
    //        || collision.tag == "Barrier" || collision.tag == "Wheel" || collision.tag == "Box"
    //        || collision.tag == "Wood")
    //    {
    //        if (pen.penMoveSpeed < 2f)
    //        {
    //            pen.penMoveSpeed += 0.2f;
    //        }

    //        //Làm đối tượng không bị tác dụng lực bởi Pen khi tiếp xúc
    //        collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    //    }

    //    //Car riêng vì có nhiều bộ phận ghép thành
    //    if (collision.tag == "Car")
    //    {
    //        if (pen.penMoveSpeed < 2f)
    //        {
    //            pen.penMoveSpeed += 0.2f;
    //        }

    //        //Làm đối tượng không bị tác dụng lực bởi Pen khi tiếp xúc
    //        collision.gameObject.GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Wall" || collision.tag == "Line"
    //        || collision.tag == "Barrier" || collision.tag == "Wheel" || collision.tag == "Box"
    //        || collision.tag == "Wood")
    //    {
    //        //Debug.Log("Thoat chan");
    //        if (countCollision > 1)
    //        {
    //            countCollision--;
    //        }
    //        else
    //        {
    //            countCollision--;

    //            while (pen.penMoveSpeed < 15f)
    //            {
    //                pen.penMoveSpeed += 0.0001f;
    //            }
    //        }
    //        //Mở tác dụng lực trở lại
    //        collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    //    }
    //    //Car riêng vì có nhiều bộ phận ghép thành
    //    if (collision.tag == "Car")
    //    {
    //        //Debug.Log("Thoat chan");
    //        if (countCollision > 1)
    //        {
    //            countCollision--;
    //        }
    //        else
    //        {
    //            countCollision--;

    //            while (pen.penMoveSpeed < 15f)
    //            {
    //                pen.penMoveSpeed += 0.0001f;
    //            }
    //        }

    //        collision.gameObject.GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    //    }
    //}
}
