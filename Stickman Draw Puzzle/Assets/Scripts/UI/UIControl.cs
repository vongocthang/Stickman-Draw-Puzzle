using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//Điều khiển các tác vụ sử dụng đồng thời cho cả 2 chế độ Basic và Collect Wood
//PlayerPrefs (SceneUnlocked)(StarLevel+x)(

public class UIControl : MonoBehaviour
{
    //Số lượng Line đc vẽ ứng với 3 sao, 2 sao, 1 sao
    //Cái này là khác nhau cho mỗi Level, tùy vào độ khó
    public int[] setupStar;
    public int countStar;
    public int tempCount;//Đếm số line đã vẽ mỗi mức sao

    public GameObject star1, star2, star3;
    
    public TMP_Text countLine;//Hiển thị số Line còn lại đc phép vẽ cho mốc sao hiện tại

    public TempDrawLine drawLine;

    //Điều khiển xe di chuyển trái phải
    public bool moveLeft, moveRight;

    //DrawLine drawLine;

    private void Start()
    {
        //drawLine = GameObject.Find("Pen").GetComponent<DrawLine>();
        countStar = 3;
        tempCount = setupStar[countStar - 1];
        
        countLine.text = tempCount.ToString();

        drawLine = GameObject.Find("Draw Line").GetComponent<TempDrawLine>();

        SetPenLoad();
    }

    private void Update()
    {
        CountLine();
        ShowStar();
    }

    public void CountLine()
    {
        if (tempCount == 0 && countStar >= 1)
        {
            countStar--;
            if (countStar >= 1)
            {
                tempCount = setupStar[countStar - 1];
                
            }
        }

        countLine.text = tempCount.ToString();
    }

    public void ShowStar()
    {
        if (countStar == 2)
        {
            star3.SetActive(false);
        }
        if (countStar == 1)
        {


            star2.SetActive(false);
        }
        if (countStar == 0)
        {


            star1.SetActive(false);
        }
    }

    //Xác định Pen để load % bỏ qua các Pen đã mở khóa sở hữu
    public void SetPenLoad()
    {
        for(int i=0; i<=5; i++)
        {
            if (PlayerPrefs.GetInt("Pen" + i.ToString()) == 0)
            {
                PlayerPrefs.SetInt("ClaimPen", i);
                return;
            }
        }
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

    public void PauseDrawLine()
    {
        drawLine.enabled = false;
    }

    public void ResumeDrawLine()
    {
        drawLine.enabled = true;
    }


    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome()
    {
        SceneManager.LoadScene(51);
    }

    public void SellectLevelBasicMode()
    {
        SceneManager.LoadScene(52);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
