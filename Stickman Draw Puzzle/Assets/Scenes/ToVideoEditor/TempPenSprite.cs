using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPenSprite : MonoBehaviour
{
    TempDrawLine drawLine;

    // Start is called before the first frame update
    void Start()
    {
        drawLine = GameObject.Find("Draw Line").GetComponent<TempDrawLine>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowDrawLine();
        ShowPenSpriteWhenDrawLine();
    }

    public void FollowDrawLine()
    {
        Vector3 a = drawLine.mousePos;
        a.z = -10;
        this.transform.position = a;
    }

    public void ShowPenSpriteWhenDrawLine()
    {
        if (drawLine.line != null)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
