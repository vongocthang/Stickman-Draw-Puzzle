using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIoff : MonoBehaviour
{
    public GameObject[] uiOFF;
    public GameObject tempJoystick;

    // Start is called before the first frame update
    void Start()
    {
        uiOFF = GameObject.FindGameObjectsWithTag("uiOFF");
        if(GameObject.Find("Temp Fixed Joystick")!=null)
        {
            tempJoystick = GameObject.Find("Temp Fixed Joystick");
            tempJoystick.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            for(int i=0; i<uiOFF.Length; i++)
            {
                uiOFF[i].SetActive(false);
                if (tempJoystick != null)
                {
                    tempJoystick.SetActive(true);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < uiOFF.Length; i++)
            {
                uiOFF[i].SetActive(true);
                if (tempJoystick != null)
                {
                    tempJoystick.SetActive(false);
                }
            }
        }
    }
}
