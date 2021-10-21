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
    public TMP_Text starNumber;
    public bool unlocked;

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUp()
    {
        int level = int.Parse(this.name.Substring(7, 2));

        int scenceUnlocked = PlayerPrefs.GetInt("SceneUnlocked");
        if (scenceUnlocked >= level)
        {
            unlocked = true;
            levelNumber.text = level.ToString();
        }
        else
        {
            return;
        }

        int star = PlayerPrefs.GetInt("StarLevel" + level.ToString());
        starNumber.text = star.ToString();
    }

    public void LoadScene()
    {
        if (unlocked == true)
        {
            SceneManager.LoadScene(int.Parse(levelNumber.text));
        }
    }
}
