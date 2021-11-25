using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadSceneTemp : MonoBehaviour
{
    public TMP_Text levelName;
    public int levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        levelNumber = int.Parse(this.name.Substring(7, 2));
        levelName.text = levelNumber.ToString();
    }

    public void LoadScene01()
    {
        SceneManager.LoadScene(157);
    }
    public void LoadScene02()
    {
        SceneManager.LoadScene(158);
    }
    public void LoadScene03()
    {
        SceneManager.LoadScene(159);
    }
}
