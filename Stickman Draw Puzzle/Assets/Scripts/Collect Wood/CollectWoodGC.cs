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
    float threeSecond = 3;
    float tempSecond = 0;


    public TempDrawLine drawLine;

    GameObject phaoHoa;

    // Start is called before the first frame update
    void Start()
    {
        drawLine = GameObject.Find("Draw Line").GetComponent<TempDrawLine>();

        phaoHoa = GameObject.Find("Phao Hoa");
        phaoHoa.SetActive(false);
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
        if (threeSecond == 0)
        {
            drawLine.enabled = false;

            int a = PlayerPrefs.GetInt("SceneUnlockedBM");
            if (a < SceneManager.GetActiveScene().buildIndex + 1)
            {
                PlayerPrefs.SetInt("SceneUnlockedBM", SceneManager.GetActiveScene().buildIndex + 1);
            }

            phaoHoa.SetActive(true);
            countTime.enabled = false;

            StartCoroutine(ActiveWinGame());
        }
    }


    //Đếm thời gian
    public void CountTimeWin()
    {
        //Điều kiện thỏa mãn để bắt đầu đếm
        if (beginCountTime == true)
        {
            if (Time.time > timeLine + tempSecond + 1)
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

        //Nếu đang đếm mà điều kiện không thỏa mãn nữa thì
        if (beginCountTime == false)
        {
            countTime.enabled = false;
            threeSecond = 3;
            tempSecond = 0;
            countTime.text = 3.ToString();
        }
    }

    IEnumerator ActiveWinGame()
    {
        yield return new WaitForSeconds(3.2f);

        winGame.SetActive(true);
    }
}
