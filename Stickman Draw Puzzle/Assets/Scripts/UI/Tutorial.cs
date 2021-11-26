using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Chỉ xuất hiện lần đầu tại map có Tutorial, lần sau chơi lại k hiện

public class Tutorial : MonoBehaviour
{
    public GameObject[] tuto;
    public GameObject[] noOFF;

    public GameObject win;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("Tutorial" + SceneManager.GetActiveScene().buildIndex.ToString(), 0);

        if(PlayerPrefs.GetInt("Tutorial" + SceneManager.GetActiveScene().buildIndex.ToString()) != 0)
        {
            if (noOFF != null)
            {
                for (int i = 0; i < noOFF.Length; i++)
                {
                    Destroy(noOFF[i]);
                }
            }
            for (int i = 0; i < tuto.Length; i++)
            {
                Destroy(tuto[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < tuto.Length; i++)
            {
                Destroy(tuto[i]);
            }
        }

        if (win.activeSelf)
        {
            PlayerPrefs.SetInt("Tutorial" + SceneManager.GetActiveScene().buildIndex.ToString(), 5);

            Debug.Log("Tat tutorial");
            if (noOFF != null)
            {
                for (int i = 0; i < noOFF.Length; i++)
                {
                    Destroy(noOFF[i]);
                }
            }
            for (int i = 0; i < tuto.Length; i++)
            {
                Destroy(tuto[i]);
            }
        }
    }
}
