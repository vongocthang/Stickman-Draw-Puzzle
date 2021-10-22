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
        
        
    }

    public void NextPage()
    {
        //scrollbar.value = Mathf.Lerp(scrollbar.value, pos[pageNumber - 1], 0.1f * Time.deltaTime);
        
        if (pageNumber < 4)
        {
            
            pageNumber++;
            scrollbar.value = pos[pageNumber - 1];
        }
    }

    public void BackPage()
    {
        //scrollbar.value = Mathf.Lerp(scrollbar.value, pos[pageNumber - 1], 0.01f * Time.deltaTime);
        
        if (pageNumber > 1)
        {
            
            pageNumber--;
            scrollbar.value = pos[pageNumber - 1];
        }
    }
}
