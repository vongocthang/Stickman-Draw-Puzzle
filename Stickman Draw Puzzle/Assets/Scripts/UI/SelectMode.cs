using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMode : MonoBehaviour
{
    public Scrollbar scrollbar;
    public float[] pos;//Tập vị trí của các đối tượng trên thanh cuộn
    public float distance;//Khoảng cách giữa 2 đối tượng trên thanh cuộn
    public float scrollbarPos;//Vị trí ngay khi thả chuột-kết thúc cuộn
    public int modeNumber = 1;//Mode số mấy đang hiển thị
    public int maxMode;

    public bool useButton;

    public GameObject origin;
    public GameObject woods;
    public GameObject water;
    public GameObject gravity;

    // Start is called before the first frame update
    void Start()
    {
        pos = new float[transform.childCount];
        distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        maxMode = pos.Length;
    }

    // Update is called once per frame
    void Update()
    {
        ChangePageUseScroll();
        ChangePageUseButton();
        ShowModeName();
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
            if(useButton == false)
            {
                //Debug.Log("Su dung cuon");
                for (int i = 0; i < pos.Length; i++)
                {
                    if (scrollbarPos < pos[i] + (distance / 2) && scrollbarPos > pos[i] - (distance / 2))
                    {
                        //Debug.Log("Doi pen hien thi");
                        scrollbar.value = Mathf.Lerp(scrollbar.value, pos[i], 0.05f);
                        modeNumber = i;
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
            if (scrollbar.value != pos[modeNumber])
            {
                //Debug.Log("Bat dau hanh dong");
                scrollbar.value = Mathf.Lerp(scrollbar.value, pos[modeNumber], 0.1f);

                this.transform.GetChild(modeNumber).localScale =
                        Vector2.Lerp(this.transform.GetChild(modeNumber).localScale,
                        new Vector2(1f, 1f), 0.1f);
            }

            if (scrollbar.value < pos[modeNumber] && scrollbar.value >= 0)
            {
                this.transform.GetChild(modeNumber - 1).localScale =
                    Vector2.Lerp(this.transform.GetChild(modeNumber - 1).localScale, new Vector2(0.6f, 0.6f), 0.1f);
            }

            if (scrollbar.value > pos[modeNumber] && scrollbar.value <= 1)
            {
                this.transform.GetChild(modeNumber + 1).localScale =
                    Vector2.Lerp(this.transform.GetChild(modeNumber + 1).localScale, new Vector2(0.6f, 0.6f), 0.1f);
            }
            scrollbarPos = scrollbar.value;
        }
    }

    public void NextPage()
    {
        if (modeNumber < maxMode - 1)
        {
            //Debug.Log("Next page");
            modeNumber++;
            useButton = true;
        }
    }

    public void BackPage()
    {
        if (modeNumber > 0)
        {
            //Debug.Log("Back page");
            modeNumber--;
            useButton = true;
        }
    }

    public void ShowModeName()
    {
        if (modeNumber == 0)
        {
            origin.SetActive(true);
            woods.SetActive(false);
            water.SetActive(false);
            gravity.SetActive(false);

            transform.GetChild(0).GetComponent<Button>().enabled = true;
            transform.GetChild(1).GetComponent<Button>().enabled = false;
            transform.GetChild(2).GetComponent<Button>().enabled = false;
            transform.GetChild(3).GetComponent<Button>().enabled = false;

        }
        if (modeNumber == 1)
        {
            origin.SetActive(false);
            woods.SetActive(true);
            water.SetActive(false);
            gravity.SetActive(false);

            transform.GetChild(0).GetComponent<Button>().enabled = false;
            transform.GetChild(1).GetComponent<Button>().enabled = true;
            transform.GetChild(2).GetComponent<Button>().enabled = false;
            transform.GetChild(3).GetComponent<Button>().enabled = false;
        }
        if (modeNumber == 2)
        {
            origin.SetActive(false);
            woods.SetActive(false);
            water.SetActive(true);
            gravity.SetActive(false);

            transform.GetChild(0).GetComponent<Button>().enabled = false;
            transform.GetChild(1).GetComponent<Button>().enabled = false;
            transform.GetChild(2).GetComponent<Button>().enabled = true;
            transform.GetChild(3).GetComponent<Button>().enabled = false;
        }
        if (modeNumber == 3)
        {
            origin.SetActive(false);
            woods.SetActive(false);
            water.SetActive(false);
            gravity.SetActive(true);

            transform.GetChild(0).GetComponent<Button>().enabled = false;
            transform.GetChild(1).GetComponent<Button>().enabled = false;
            transform.GetChild(2).GetComponent<Button>().enabled = false;
            transform.GetChild(3).GetComponent<Button>().enabled = true;
        }
    }
}
