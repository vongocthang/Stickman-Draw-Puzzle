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
        if (PlayerPrefs.GetInt("SceneUnlocked") == 0)
        {
            PlayerPrefs.SetInt("SceneUnlocked", 3);
        }
        if (PlayerPrefs.GetInt("SceneComplete") == 0)
        {
            PlayerPrefs.SetInt("SceneComplete", 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
