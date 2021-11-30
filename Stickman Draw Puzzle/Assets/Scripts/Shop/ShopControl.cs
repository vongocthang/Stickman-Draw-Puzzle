using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour
{
    public TMP_Text showCoin;

    //public Image scrollPage;
    public GameObject musicON;
    public GameObject audioEffectsON;

    private void Start()
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

    // Update is called once per frame
    void Update()
    {
        ShowCoin();
    }

    public void ShowCoin()
    {
        showCoin.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    public void GoHome()
    {
        SceneManager.LoadSceneAsync("Home");
    }

    public void BuyCoin1()
    {
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1000);
    }

    public void BuyCoin2()
    {
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 2500);
    }

    public void BuyCoin3()
    {
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 10000);
    }
}
