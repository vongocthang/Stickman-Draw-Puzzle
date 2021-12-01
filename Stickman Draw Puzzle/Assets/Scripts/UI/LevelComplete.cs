using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//Quản lý các tác vụ trên giao diện khi Complete Level
//Đặt tại MainUI/WinLevel

public class LevelComplete : MonoBehaviour
{
    TempDrawLine drawLine;
    UIControl uiControl;

    public TMP_Text countLine;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public TMP_Text showCoin;
    public int tempCoin;

    public GameObject claimPen1;
    public GameObject claimPen2;
    public GameObject claimPen3;
    public GameObject claimPen4;
    public GameObject claimPen5;


    // Start is called before the first frame update
    void Start()
    {
        drawLine = GameObject.Find("Draw Line").GetComponent<TempDrawLine>();
        uiControl = GameObject.Find("MainUI").GetComponent<UIControl>();

        ShowCountLine();
        ShowStar();
        ShowCoin();
        LoadClaimPen();


        //Debug.Log(PlayerPrefs.GetInt("Pen"));
        //Debug.Log(PlayerPrefs.GetInt("ClaimPen"));
    }

    public void ShowCountLine()
    {
        countLine.text = "Line: " + drawLine.countLine.ToString();
    }

    public void ShowStar()
    {
        //Debug.Log("So sao cua lan choi nay= " + uiControl.countStar);
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
            //Chế độ 1
            if (SceneManager.GetActiveScene().buildIndex <= 90)
            {
                int a = PlayerPrefs.GetInt("M1StarLevel" + SceneManager.GetActiveScene().buildIndex.ToString());
                //Debug.Log("So sao da dat dc truoc do= " + a);
                if (uiControl.countStar > a)
                {
                    if (uiControl.countStar - a == 1)
                    {
                        showCoin.text = "+" + (100).ToString();
                        tempCoin = 100;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
                    }
                    if (uiControl.countStar - a == 2)
                    {
                        showCoin.text = "+" + (150).ToString();
                        tempCoin = 150;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 150);
                    }
                    if (uiControl.countStar - a == 3)
                    {
                        showCoin.text = "+" + (200).ToString();
                        tempCoin = 200;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 200);
                    }
                    PlayerPrefs.SetInt("M1StarLevel" + SceneManager.GetActiveScene().buildIndex.ToString(), uiControl.countStar);
                }
                else
                {
                    showCoin.text = "+" + (0).ToString();
                }
            }
            else
            //Chế độ 2
            if (SceneManager.GetActiveScene().buildIndex <= 110)
            {
                int a = PlayerPrefs.GetInt("M2StarLevel" + (SceneManager.GetActiveScene().buildIndex - 90).ToString());
                //Debug.Log("So sao da dat dc truoc do= " + a);
                if (uiControl.countStar > a)
                {
                    if (uiControl.countStar - a == 1)
                    {
                        showCoin.text = "+" + (100).ToString();
                        tempCoin = 100;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
                    }
                    if (uiControl.countStar - a == 2)
                    {
                        showCoin.text = "+" + (150).ToString();
                        tempCoin = 150;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 150);
                    }
                    if (uiControl.countStar - a == 3)
                    {
                        showCoin.text = "+" + (200).ToString();
                        tempCoin = 200;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 200);
                    }
                    PlayerPrefs.SetInt("M2StarLevel" + (SceneManager.GetActiveScene().buildIndex - 90).ToString(), uiControl.countStar);
                }
                else
                {
                    showCoin.text = "+" + (0).ToString();
                }
            }
            else
            //Chế độ 3
            if (SceneManager.GetActiveScene().buildIndex <= 130)
            {
                int a = PlayerPrefs.GetInt("M3StarLevel" + (SceneManager.GetActiveScene().buildIndex - 110).ToString());
                //Debug.Log("So sao da dat dc truoc do= " + a);
                if (uiControl.countStar > a)
                {
                    if (uiControl.countStar - a == 1)
                    {
                        showCoin.text = "+" + (100).ToString();
                        tempCoin = 100;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
                    }
                    if (uiControl.countStar - a == 2)
                    {
                        showCoin.text = "+" + (150).ToString();
                        tempCoin = 150;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 150);
                    }
                    if (uiControl.countStar - a == 3)
                    {
                        showCoin.text = "+" + (200).ToString();
                        tempCoin = 200;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 200);
                    }
                    PlayerPrefs.SetInt("M3StarLevel" + (SceneManager.GetActiveScene().buildIndex - 110).ToString(), uiControl.countStar);
                }
                else
                {
                    showCoin.text = "+" + (0).ToString();
                }
            }
            else
            //Chế độ 4
            if (SceneManager.GetActiveScene().buildIndex <= 150)
            {
                int a = PlayerPrefs.GetInt("M4StarLevel" + (SceneManager.GetActiveScene().buildIndex - 130).ToString());
                //Debug.Log("So sao da dat dc truoc do= " + a);
                if (uiControl.countStar > a)
                {
                    if (uiControl.countStar - a == 1)
                    {
                        showCoin.text = "+" + (100).ToString();
                        tempCoin = 100;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
                    }
                    if (uiControl.countStar - a == 2)
                    {
                        showCoin.text = "+" + (150).ToString();
                        tempCoin = 150;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 150);
                    }
                    if (uiControl.countStar - a == 3)
                    {
                        showCoin.text = "+" + (200).ToString();
                        tempCoin = 200;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 200);
                    }
                    PlayerPrefs.SetInt("M4StarLevel" + (SceneManager.GetActiveScene().buildIndex - 130).ToString(), uiControl.countStar);
                }
                else
                {
                    showCoin.text = "+" + (0).ToString();
                }
            }
        }
        /////////////////////////////
        if (uiControl.countStar == 2)
        {
            //Chế độ 1
            if(SceneManager.GetActiveScene().buildIndex <= 90)
            {
                int a = PlayerPrefs.GetInt("M1StarLevel" + SceneManager.GetActiveScene().buildIndex.ToString());
                //Debug.Log("So sao da dat dc truoc do= " + a);
                if (uiControl.countStar > a)
                {
                    if (uiControl.countStar - a == 1)
                    {
                        showCoin.text = "+" + (50).ToString();
                        tempCoin = 50;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 50);
                    }
                    if (uiControl.countStar - a == 2)
                    {
                        showCoin.text = "+" + (100).ToString();
                        tempCoin = 100;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
                    }
                    PlayerPrefs.SetInt("M1StarLevel" + SceneManager.GetActiveScene().buildIndex.ToString(), uiControl.countStar);
                }
                else
                {
                    showCoin.text = "+" + (0).ToString();
                }
            }
            else
            //Chế độ 2
            if (SceneManager.GetActiveScene().buildIndex <= 110)
            {
                int a = PlayerPrefs.GetInt("M2StarLevel" + (SceneManager.GetActiveScene().buildIndex - 90).ToString());
                //Debug.Log("So sao da dat dc truoc do= " + a);
                if (uiControl.countStar > a)
                {
                    if (uiControl.countStar - a == 1)
                    {
                        showCoin.text = "+" + (50).ToString();
                        tempCoin = 50;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 50);
                    }
                    if (uiControl.countStar - a == 2)
                    {
                        showCoin.text = "+" + (100).ToString();
                        tempCoin = 100;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
                    }
                    PlayerPrefs.SetInt("M2StarLevel" + (SceneManager.GetActiveScene().buildIndex - 90).ToString(), uiControl.countStar);
                }
                else
                {
                    showCoin.text = "+" + (0).ToString();
                }
            }
            else
            //Chế độ 3
            if (SceneManager.GetActiveScene().buildIndex <= 130)
            {
                int a = PlayerPrefs.GetInt("M3StarLevel" + (SceneManager.GetActiveScene().buildIndex - 110).ToString());
                //Debug.Log("So sao da dat dc truoc do= " + a);
                if (uiControl.countStar > a)
                {
                    if (uiControl.countStar - a == 1)
                    {
                        showCoin.text = "+" + (50).ToString();
                        tempCoin = 50;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 50);
                    }
                    if (uiControl.countStar - a == 2)
                    {
                        showCoin.text = "+" + (100).ToString();
                        tempCoin = 100;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
                    }
                    PlayerPrefs.SetInt("M3StarLevel" + (SceneManager.GetActiveScene().buildIndex - 110).ToString(), uiControl.countStar);
                }
                else
                {
                    showCoin.text = "+" + (0).ToString();
                }
            }
            else
            //Chế độ 4
            if (SceneManager.GetActiveScene().buildIndex <= 150)
            {
                int a = PlayerPrefs.GetInt("M4StarLevel" + (SceneManager.GetActiveScene().buildIndex - 130).ToString());
                //Debug.Log("So sao da dat dc truoc do= " + a);
                if (uiControl.countStar > a)
                {
                    if (uiControl.countStar - a == 1)
                    {
                        showCoin.text = "+" + (50).ToString();
                        tempCoin = 50;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 50);
                    }
                    if (uiControl.countStar - a == 2)
                    {
                        showCoin.text = "+" + (100).ToString();
                        tempCoin = 100;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 100);
                    }
                    PlayerPrefs.SetInt("M4StarLevel" + (SceneManager.GetActiveScene().buildIndex - 130).ToString(), uiControl.countStar);
                }
                else
                {
                    showCoin.text = "+" + (0).ToString();
                }
            }
        }
        /////////////////////////////
        if (uiControl.countStar == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex <= 90)
            {
                int a = PlayerPrefs.GetInt("M1StarLevel" + SceneManager.GetActiveScene().buildIndex.ToString());
                //Debug.Log("So sao da dat dc truoc do= " + a);
                if (uiControl.countStar > a)
                {
                    if (uiControl.countStar - a == 1)
                    {
                        showCoin.text = "+" + (50).ToString();
                        tempCoin = 50;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 50);
                    }
                    PlayerPrefs.SetInt("M1StarLevel" + SceneManager.GetActiveScene().buildIndex.ToString(), uiControl.countStar);
                }
                else
                {
                    showCoin.text = "+" + (0).ToString();
                }
            }
            else
            //Chế độ 2
            if (SceneManager.GetActiveScene().buildIndex <= 110)
            {
                int a = PlayerPrefs.GetInt("M2StarLevel" + (SceneManager.GetActiveScene().buildIndex - 90).ToString());
                //Debug.Log("So sao da dat dc truoc do= " + a);
                if (uiControl.countStar > a)
                {
                    if (uiControl.countStar - a == 1)
                    {
                        showCoin.text = "+" + (50).ToString();
                        tempCoin = 50;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 50);
                    }
                    PlayerPrefs.SetInt("M2StarLevel" + (SceneManager.GetActiveScene().buildIndex - 90).ToString(), uiControl.countStar);
                }
                else
                {
                    showCoin.text = "+" + (0).ToString();
                }
            }
            else
            //Chế độ 3
            if (SceneManager.GetActiveScene().buildIndex <= 130)
            {
                int a = PlayerPrefs.GetInt("M3StarLevel" + (SceneManager.GetActiveScene().buildIndex - 110).ToString());
                //Debug.Log("So sao da dat dc truoc do= " + a);
                if (uiControl.countStar > a)
                {
                    if (uiControl.countStar - a == 1)
                    {
                        showCoin.text = "+" + (50).ToString();
                        tempCoin = 50;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 50);
                    }
                    PlayerPrefs.SetInt("M3StarLevel" + (SceneManager.GetActiveScene().buildIndex - 110).ToString(), uiControl.countStar);
                }
                else
                {
                    showCoin.text = "+" + (0).ToString();
                }
            }
            else
            //Chế độ 4
            if (SceneManager.GetActiveScene().buildIndex <= 150)
            {
                int a = PlayerPrefs.GetInt("M4StarLevel" + (SceneManager.GetActiveScene().buildIndex - 130).ToString());
                //Debug.Log("So sao da dat dc truoc do= " + a);
                if (uiControl.countStar > a)
                {
                    if (uiControl.countStar - a == 1)
                    {
                        showCoin.text = "+" + (50).ToString();
                        tempCoin = 50;
                        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 50);
                    }
                    PlayerPrefs.SetInt("M4StarLevel" + (SceneManager.GetActiveScene().buildIndex - 130).ToString(), uiControl.countStar);
                }
                else
                {
                    showCoin.text = "+" + (0).ToString();
                }
            }
        }
        /////////////////////////////
        if (uiControl.countStar == 0)
        {
            showCoin.text = "+" + (0).ToString();
            tempCoin = 0;
        }
    }

    //X2 Coin khi xem Video
    public void WatchVideoX2Coin()
    {
        showCoin.text = "+" + (tempCoin * 2).ToString();
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + tempCoin);
    }

    public void LoadClaimPen()
    {
        if (PlayerPrefs.GetInt("ClaimPen") == 1)
        {
            claimPen2.SetActive(false);
            claimPen3.SetActive(false);
            claimPen4.SetActive(false);
            claimPen5.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ClaimPen") == 2)
        {
            claimPen1.SetActive(false);
            claimPen3.SetActive(false);
            claimPen4.SetActive(false);
            claimPen5.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ClaimPen") == 3)
        {
            claimPen1.SetActive(false);
            claimPen2.SetActive(false);
            claimPen4.SetActive(false);
            claimPen5.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ClaimPen") == 4)
        {
            claimPen1.SetActive(false);
            claimPen2.SetActive(false);
            claimPen3.SetActive(false);
            claimPen5.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ClaimPen") == 5)
        {
            claimPen1.SetActive(false);
            claimPen2.SetActive(false);
            claimPen3.SetActive(false);
            claimPen4.SetActive(false);
        }
    }


}
