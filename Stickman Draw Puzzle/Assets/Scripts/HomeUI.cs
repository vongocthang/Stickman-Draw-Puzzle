using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Đặt ở Home Scene, Load đầu tiên khi vào game
public class HomeUI : MonoBehaviour
{
    public Image scrollPage;


    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("SceneUnlockedBM", 0);

        if (PlayerPrefs.GetInt("SceneUnlockedBM") == 0)
        {
            PlayerPrefs.SetInt("SceneUnlockedBM", 1);
        }
        if (PlayerPrefs.GetInt("SceneCompleteBM") == 0)
        {
            PlayerPrefs.SetInt("SceneCompleteNM", 0);
        }
        Debug.Log(PlayerPrefs.GetInt("SceneUnlockedBM"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
