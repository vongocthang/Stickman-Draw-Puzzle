using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour
{
    public TMP_Text showCoin;

    // Start is called before the first frame update
    void Start()
    {
        
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
