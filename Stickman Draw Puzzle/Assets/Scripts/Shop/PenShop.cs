using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenShop : MonoBehaviour
{
    public Scrollbar scrollbar;
    public float[] pos;
    public float distance;
    public float scrollbarPos;//Vị trí ngay khi thả chuột-kết thúc cuộn

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
        //ChangeScale();
    }

    public void ChangePage()
    {
        if (Input.GetMouseButton(0))
        {
            scrollbarPos = scrollbar.value;
        }
        else
        {
            foreach (int i in pos)
            {
                if (scrollbarPos < pos[i] + (distance / 2f) && scrollbarPos > pos[i] - (distance / 2f))
                {
                    scrollbar.value = Mathf.Lerp(scrollbar.value, pos[i], 0.1f);
                }
            }
        }

        foreach (int i in pos)
        {
            if (scrollbarPos < pos[i] + (distance / 2f) && scrollbarPos > pos[i] - (distance / 2f))
            {
                this.transform.GetChild(i).localScale =
                    Vector2.Lerp(this.transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                foreach (int j in pos)
                {
                    if (j != i)
                    {
                        this.transform.GetChild(j).localScale =
                            Vector2.Lerp(this.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.2f);
                    }
                }
            }
        }
    }

    //public void ChangeScale()
    //{
    //    if (scrollbar.value < pos[pageNumber - 1] && scrollbar.value >= 0)
    //    {
    //        this.transform.GetChild(pageNumber - 2).localScale =
    //            Vector2.Lerp(this.transform.GetChild(pageNumber - 2).localScale, new Vector2(0.8f, 0.8f), 0.2f);
    //    }

    //    if (scrollbar.value > pos[pageNumber - 1] && scrollbar.value <= 1)
    //    {
    //        this.transform.GetChild(pageNumber).localScale =
    //            Vector2.Lerp(this.transform.GetChild(pageNumber).localScale, new Vector2(0.8f, 0.8f), 0.2f);
    //    }

    //}
}
