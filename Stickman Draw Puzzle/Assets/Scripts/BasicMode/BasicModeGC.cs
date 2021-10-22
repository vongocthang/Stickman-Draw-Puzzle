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

    //Điều khiển xe di chuyển trái phải
    public bool moveLeft, moveRight;
    //Điều khiển thanh nâng của xe
    public bool up, down;

    public UIControl uiControl;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Target").GetComponent<Target>();
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
            int a = PlayerPrefs.GetInt("SceneUnlockedBM");
            if (a < SceneManager.GetActiveScene().buildIndex + 1)
            {
                PlayerPrefs.SetInt("SceneUnlockedBM", SceneManager.GetActiveScene().buildIndex + 1);
            }
            
            int b = PlayerPrefs.GetInt("StarLevel" + SceneManager.GetActiveScene().buildIndex.ToString());
            if (b < uiControl.countStar)
            {
                PlayerPrefs.SetInt("StarLevel" + SceneManager.GetActiveScene().buildIndex.ToString(), uiControl.countStar);
            }
            

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

    //Điều khiển xe
    public void MoveLeft()
    {
        moveLeft = true;
    }

    public void MoveRight()
    {
        moveRight = true;
    }

    public void NotMove()
    {
        moveLeft = false;
        moveRight = false;
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
