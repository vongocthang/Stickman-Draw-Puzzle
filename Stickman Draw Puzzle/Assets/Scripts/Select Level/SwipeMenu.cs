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
    public float scrollbarPos;//Vị trí ngay khi thả chuột-kết thúc cuộn
    public int pageNumber;
    public int maxPage;
    public bool useButton;

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


        pageNumber = PlayerPrefs.GetInt("PageNumber");
        scrollbarPos = pos[pageNumber];
        //Debug.Log(pageNumber);
        scrollbar.value = pos[pageNumber];

        //Debug.Log(SceneManager.GetActiveScene().name);
        //GetMaxSceneUnlock();
    }

    // Update is called once per frame
    void Update()
    {
        ChangePageUseScroll();
        ChangePageUseButton();
        WhatPage();
    }

    public void NextPage()
    {
        if (pageNumber < maxPage - 1)
        {
            //Debug.Log("Next page");
            pageNumber++;
            useButton = true;
        }
    }

    public void BackPage()
    {
        if (pageNumber > 0)
        {
            //Debug.Log("Back page");
            pageNumber--;
            useButton = true;
        }
    }

    public void ChangePageUseScroll()
    {
        if (Input.GetMouseButton(0))
        {
            scrollbarPos = scrollbar.value;
            useButton = false;
        }
        else
        {
            if (useButton == false)
            {
                //Debug.Log("Su dung cuon");
                for (int i = 0; i < pos.Length; i++)
                {
                    if (scrollbarPos < pos[i] + (distance / 2) && scrollbarPos > pos[i] - (distance / 2))
                    {
                        //Debug.Log("Doi pen hien thi");
                        scrollbar.value = Mathf.Lerp(scrollbar.value, pos[i], 0.05f);
                        pageNumber = i;
                    }
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < pos.Length; i++)
            {
                if (scrollbarPos < pos[i] + (distance / 2f) && scrollbarPos > pos[i] - (distance / 2f))
                {
                    this.transform.GetChild(i).localScale =
                        Vector2.Lerp(this.transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.05f);
                    for (int j = 0; j < pos.Length; j++)
                    {
                        if (j != i)
                        {
                            this.transform.GetChild(j).localScale =
                                Vector2.Lerp(this.transform.GetChild(j).localScale, new Vector2(0.6f, 0.6f), 0.05f);
                        }
                    }
                }
            }
        }
    }

    public void ChangePageUseButton()
    {
        if (useButton == true)
        {
            //Debug.Log("Su dung button");
            if (scrollbar.value != pos[pageNumber])
            {
                //Debug.Log("Bat dau hanh dong");
                scrollbar.value = Mathf.Lerp(scrollbar.value, pos[pageNumber], 0.1f);

                this.transform.GetChild(pageNumber).localScale =
                        Vector2.Lerp(this.transform.GetChild(pageNumber).localScale, new Vector2(1f, 1f), 0.1f);
            }
            /////////////////////////////////////////////
            if (scrollbar.value < pos[pageNumber] && scrollbar.value >= 0)
            {
                this.transform.GetChild(pageNumber - 1).localScale =
                    Vector2.Lerp(this.transform.GetChild(pageNumber - 1).localScale, new Vector2(0.6f, 0.6f), 0.1f);
            }
            ////////////////////////////////////////////
            if (scrollbar.value > pos[pageNumber] && scrollbar.value <= 1)
            {
                this.transform.GetChild(pageNumber + 1).localScale =
                    Vector2.Lerp(this.transform.GetChild(pageNumber + 1).localScale, new Vector2(0.6f, 0.6f), 0.1f);
            }
            scrollbarPos = scrollbar.value;
        }
    }

    public void WhatPage()
    {
        if (pageNumber == 0)
        {
            page[pageNumber].SetActive(false);
            for(int i=0; i<page.Length; i++)
            {
                if (i != pageNumber)
                {
                    page[i].SetActive(true);
                }
            }
        }
        if (pageNumber == 1)
        {
            page[pageNumber].SetActive(false);
            for (int i = 0; i < page.Length; i++)
            {
                if (i != pageNumber)
                {
                    page[i].SetActive(true);
                }
            }
        }
        if (pageNumber == 2)
        {
            page[pageNumber].SetActive(false);
            for (int i = 0; i < page.Length; i++)
            {
                if (i != pageNumber)
                {
                    page[i].SetActive(true);
                }
            }
        }
        if (pageNumber == 3)
        {
            page[pageNumber].SetActive(false);
            for (int i = 0; i < page.Length; i++)
            {
                if (i != pageNumber)
                {
                    page[i].SetActive(true);
                }
            }
        }
        if (pageNumber == 4)
        {
            page[pageNumber].SetActive(false);
            for (int i = 0; i < page.Length; i++)
            {
                if (i != pageNumber)
                {
                    page[i].SetActive(true);
                }
            }
        }
        if (pageNumber == 5)
        {
            page[pageNumber].SetActive(false);
            for (int i = 0; i < page.Length; i++)
            {
                if (i != pageNumber)
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
