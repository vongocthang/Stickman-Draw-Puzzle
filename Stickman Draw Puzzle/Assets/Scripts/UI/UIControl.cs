using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//

public class UIControl : MonoBehaviour
{
    //Số lượng Line đc vẽ ứng với 3 sao, 2 sao, 1 sao
    //Cái này là khác nhau cho mỗi Level, tùy vào độ khó
    public int[] setupStar;
    public int countStar;
    public int tempCount = 0;//Đếm số line đã vẽ mỗi mức sao
    public int duocVe;

    public GameObject star1, star2, star3;
    
    public TMP_Text countLine;//Hiển thị số Line đã vẽ
    public TMP_Text showDuocVe;//Số Line được vẽ để đạt được mốc sao

    public TempDrawLine drawLine;
    public bool stopDrawLine;

    //Điều khiển xe di chuyển trái phải
    public bool moveLeft, moveRight;
    //Điều khiển xe di chuyển lên xuống - chỉ chế độ không trọng lực
    public bool moveUp, moveDown;

    public GameObject car;

    private void Start()
    {
        countStar = 3;
        showDuocVe.text = setupStar[2].ToString();
        countLine.text = tempCount.ToString();

        drawLine = GameObject.Find("Draw Line").GetComponent<TempDrawLine>();

        if (GameObject.Find("CarLeft"))
        {
            car = GameObject.Find("CarLeft");
            
        }
        if (GameObject.Find("CarRight"))
        {
            car = GameObject.Find("CarRight");
        }

        SetPenLoad();

        //Temp
        //ShowLevelNumber();
    }

    private void Update()
    {
        CountLine();
        ShowStar();
    }

