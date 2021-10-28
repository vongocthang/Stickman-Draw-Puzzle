using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    public Scrollbar scrollbar;
    public float[] pos;
    public float distance;
    public int pageNumber = 1;

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
        ChangeScale();
    }

    public void NextPage()
    {
        if (pageNumber < 4)
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
        if (scrollbar.value != pos[pageNumber - 1])
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, pos[pageNumber - 1], 0.1f);

            this.transform.GetChild(pageNumber - 1).localScale =
                    Vector2.Lerp(this.transform.GetChild(pageNumber - 1).localScale, new Vector2(1f, 1f), 0.1f);
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
}
