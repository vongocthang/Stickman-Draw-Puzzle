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

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("SceneUnlockedBM") == 0)
        {
            PlayerPrefs.SetInt("SceneUnlockedBM", 90);
        }
        if (PlayerPrefs.GetInt("SceneUnlockedCW") == 0)
        {
            PlayerPrefs.SetInt("SceneUnlockedCW", 20);
        }
        if (PlayerPrefs.GetInt("SceneUnlockedWM") == 0)
        {
            PlayerPrefs.SetInt("SceneUnlockedWM", 20);
        }
        if (PlayerPrefs.GetInt("SceneUnlockedSM") == 0)
        {
            PlayerPrefs.SetInt("SceneUnlockedSM", 20);
        }

        if (PlayerPrefs.GetInt("ClaimPen") == 0)
        {
            PlayerPrefs.SetInt("ClaimPen", 1);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //for (int i = 1; i <= 5; i++)
        //{
        //    PlayerPrefs.SetInt("Pen" + i.ToString(), 0);
        //}

        //for (int i = 1; i <= 90; i++)
        //{
        //    PlayerPrefs.SetInt("M1StarLevel" + i.ToString(), 0);
        //}

        //for (int i = 1; i <= 20; i++)
        //{
        //    PlayerPrefs.SetInt("M2StarLevel" + i.ToString(), 0);
        //}

        //for (int i = 1; i <= 20; i++)
        //{
        //    PlayerPrefs.SetInt("M3StarLevel" + i.ToString(), 0);
        //}
        //for (int i = 1; i <= 20; i++)
        //{
        //    PlayerPrefs.SetInt("M4StarLevel" + i.ToString(), 0);
        //}

        //PlayerPrefs.SetInt("Coin", 0);

        //PlayerPrefs.SetInt("ClaimPen", 0);
        //PlayerPrefs.SetInt("PenLoad", 0);
        //PlayerPrefs.SetInt("Pen", 0);

        //PlayerPrefs.SetInt("SceneUnlockedBM", 0);
        //PlayerPrefs.SetInt("SceneUnlockedCW", 0);
        //PlayerPrefs.SetInt("SceneUnlockedWM", 0);
        //PlayerPrefs.SetInt("SceneUnlockedSM", 0);

        //PlayerPrefs.SetInt("PageNumber", 1);

        ////////////////////////////////////////////////////////////////////////////////////////////////

        PlayerPrefs.SetInt("Pen0", 1);

        if (PlayerPrefs.GetInt("AudioEffects") == 0)
        {
            audioEffectsON.SetActive(true);
        }
        else
        {
            audioEffectsON.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Music") == 0)
        {
            musicON.SetActive(true);
        }
        else
        {
            musicON.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShowCoin();
        
    }

    public void LoadHome()
    {
        SceneManager.LoadSceneAsync("Home");
    }

    public void LoadStartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSellectLevelBasicMode()
    {
        SceneManager.LoadSceneAsync("Basic Mode");
    }

    public void LoadSellectLevelCollectWood()
    {
        SceneManager.LoadSceneAsync("Collect Wood");
    }

    public void LoadSellectLevelWaterMode()
    {
        SceneManager.LoadSceneAsync("Water Mode");
    }

    public void LoadSellectLevelSpaceMode()
    {
        SceneManager.LoadSceneAsync("Space Mode");
    }

    public void ShowCoin()
    {
        showCoin.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    public void GoShop()
    {
        SceneManager.LoadSceneAsync("Shop");
    }

    //Tạm thời cho Video Editor
    public void LoadToVideoEditor()
    {
        //SceneManager.LoadSceneAsync("ToVideoEditor");
    }
}
