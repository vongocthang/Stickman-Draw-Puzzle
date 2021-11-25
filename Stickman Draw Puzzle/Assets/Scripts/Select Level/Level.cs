using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Setup tự động thông tin cho Level
public class Level : MonoBehaviour
{
    //public string a = "01";
    public TMP_Text  levelNumber;
    public GameObject locked;
    public int level;
    public int mode = 1;//Xác định để load từ Scene nào

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    // Start is called before the first frame update
    void Start()
    {
        level = int.Parse(this.name.Substring(7, 2));

        SetUp();
        ShowStar();

    }

    public void SetUp()
    {
        if (mode == 1)
        {
            int scenceUnlocked = PlayerPrefs.GetInt("SceneUnlockedBM");
            if (scenceUnlocked >= level)
            {
                locked.SetActive(false);
                levelNumber.text = level.ToString();
            }
        }
        if (mode == 2)
        {
            int scenceUnlocked = PlayerPrefs.GetInt("SceneUnlockedCW");
            if (scenceUnlocked >= level)
            {
                locked.SetActive(false);
                levelNumber.text = level.ToString();
            }
        }
        if (mode == 3)
        {
            int scenceUnlocked = PlayerPrefs.GetInt("SceneUnlockedWM");
            if (scenceUnlocked >= level)
            {
                locked.SetActive(false);
                levelNumber.text = level.ToString();
            }
        }
        if (mode == 4)
        {
            int scenceUnlocked = PlayerPrefs.GetInt("SceneUnlockedSM");
            if (scenceUnlocked >= level)
            {
                locked.SetActive(false);
                levelNumber.text = level.ToString();
            }
        }
    }

    public void LoadScene()
    {
        if (locked.activeSelf == false)
        {
            if (mode == 1)
            {
                SceneManager.LoadScene(level);
            }
            if (mode == 2)
            {
                SceneManager.LoadScene(level + 90);
            }
            if (mode == 3)
            {
                SceneManager.LoadScene(level + 110);
            }
            if (mode == 4)
            {
                SceneManager.LoadScene(level + 130);
            }
        }
    }

    public void ShowStar()
    {
        if (mode == 1)
        {
            int star = PlayerPrefs.GetInt("M1StarLevel" + level.ToString());
            if (star == 2)
            {
                star3.SetActive(false);
            }
            if (star == 1)
            {
                star3.SetActive(false);
                star2.SetActive(false);
            }
            if (star == 0)
            {
                star3.SetActive(false);
                star2.SetActive(false);
                star1.SetActive(false);
            }
        }
        if (mode == 2)
        {
            int star = PlayerPrefs.GetInt("M2StarLevel" + level.ToString());
            if (star == 2)
            {
                star3.SetActive(false);
            }
            if (star == 1)
            {
                star3.SetActive(false);
                star2.SetActive(false);
            }
            if (star == 0)
            {
                star3.SetActive(false);
                star2.SetActive(false);
                star1.SetActive(false);
            }
        }
        if (mode == 3)
        {
            int star = PlayerPrefs.GetInt("M3StarLevel" + level.ToString());
            if (star == 2)
            {
                star3.SetActive(false);
            }
            if (star == 1)
            {
                star3.SetActive(false);
                star2.SetActive(false);
            }
            if (star == 0)
            {
                star3.SetActive(false);
                star2.SetActive(false);
                star1.SetActive(false);
            }
        }
        if (mode == 4)
        {
            int star = PlayerPrefs.GetInt("M4StarLevel" + level.ToString());
            if (star == 2)
            {
                star3.SetActive(false);
            }
            if (star == 1)
            {
                star3.SetActive(false);
                star2.SetActive(false);
            }
            if (star == 0)
            {
                star3.SetActive(false);
                star2.SetActive(false);
                star1.SetActive(false);
            }
        } 
    }

    

}
