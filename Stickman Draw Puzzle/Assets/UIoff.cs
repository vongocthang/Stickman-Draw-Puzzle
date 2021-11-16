using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIoff : MonoBehaviour
{
    public GameObject[] uiOFF;

    // Start is called before the first frame update
    void Start()
    {
        uiOFF = GameObject.FindGameObjectsWithTag("uiOFF");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            for(int i=0; i<uiOFF.Length; i++)
            {
                uiOFF[i].SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < uiOFF.Length; i++)
            {
                uiOFF[i].SetActive(true);
            }
        }
    }
}
