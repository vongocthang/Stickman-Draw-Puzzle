﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Rigidbody2D rb;
    public EdgeCollider2D edgeCollider;
    float circleColliderRadius;

    public int pointsCount = 0;
    public List<Vector2> points = new List<Vector2>();

    public float pointsMinDistance;

    //
    public bool blocked;

    public void AddPoint(Vector2 newPoint)
    {
        if (pointsCount >= 2 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
        {
            return;
        }

        points.Add(newPoint);
        pointsCount++;

        lineRenderer.positionCount = pointsCount;
        lineRenderer.SetPosition(pointsCount - 1, newPoint);

        if (pointsCount > 1)
        {
            edgeCollider.points = points.ToArray();
        }

        CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
        circleCollider.offset = newPoint;
        circleCollider.radius = circleColliderRadius;
    }

    public Vector2 GetLastPoint()
    {
        return lineRenderer.GetPosition(pointsCount - 1);
    }

    public void SetLineColor(Gradient color)
    {
        lineRenderer.colorGradient = color;
    }

    public void UsePhysics(bool usePhysics)
    {
        rb.simulated = usePhysics;
    }

    public void SetPointMinDistance(float distance)
    {
        pointsMinDistance = distance;
    }

    public void SetLineWidth(float width)
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        edgeCollider.edgeRadius = width / 2f;
        circleColliderRadius = width / 2f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Wall" || collision.tag == "Line" || collision.tag == "Barrier" || 
            collision.tag == "Wheel" || collision.tag == "Box" || collision.tag == "Wood")
        {
            Debug.Log("Va chạm với: " + collision.tag);
            blocked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall" || collision.tag == "Barrier" || collision.tag == "Wheel" || 
            collision.tag == "Box" || collision.tag == "Wood")
        {
            Debug.Log("Thoát khỏi: " + collision.tag);
            blocked = false;

        }
        if (collision.tag == "Line")
        {
            Debug.Log("Thoát khỏi Line");
            if (collision.GetType() == edgeCollider.GetType())
            {
                Debug.Log("Thoát khỏi: " + collision.GetType() + " của Line");
                blocked = false;
            }
        }
    }
}
