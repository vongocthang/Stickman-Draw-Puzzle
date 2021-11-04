using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//Điều khiển chế độ Basic
public class BasicModeGC : MonoBehaviour
{
    Target target;
    public GameObject winGame;
    public TMP_Text countTime;

    float threeSecond = 0;

    //Điều khiển thanh nâng của xe
    public bool up, down;

    public UIControl uiControl;

    TempDrawLine drawLine;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Target").GetComponent<Target>();
        drawLine = GameObject.Find("Draw Line").GetComponent<TempDrawLine>();
    }

    // Update is called once per frame
    void Update()
    {
        WinGame();
        CountTimeWin();
    }

    public void WinGame()
    {
        if (threeSecond >= 3)
        {
            //Tắt vẽ Line
            drawLine.enabled = false;

            int a = PlayerPrefs.GetInt("SceneUnlockedBM");
            if (a < SceneManager.GetActiveScene().buildIndex + 1)
            {
                PlayerPrefs.SetInt("SceneUnlockedBM", SceneManager.GetActiveScene().buildIndex + 1);
            }
            
            //int b = PlayerPrefs.GetInt("StarLevel" + SceneManager.GetActiveScene().buildIndex.ToString());
            //if (b < uiControl.countStar)
            //{
            //    PlayerPrefs.SetInt("StarLevel" + SceneManager.GetActiveScene().buildIndex.ToString(), uiControl.countStar);
            //    //Debug.Log("Sao dat dc= " + PlayerPrefs.GetInt("StarLevel" + SceneManager.GetActiveScene().buildIndex.ToString()));
            //}
            

            StartCoroutine(DisabledCountTime());
        }

    }

    //Đếm thời gian
    public void CountTimeWin()
    {
        if (target.beginCountTime == true)
        {
            countTime.enabled = true;

            if (Time.time > target.timeLine + threeSecond + 1)
            {
                threeSecond++;
                countTime.text = threeSecond.ToString();
            }
        }

        if (target.beginCountTime == false)
        {
            countTime.text = 0.ToString();
            threeSecond = 0;
            countTime.enabled = false;
        }
    }

    IEnumerator DisabledCountTime()
    {
        yield return new WaitForSeconds(0.5f);

        winGame.SetActive(true);
        target.beginCountTime = false;
    }

    //Điều khiển nâng
    public void ElevateUp()
    {
        up = true;
    }

    public void ElevateDown()
    {
        down = true;
    }

    public void NotElevate()
    {
        up = false;
        down = false;
    }
}
