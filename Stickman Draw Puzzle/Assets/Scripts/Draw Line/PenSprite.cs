using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenSprite : MonoBehaviour
{
    TempDrawLine drawLine;

    public GameObject penSprite;

    UIControl uiControl;

    // Start is called before the first frame update
    void Start()
    {
        SetupPenSprite();
        drawLine = GameObject.Find("Draw Line").GetComponent<TempDrawLine>();
        uiControl = GameObject.Find("MainUI").GetComponent<UIControl>();
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

    public void SetupPenSprite()
    {
        penSprite = this.transform.GetChild(PlayerPrefs.GetInt("Pen")).gameObject;
        
    }

    public void ShowPenSpriteWhenDrawLine()
    {
        if (drawLine.line != null && uiControl.stopDrawLine == false)
        {
            penSprite.SetActive(true);
        }
        else
        {
            penSprite.SetActive(false);
        }
    }
}
