using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPenClaim : MonoBehaviour
{
    public Slider slider;
    public int sliderPos;
    public TMP_Text claim;
    public int penNumber;
    public int load1;
    public int load2;
    public int tempLoad;
    public GameObject claimButton;

    UIControl uiControl;

    // Start is called before the first frame update
    void Start()
    {
        uiControl = GameObject.Find("MainUI").GetComponent<UIControl>();
        penNumber = int.Parse(this.name.Substring(5, 2));
        if (penNumber == 1 || penNumber == 2)
        {
            load1 = 20;
            load2 = 10;
        }
        else if (penNumber == 3 || penNumber == 4)
        {
            load1 = 10;
            load2 = 5;
        }
        else
        {
            load1 = 5;
            load2 = 2;
        }
        slider.value = PlayerPrefs.GetInt("PenLoad");
        tempLoad = PlayerPrefs.GetInt("PenLoad");
        sliderPos = PlayerPrefs.GetInt("PenLoad");

        Debug.Log(PlayerPrefs.GetInt("PenLoad"));
    }

    // Update is called once per frame
    void Update()
    {
        LoadPen();

        if (slider.value == 100)
        {
            claimButton.SetActive(true);
        }  
    }

    public void LoadPen()
    {
        
        if (uiControl.countStar == 3)
        {
            PlayerPrefs.SetInt("PenLoad", sliderPos + load1);
            if (slider.value != sliderPos + load1)
            {
                Debug.Log("Loading 3 star");
                slider.value = Mathf.MoveTowards(slider.value, sliderPos + load1, 0.2f); 
            }
            if (slider.value > tempLoad)
            {
                Debug.Log("Tang %");
                tempLoad++;
                claim.text = tempLoad.ToString() + "%";
            }
            if (slider.value == sliderPos + load1)
            {
                Debug.Log("Ket thuc load");
                
            }
        }
        else
        {
            PlayerPrefs.SetInt("PenLoad", sliderPos + load2);
            if (slider.value != sliderPos + load2)
            {
                Debug.Log("Loading < 3 star");
                slider.value = Mathf.MoveTowards(slider.value, sliderPos + load2, 0.2f);
            }
            if (slider.value > tempLoad)
            {
                Debug.Log("Tang %");
                tempLoad++;
                claim.text = tempLoad.ToString() + "%";
            }
            if (slider.value == sliderPos + load2)
            {
                Debug.Log("Ket thuc load");
                PlayerPrefs.SetInt("PenLoad", sliderPos + load2);
            }
        }
    }

    public void ClaimPen()
    {
        PlayerPrefs.SetInt("Pen" + penNumber.ToString(), 1);
        PlayerPrefs.SetInt("Pen", penNumber);
        PlayerPrefs.SetInt("PenLoad", 0);
        if (penNumber < 5)
        {
            PlayerPrefs.SetInt("ClaimPen", PlayerPrefs.GetInt("ClaimPen") + 1);
        }
        Destroy(this.transform.gameObject);
    }
}
