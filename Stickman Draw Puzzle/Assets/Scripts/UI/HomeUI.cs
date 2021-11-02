using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Đặt ở Home Scene, Load đầu tiên khi vào game

public class HomeUI : MonoBehaviour
{
    //public Image scrollPage;
    public GameObject musicON;
    public GameObject audioEffectsON;

    public TMP_Text showCoin;
    //Hiển thị tổng số sao của tất cả các Level
    public TMP_Text showSumStar;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("SceneUnlockedBM") == 0)
        {
            PlayerPrefs.SetInt("SceneUnlockedBM", 50);
        }
        if (PlayerPrefs.GetInt("ClaimPen") == 0)
        {
            PlayerPrefs.SetInt("ClaimPen", 1);
        }

        //for (int i = 1; i <= 5; i++)
        //{
        //    PlayerPrefs.SetInt("Pen" + i.ToString(), 0);
        //}

        //for (int i = 1; i <= 50; i++)
        //{
        //    PlayerPrefs.SetInt("StarLevel" + i.ToString(), 0);
        //}

        //PlayerPrefs.SetInt("Coin", 0);

        //PlayerPrefs.SetInt("ClaimPen", 0);
        //PlayerPrefs.SetInt("PenLoad", 0);
        //PlayerPrefs.SetInt("Pen", 0);

        //PlayerPrefs.SetInt("SceneUnlockedBM", 0);

        PlayerPrefs.SetInt("Pen0", 1);
    }

    // Update is called once per frame
    void Update()
    {
        ShowCoin();
        ShowSumStar();
    }

    public void LoadHome()
    {
        SceneManager.LoadScene(51);
    }

    public void LoadSellectLevelBasicMode()
    {
        SceneManager.LoadScene(52);
    }

    public void LoadSellectLevelCollectWood()
    {

    }

    public void ShowCoin()
    {
        showCoin.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    public void ShowSumStar()
    {
        int sumStar = 0;
        for(int i=1; i<=50; i++)
        {
            int a = PlayerPrefs.GetInt("StarLevel" + i.ToString());
            sumStar += a;
            showSumStar.text = sumStar.ToString();
        }
    }

    public void GoShop()
    {
        SceneManager.LoadScene(53);
    }
}
