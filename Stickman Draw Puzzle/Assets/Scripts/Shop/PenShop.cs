using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Điều khiển giao diện Shop Pen
//Đặt tại Scroll View/Viewport/Content

public class PenShop : MonoBehaviour
{
    public Scrollbar scrollbar;
    public float[] pos;//Tập vị trí của các đối tượng trên thanh cuộn
    public float distance;//Khoảng cách giữa 2 đối tượng trên thanh cuộn
    public float scrollbarPos;//Vị trí ngay khi thả chuột-kết thúc cuộn
    public int penNumber = 0;//Pen số mấy đang hiển thị

    public GameObject unlockPen;//Giao diện xem video để mở khóa Pen
    public GameObject selectedPen;//Dấu hiệu bút này đang đc sử dụng
    public GameObject selectPen;//Có thể chọn bút để sử dụng

    // Start is called before the first frame update
    void Start()
    {
        pos = new float[transform.childCount];
        distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        //Debug.Log(PlayerPrefs.GetInt("Pen"));

        
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
                    Debug.Log("Doi pen hien thi");
                    scrollbar.value = Mathf.Lerp(scrollbar.value, pos[i], 0.05f);
                    penNumber = i;
                }
            }
        }

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

    public void ShowPenStatus()
    {
        if (PlayerPrefs.GetInt("Pen" + penNumber.ToString()) == 1)
        {
            unlockPen.SetActive(false);
            selectPen.SetActive(true);
            selectedPen.SetActive(false);

            if (penNumber == PlayerPrefs.GetInt("Pen"))
            {
                unlockPen.SetActive(false);
                selectPen.SetActive(false);
                selectedPen.SetActive(true);
            }
            else
            {
                unlockPen.SetActive(false);
                selectPen.SetActive(true);
                selectedPen.SetActive(false);
            }
        }
        else
        {
            unlockPen.SetActive(true);
            selectPen.SetActive(false);
            selectedPen.SetActive(false);
        }
    }

    public void SelectPen()
    {
        PlayerPrefs.SetInt("Pen", penNumber);
        unlockPen.SetActive(false);
        selectPen.SetActive(false);
        selectedPen.SetActive(true);
    }

    public void UnlockPen()
    {
        if (PlayerPrefs.GetInt("Coin") >= 3000)
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 3000);
            PlayerPrefs.SetInt("Pen" + penNumber.ToString(), 1);
            PlayerPrefs.SetInt("PenLoad", 0);

            unlockPen.SetActive(false);
            selectPen.SetActive(true);
            selectedPen.SetActive(false);
        }
    }
}
