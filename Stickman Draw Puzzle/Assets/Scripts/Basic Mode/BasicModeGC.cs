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

    float threeSecond = 3;
    float tempSecond = 0;

    //Điều khiển thanh nâng của xe
    public bool up, down;

    public UIControl uiControl;

    TempDrawLine drawLine;

    GameObject phaoHoa;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Target").GetComponent<Target>();
        drawLine = GameObject.Find("Draw Line").GetComponent<TempDrawLine>();

        phaoHoa = GameObject.Find("Phao Hoa");
        phaoHoa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WinGame();
        CountTimeWin();
    }

    public void WinGame()
    {
        if (threeSecond == 0)
        {
            countTime.enabled = false;
            //Tắt vẽ Line
            drawLine.enabled = false;

            int a = PlayerPrefs.GetInt("SceneUnlockedBM");
            if (a < SceneManager.GetActiveScene().buildIndex + 1)
            {
                PlayerPrefs.SetInt("SceneUnlockedBM", SceneManager.GetActiveScene().buildIndex + 1);
            }

            phaoHoa.SetActive(true);
            

            StartCoroutine(ActiveWinGame());
        }

    }

    //Đếm thời gian
    public void CountTimeWin()
    {
        if (target.beginCountTime == true)
        {
            if (Time.time > target.timeLine + tempSecond + 1)
            {
                if (tempSecond < 3)
                {
                    threeSecond--;
                    tempSecond++;
                    countTime.text = threeSecond.ToString();
                }
                
            }
            countTime.enabled = true;
        }

        if (target.beginCountTime == false)
        {
            countTime.text = 3.ToString();
            threeSecond = 3;
            tempSecond = 0;
            countTime.enabled = false;
        }
    }

    IEnumerator ActiveWinGame()
    {
        yield return new WaitForSeconds(3.2f);

        winGame.SetActive(true);
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