    public void CountLine()
    {
        //if (tempCount == 0 && countStar >= 1)
        //{
        //    countStar--;
        //    if (countStar >= 1)
        //    {
        //        tempCount = setupStar[countStar - 1];
        //    }
        //}
        if (countStar == 3)
        {
            if (tempCount - setupStar[2] == 0)
            {
                countStar--;
            }
        }
        if (countStar == 2)
        {
            if (tempCount - setupStar[2] - setupStar[1] == 0)
            {
                countStar--;
            }
        }
        if (countStar == 1)
        {
            if (tempCount - setupStar[2] - setupStar[1] - setupStar[0] == 0)
            {
                countStar--;
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

    //Điều khiển xe di chuyển trái phải - 3 Mode đầu
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
        moveUp = false;
        moveDown = false;

        if (car.GetComponent<CarControl>() != null)
        {
            car.GetComponent<CarControl>().countTime = Time.time;
        }
        if (car.GetComponent<GravityCar>() != null)
        {
            car.GetComponent<GravityCar>().countTime = Time.time;
        }
    }

    //Điều khiển xe di chuyển lên xuống - chỉ Mode không trọng lực
    public void MoveUp()
    {
        moveUp = true;
    }

    public void MoveDown()
    {
        moveDown = true;
    }

    public void PauseDrawLine()
    {
        stopDrawLine = true;
    }

    public void ResumeDrawLine()
    {
        stopDrawLine = false;
    }


    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome()
    {
        SceneManager.LoadSceneAsync("Home");
    }

    public void SellectLevel()
    {
        //Chế độ 1
        if (SceneManager.GetActiveScene().buildIndex <= 80)
        {
            SceneManager.LoadSceneAsync("Basic Mode");
        }
        //Chế độ 2
        if (SceneManager.GetActiveScene().buildIndex > 80 && SceneManager.GetActiveScene().buildIndex <= 100)
        {
            SceneManager.LoadSceneAsync("Collect Wood");
        }
        //Chế độ 3
        if (SceneManager.GetActiveScene().buildIndex > 100 && SceneManager.GetActiveScene().buildIndex <= 120)
        {
            SceneManager.LoadSceneAsync("Water Mode");
        }
        //Chế độ 4
        if (SceneManager.GetActiveScene().buildIndex > 120 && SceneManager.GetActiveScene().buildIndex <= 140)
        {
            SceneManager.LoadSceneAsync("Space Mode");
        }
    }


    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
    public void SceneInPage()
    {
        //Chế độ 1
        if (SceneManager.GetActiveScene().buildIndex <= 80)
        {
            if (SceneManager.GetActiveScene().buildIndex % 15 == 0)
            {
                int pageNumber = SceneManager.GetActiveScene().buildIndex / 15 - 1;
                PlayerPrefs.SetInt("PageNumber", pageNumber);
            }
            else
            {
                int pageNumber = SceneManager.GetActiveScene().buildIndex / 15;
                PlayerPrefs.SetInt("PageNumber", pageNumber);
            }
        }
        //Chế độ 2
        if (SceneManager.GetActiveScene().buildIndex > 80 && SceneManager.GetActiveScene().buildIndex <= 100)
        {
            if ((SceneManager.GetActiveScene().buildIndex - 80) % 15 == 0)
            {
                int pageNumber = (SceneManager.GetActiveScene().buildIndex - 80) / 15 - 1;
                PlayerPrefs.SetInt("PageNumber", pageNumber);
            }
            else
            {
                int pageNumber = (SceneManager.GetActiveScene().buildIndex - 80) / 15;
                PlayerPrefs.SetInt("PageNumber", pageNumber);
            }
        }
        //Chế độ 3
        if (SceneManager.GetActiveScene().buildIndex > 100 && SceneManager.GetActiveScene().buildIndex <= 120)
        {
            if ((SceneManager.GetActiveScene().buildIndex - 100) % 15 == 0)
            {
                int pageNumber = (SceneManager.GetActiveScene().buildIndex - 100) / 15 - 1;
                PlayerPrefs.SetInt("PageNumber", pageNumber);
            }
            else
            {
                int pageNumber = (SceneManager.GetActiveScene().buildIndex - 100) / 15;
                PlayerPrefs.SetInt("PageNumber", pageNumber);
            }
        }
        //Chế độ 4
        if (SceneManager.GetActiveScene().buildIndex > 120 && SceneManager.GetActiveScene().buildIndex <= 140)
        {
            if ((SceneManager.GetActiveScene().buildIndex - 120) % 15 == 0)
            {
                int pageNumber = (SceneManager.GetActiveScene().buildIndex - 120) / 15 - 1;
                PlayerPrefs.SetInt("PageNumber", pageNumber);
            }
            else
            {
                int pageNumber = (SceneManager.GetActiveScene().buildIndex - 120) / 15;
                PlayerPrefs.SetInt("PageNumber", pageNumber);
            }
        }
    }

    //Tạm thời cho Video Editor
    public void LoadToVideoEditor()
    {
        SceneManager.LoadSceneAsync("ToVideoEditor");
    }

    //Hiện tên level ở mỗi màn chơi tạm thời
    public void ShowLevelNumber()
    {
        //Chế độ 1
        if (SceneManager.GetActiveScene().buildIndex <= 80)
        {
            GameObject.Find("ShowLevelNumber").GetComponent<TMP_Text>().text = "Level " +
                SceneManager.GetActiveScene().buildIndex.ToString();
        }
        //Chế độ 2
        if (SceneManager.GetActiveScene().buildIndex > 80 && SceneManager.GetActiveScene().buildIndex <= 100)
        {
            GameObject.Find("ShowLevelNumber").GetComponent<TMP_Text>().text = "Level " +
                (SceneManager.GetActiveScene().buildIndex - 80).ToString();
        }
        //Chế độ 3
        if (SceneManager.GetActiveScene().buildIndex > 100 && SceneManager.GetActiveScene().buildIndex <= 120)
        {
            GameObject.Find("ShowLevelNumber").GetComponent<TMP_Text>().text = "Level " +
                (SceneManager.GetActiveScene().buildIndex - 100).ToString();
        }
        //Chế độ 4
        if (SceneManager.GetActiveScene().buildIndex > 120 && SceneManager.GetActiveScene().buildIndex <= 140)
        {
            GameObject.Find("ShowLevelNumber").GetComponent<TMP_Text>().text = "Level " +
                (SceneManager.GetActiveScene().buildIndex - 120).ToString();
        }
    }
}
