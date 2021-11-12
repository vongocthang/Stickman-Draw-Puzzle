using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwipeMenu : MonoBehaviour
{
    public Scrollbar scrollbar;
    public float[] pos;
    public float distance;
    public int pageNumber = 1;
    public int maxPage;

    public GameObject[] page;

    public int maxUnlock;//Scene lớn nhất đã mở khóa

    // Start is called before the first frame update
    void Start()
    {
        pos = new float[transform.childCount];
        distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }


        if (PlayerPrefs.GetInt("PageNumber") != 0)
        {
            pageNumber = PlayerPrefs.GetInt("PageNumber");
        }
        
        //Debug.Log(SceneManager.GetActiveScene().name);
        //GetMaxSceneUnlock();
    }

    // Update is called once per frame
    void Update()
    {
        ChangePage();
        ChangeScale();
        WhatPage();
    }

    public void NextPage()
    {
        if (pageNumber < maxPage)
        {
            pageNumber++;
        }
    }

    public void BackPage()
    {
        if (pageNumber > 1)
        {
            pageNumber--;
        }
    }

    public void ChangePage()
    {
        if (!Input.GetMouseButton(0))
        {
            if (scrollbar.value != pos[pageNumber - 1])
            {
                scrollbar.value = Mathf.Lerp(scrollbar.value, pos[pageNumber - 1], 0.1f);

                this.transform.GetChild(pageNumber - 1).localScale =
                        Vector2.Lerp(this.transform.GetChild(pageNumber - 1).localScale, new Vector2(1f, 1f), 0.1f);
            }
        }
    }

    public void ChangeScale()
    {
        if (scrollbar.value < pos[pageNumber - 1] && scrollbar.value >= 0)
        {
            this.transform.GetChild(pageNumber - 2).localScale =
                Vector2.Lerp(this.transform.GetChild(pageNumber - 2).localScale, new Vector2(0.8f, 0.8f), 0.1f);
        }

        if (scrollbar.value > pos[pageNumber - 1] && scrollbar.value <= 1)
        {
            this.transform.GetChild(pageNumber).localScale =
                Vector2.Lerp(this.transform.GetChild(pageNumber).localScale, new Vector2(0.8f, 0.8f), 0.1f);
        }
    }

    public void WhatPage()
    {
        if (pageNumber == 1)
        {
            page[1-1].SetActive(false);
            for(int i=0; i<page.Length; i++)
            {
                if (i + 1 != pageNumber)
                {
                    page[i].SetActive(true);
                }
            }
        }
        if (pageNumber == 2)
        {
            page[2 - 1].SetActive(false);
            for (int i = 0; i < page.Length; i++)
            {
                if (i + 1 != pageNumber)
                {
                    page[i].SetActive(true);
                }
            }
        }
        if (pageNumber == 3)
        {
            page[3 - 1].SetActive(false);
            for (int i = 0; i < page.Length; i++)
            {
                if (i + 1 != pageNumber)
                {
                    page[i].SetActive(true);
                }
            }
        }
        if (pageNumber == 4)
        {
            page[4 - 1].SetActive(false);
            for (int i = 0; i < page.Length; i++)
            {
                if (i + 1 != pageNumber)
                {
                    page[i].SetActive(true);
                }
            }
        }
        if (pageNumber == 5)
        {
            page[5 - 1].SetActive(false);
            for (int i = 0; i < page.Length; i++)
            {
                if (i + 1 != pageNumber)
                {
                    page[i].SetActive(true);
                }
            }
        }
        if (pageNumber == 6)
        {
            page[6 - 1].SetActive(false);
            for (int i = 0; i < page.Length; i++)
            {
                if (i + 1 != pageNumber)
                {
                    page[i].SetActive(true);
                }
            }
        }
    }

    public void GetMaxSceneUnlock()
    {
        if(SceneManager.GetActiveScene().name=="Basic Mode")
        {
            maxUnlock = PlayerPrefs.GetInt("SceneUnlockBM");
        }
        if (SceneManager.GetActiveScene().name == "Collect Wood")
        {
            maxUnlock = PlayerPrefs.GetInt("SceneUnlockCW");
        }
        if (SceneManager.GetActiveScene().name == "Water Mode")
        {
            maxUnlock = PlayerPrefs.GetInt("SceneUnlockWM");
        }
        if (SceneManager.GetActiveScene().name == "Space Mode")
        {
            maxUnlock = PlayerPrefs.GetInt("SceneUnlockSM");
        }
    }
}
