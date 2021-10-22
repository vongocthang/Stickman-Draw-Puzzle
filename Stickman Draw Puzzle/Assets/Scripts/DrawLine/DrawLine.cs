﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject penSprite;
    public int countLine;

    public Gradient lineColor;
    public float linePointsMinDistance;
    public float lineWidth;

    public Line line;
    public CircleCollider2D circleCollider;

    Camera cam;

    //public GameObject pen;
    public float penMoveSpeed = 15f;
    public Vector2 penPosition;
    public Vector2 mousePosition;
    //Đối tượng con-dùng dể xác định va chạm với các đối tượng không đc vẽ xuyên qua
    public GameObject penCollider;
    public float distance;//Khoảng cách giữa Pen và Mouse

    public LayerMask blockLayer;//Dùng khi bắt đầu vẽ
    public bool drawing;//Đang vẽ
    public bool blocked;

    GameObject renderMiniCamera;

    UIControl uiControl;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        renderMiniCamera = GameObject.Find("RenderMiniCamera");
        renderMiniCamera.SetActive(false);

        uiControl = GameObject.Find("MainUI").GetComponent<UIControl>();
    }

    // Update is called once per frame
    void Update()
    {
        BeforeDraw();
        ChangePenSpeed();

        if (Input.GetMouseButtonDown(0))
        {
            SetUpPen();
            BeginDraw();
        }
        if (Input.GetMouseButton(0))
        {
            PenFollowMouse();
            Draw();
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndDraw();
        }

        PenCollider();
    }

    public void BeginDraw()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 2f, Vector2.zero, 1f, blockLayer);
        if (hit)
        {
            //Debug.Log("Layer này không thể vẽ lên");
        }
        else
        {
            line = Instantiate(linePrefab, new Vector2(0, 0), this.transform.rotation).GetComponent<Line>();
            line.UsePhysics(false);
            line.SetLineColor(lineColor);
            line.SetPointMinDistance(linePointsMinDistance);
            line.SetLineWidth(lineWidth);

            penSprite.SetActive(true);

            renderMiniCamera.SetActive(true);
        }
    }

    public void Draw()
    {
        penPosition = this.transform.position;
        
        RaycastHit2D hit = Physics2D.CircleCast(penPosition, lineWidth / 2f, Vector2.zero, 1f, blockLayer);
        if (hit)
        {
            
        }
        else
        {
            if (line == null)
            {
                BeginDraw();
            }

            circleCollider.isTrigger = false;
            line.AddPoint(penPosition);
        }
    }

    public void EndDraw()
    {
        if (line != null)
        {
            if (line.pointsCount < 2)
            {
                
            }
            else
            {
                
            }

            line.gameObject.tag = "Line";
            line.UsePhysics(true);
            countLine++;
            line = null;

            penSprite.SetActive(false);

            //Cập nhật hiển thị số nét vẽ còn lại cho mốc sao
            uiControl.tempCount--;
        }

        blocked = false;
        drawing = false;

        circleCollider.isTrigger = true;
        this.transform.position = new Vector2(0, 10);

        renderMiniCamera.SetActive(false);
    }

    public void SetUpPen()
    {
        this.transform.position = mousePosition;
    }

    public void PenFollowMouse()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, mousePosition, penMoveSpeed*Time.deltaTime);
    }

    public void PenCollider()
    {
        penCollider.transform.position = this.transform.position;
    }

    public void BeforeDraw()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        penPosition = this.transform.position;
    }

    public void ChangePenSpeed()
    {
        distance = Vector2.Distance(penPosition, mousePosition);
    }
}
