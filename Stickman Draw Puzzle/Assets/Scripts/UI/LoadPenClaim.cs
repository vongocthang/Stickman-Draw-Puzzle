using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPenClaim : MonoBehaviour
{
    public Slider slider;
    public TMP_Text claim;
    public int penNumber;
    public float load1;
    public float load2;
    public GameObject claimButton;

    UIControl uiControl;

    // Start is called before the first frame update
    void Start()
    {
        uiControl = GameObject.Find("MainUI").GetComponent<UIControl>();
        penNumber = int.Parse(this.name.Substring(5, 2));
        if (penNumber == 1 || penNumber == 2)
        {
            load1 = 0.2f;
            load2 = 0.1f;
        }
        else if (penNumber == 3 || penNumber == 4)
        {
            load1 = 0.1f;
            load2 = 0.05f;
        }
        else
        {
            load1 = 0.05f;
            load2 = 0.02f;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value == 1)
        {
            claim.text = "CLAIM";
        }

        LoadPen();
    }

    public void LoadPen()
    {
        slider.value = PlayerPrefs.GetFloat("PenLoad");
        float a = slider.value;
        if (uiControl.countStar == 3)
        {
            slider.value = Mathf.Lerp(a, a + load1, 10 * Time.deltaTime);
        }
        else
        {
            slider.value = Mathf.Lerp(a, a + load2, 10 * Time.deltaTime);
        }
    }

    public void ClaimPen()
    {

    }
}
