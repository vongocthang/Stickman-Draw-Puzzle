using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Điều khiển giao diện Shop Pen
//Đặt tại Scroll View/Viewport/Content

public class PenShop : MonoBehaviour
{
    public Scrollbar scrollbar;
    public float[] pos;//Tập vị trí của các đối tượng trên thanh cuộn
    public float distance;//Khoảng cách giữa 2 đối tượng trên thanh cuộn
    public float scrollbarPos;//Vị trí ngay khi thả chuột-kết thúc cuộn

    public GameObject unlockPen;//Giao diện xem video để mở khóa Pen
    public GameObject usingPen;//Dấu hiệu bút này đang đc sử dụng

    // Start is called before the first frame update
    void Start()
    {
        pos = new float[transform.childCount];
        distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangePage();
        ShowPenStatus();
    }

    public void ChangePage()
    {
        if (Input.GetMouseButton(0))
        {
            scrollbarPos = scrollbar.value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scrollbarPos < pos[i] + (distance / 2) && scrollbarPos > pos[i] - (distance / 2))
                {
                    scrollbar.value = Mathf.Lerp(scrollbar.value, pos[i], 0.05f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scrollbarPos < pos[i] + (distance / 2f) && scrollbarPos > pos[i] - (distance / 2f))
            {
                this.transform.GetChild(i).localScale =
                    Vector2.Lerp(this.transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.03f);
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        this.transform.GetChild(j).localScale =
                            Vector2.Lerp(this.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.03f);
                    }
                }
            }
        }
    }

    public void ShowPenStatus()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            if (scrollbar.value == pos[i])
            {
                if (PlayerPrefs.GetString("Pen" + i.ToString()) == "Unlock")
                {
                    unlockPen.SetActive(false);
                    usingPen.SetActive(false);
                }
                else
                {
                    unlockPen.SetActive(true);
                    usingPen.SetActive(false);
                }

                if (PlayerPrefs.GetInt("Pen") == i)
                {
                    usingPen.SetActive(true);
                    unlockPen.SetActive(false);
                }
            }
        }
    }

    public void SelectPen()
    {
        
        for(int i=0; i<pos.Length; i++)
        {
            if (scrollbar.value == pos[i])
            {
                PlayerPrefs.SetInt("Pen", i);
                Debug.Log("Chon Pen " + i.ToString());
            }
        }
    }

    public void UnlockPen()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            if (scrollbar.value == pos[i])
            {
                PlayerPrefs.SetString("Pen" + i, "Unlock");
                Debug.Log("Mo khoa Pen " + i);
            }
        }
    }
}
