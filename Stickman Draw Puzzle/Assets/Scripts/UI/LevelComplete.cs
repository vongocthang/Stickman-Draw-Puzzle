using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    TempDrawLine drawLine;
    UIControl uiControl;

    public TMP_Text countLine;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public TMP_Text showCoin;


    // Start is called before the first frame update
    void Start()
    {
        drawLine = GameObject.Find("Draw Line").GetComponent<TempDrawLine>();
        uiControl = GameObject.Find("MainUI").GetComponent<UIControl>();

        ShowCountLine();
        ShowStar();
        ShowCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCountLine()
    {
        countLine.text = "Line: " + drawLine.countLine.ToString();
    }

    public void ShowStar()
    {
        if (uiControl.countStar == 2)
        {
            star3.SetActive(false);
        }
        if (uiControl.countStar == 1)
        {
            star3.SetActive(false);
            star2.SetActive(false);
        }
        if (uiControl.countStar == 0)
        {
            star3.SetActive(false);
            star2.SetActive(false);
            star1.SetActive(false);
        }
    }

    public void ShowCoin()
    {
        if(uiControl.countStar == 3)
        {
            showCoin.text = "+" + 200;
        }
        if (uiControl.countStar == 2)
        {
            showCoin.text = "+" + 100;
        }
        if (uiControl.countStar == 1)
        {
            showCoin.text = "+" + 50;
        }
        if (uiControl.countStar == 0)
        {
            showCoin.text = "+" + 0;
        }
    }
}
