﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDrawLine : MonoBehaviour
{
    Camera cam;
    public Line line;
    public GameObject linePrefab;
    public Gradient lineColor;
    public float linePointsMinDistance;
    public float lineWidth;

    public Vector2 mousePos;
    public Vector2 lastPoint;
    public LayerMask blockLayer;

    public bool blocked = false;
    public bool drawing = false;
    RaycastHit2D hit;

    Line tempLine;
    public GameObject tempLinePrefab;
    public Gradient tempLineColor;
    public List<Vector2> points = new List<Vector2>();

    public UIControl uiControl;

    //Phải tắt tác dụng lực khi vẽ
    public GameObject[] conLac;
    public GameObject[] bapBenh;
    public GameObject car;
    public GameObject box;
    public GameObject[] lineDrew;
    public GameObject[] gaiXoay;

    public int countLine = 0;


    void Start()
    {
        cam = Camera.main;

        uiControl = GameObject.Find("MainUI").GetComponent<UIControl>();

        if (conLac.Length == 1)
        {
            conLac[0] = GameObject.Find("Pendulum");
        }

        if (bapBenh.Length == 1)
        {
            bapBenh[0] = GameObject.Find("Seesaw (1)");
        }
        else if (bapBenh.Length == 2)
        {
            bapBenh[0] = GameObject.Find("Seesaw (1)");
            bapBenh[1] = GameObject.Find("Seesaw (2)");
        }

        if (GameObject.Find("CarLeft") != null)
        {
            car = GameObject.Find("CarLeft");
        }
        if (GameObject.Find("CarRight") != null)
        {
            car = GameObject.Find("CarRight");
        }

        box = GameObject.Find("Box");
        gaiXoay = GameObject.FindGameObjectsWithTag("GaiXoay");
    }

    // Update is called once per frame
    void Update()
    {
        StopPhysics();

        CheckBlockLayer();

        if (Input.GetMouseButtonDown(0))
        {
            if (hit)
            {
                blocked = true;
            }
            else
            {
                BeginDraw();
            }
        }
        if (Input.GetMouseButton(0))
        {
            Draw();
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndDraw();
        }

        if (tempLine != null)
        {

        }
    }

    public void BeginDraw()
    {
        line = Instantiate(linePrefab, this.transform).GetComponent<Line>();
        line.UsePhysics(false);
        line.SetLineColor(lineColor);
        line.SetPointMinDistance(linePointsMinDistance);
        line.SetLineWidth(lineWidth);
    }
    public void BeginTempDraw()
    {
        tempLine = Instantiate(tempLinePrefab, this.transform).GetComponent<Line>();
        tempLine.SetLineColor(tempLineColor);
        tempLine.SetPointMinDistance(linePointsMinDistance);
        tempLine.SetLineWidth(lineWidth);
        lastPoint = line.GetLastPoint();
        tempLine.lineRenderer.positionCount = 2;
        tempLine.lineRenderer.SetPosition(0, lastPoint);
    }

    public void Draw()
    {
        if (hit)
        {
            if (line == null)
            {
                blocked = true;
            }
            else
            {
                if (blocked == false)
                {
                    BeginTempDraw();
                    blocked = true;
                }
                else
                {
                    blocked = true;
                }
            }
        }
        else
        {

            if (line == null)
            {
                Debug.Log("Bắt đầu vẽ khi đưa chuột khỏi vị trí bị chặn");
                BeginDraw();
                blocked = false;
            }
            else
            {
                if (blocked == true)
                {
                    if (tempLine.blocked == true)
                    {

                    }
                    else
                    {
                        blocked = false;
                        line.AddPoint(mousePos);
                        Destroy(tempLine.gameObject);
                        tempLine = null;
                    }
                }
                else
                {
                    line.AddPoint(mousePos);
                }
            }
        }

        if (blocked == true && tempLine != null)
        {
            Debug.Log("Vẽ Temp Line");
            tempLine.lineRenderer.SetPosition(1, mousePos);
            points.Clear();
            points.Add(lastPoint);
            points.Add(mousePos);
            tempLine.edgeCollider.points = points.ToArray();
        }
    }

    public void EndDraw()
    {
        if (line != null)
        {
            line.gameObject.tag = "Line";
            line.gameObject.layer = 8;
            line.UsePhysics(true);
            line = null;
            if (uiControl.countStar >= 1)
            {
                uiControl.tempCount--;
            }

            countLine++;
        }
        if (tempLine != null)
        {
            Destroy(tempLine.gameObject);
            tempLine = null;
        }
        blocked = false;
    }

    public void CheckBlockLayer()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.CircleCast(mousePos, lineWidth, Vector2.zero, 1f, blockLayer);
    }

    public void StopPhysics()
    {
        if (conLac.Length > 0)
        {
            if (line != null)
            {
                for (int i = 0; i < conLac.Length; i++)
                {
                    conLac[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                }
            }
            else
            {
                for (int i = 0; i < conLac.Length; i++)
                {
                    conLac[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }


        if (bapBenh.Length > 0)
        {
            if (line != null)
            {
                for (int i = 0; i < bapBenh.Length; i++)
                {
                    bapBenh[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                }
            }
            else
            {
                for (int i = 0; i < bapBenh.Length; i++)
                {
                    bapBenh[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }

        if (line != null)
        {
            car.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            box.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            for (int i = 0; i < gaiXoay.Length; i++)
            {
                gaiXoay[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
        else
        {
            car.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            box.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            for (int i = 0; i < gaiXoay.Length; i++)
            {
                gaiXoay[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }

        lineDrew = GameObject.FindGameObjectsWithTag("Line");
        if (lineDrew.Length > 0)
        {
            if (line != null)
            {
                for (int i = 0; i < lineDrew.Length; i++)
                {
                    lineDrew[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                }
            }
            else
            {
                for (int i = 0; i < lineDrew.Length; i++)
                {
                    lineDrew[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
    }
}