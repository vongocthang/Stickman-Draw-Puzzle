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
        PlayerPrefs.SetInt("SceneUnlockedBM", 55);

        //if (PlayerPrefs.GetInt("SceneUnlockedBM") == 0)
        //{
        //    PlayerPrefs.SetInt("SceneUnlockedBM", 1);
        //}
        //if (PlayerPrefs.GetInt("SceneCompleteBM") == 0)
        //{
        //    PlayerPrefs.SetInt("SceneCompleteNM", 0);
        //}
        //Debug.Log(PlayerPrefs.GetInt("SceneUnlockedBM"));

        SetupAmThanh();
        ShowCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void SetupAmThanh()
    {
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

    public void MusicON()
    {
        PlayerPrefs.SetInt("Music", 0);
    }

    public void MusicOFF()
    {
        PlayerPrefs.SetInt("Music", 1);
    }

    public void AudioEffectsON()
    {
        PlayerPrefs.SetInt("AudioEffects", 0);
    }

    public void AudioEffectsOFF()
    {
        PlayerPrefs.SetInt("AudioEffects", 1);
    }

    public void ShowCoin()
    {
        showCoin.text = PlayerPrefs.GetInt("Coin").ToString();
    }
}
