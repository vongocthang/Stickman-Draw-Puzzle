using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CollectWoodGC : MonoBehaviour
{
    public GameObject winGame;
    public TMP_Text countTime;

    public int countWood;
    public bool beginCountTime;


    public float timeLine;
    public float threeSecond = 0;

    public TempDrawLine drawLine;

    // Start is called before the first frame update
    void Start()
    {
        drawLine = GameObject.Find("Draw Line").GetComponent<TempDrawLine>();
    }

    // Update is called once per frame
    void Update()
    {
        WinGame();
        //BeginCountTime();
        CountTimeWin();
    }

    public void WinGame()
    {
        if (threeSecond >= 3)
        {
            drawLine.enabled = false;

            int a = PlayerPrefs.GetInt("SceneUnlockedBM");
            if (a < SceneManager.GetActiveScene().buildIndex + 1)
            {
                PlayerPrefs.SetInt("SceneUnlockedBM", SceneManager.GetActiveScene().buildIndex + 1);
            }

            StartCoroutine(DisabledCountTime());
        }
    }


    //Đếm thời gian
    public void CountTimeWin()
    {
        //Điều kiện thỏa mãn để bắt đầu đếm
        if (beginCountTime == true)
        {
            countTime.enabled = true;
            if (Time.time > timeLine + threeSecond + 1)
            {
                threeSecond++;
                countTime.text = threeSecond.ToString();
            }
        }

        //Nếu đang đếm mà điều kiện không thỏa mãn nữa thì
        if (countTime.enabled == true && beginCountTime == false)
        {
            countTime.enabled = false;
            threeSecond = 0;
            countTime.text = 0.ToString();
        }
    }

    IEnumerator DisabledCountTime()
    {
        yield return new WaitForSeconds(0.5f);

        winGame.SetActive(true);
        beginCountTime = false;
    }
}
