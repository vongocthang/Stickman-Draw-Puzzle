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
        int scenceUnlocked = PlayerPrefs.GetInt("SceneUnlockedBM");
        if (scenceUnlocked >= level)
        {
            locked.SetActive(false);
            levelNumber.text = level.ToString();
        }
    }

    public void LoadScene()
    {
        if (locked.activeSelf == false)
        {
            SceneManager.LoadScene(level);
        }
    }

    public void ShowStar()
    {
        int star = PlayerPrefs.GetInt("StarLevel" + level.ToString());
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
