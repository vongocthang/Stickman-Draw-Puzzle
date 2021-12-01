using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//Điều khiển chế độ Basic
public class BasicModeGC : MonoBehaviour
{
    Target target;
    public GameObject winGame;
    public TMP_Text countTime;

    float threeSecond = 3;
    float tempSecond = 0;

    //Điều khiển thanh nâng của xe
    public bool up, down;

    public UIControl uiControl;

    TempDrawLine drawLine;

    GameObject phaoHoa;

    public AudioSource countTimeAudio;
    public AudioSource fireWork;
    public AudioSource musicWin;
    public AudioSource musicIngame;

    public AudioSource truckIdling;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Target").GetComponent<Target>();
        drawLine = GameObject.Find("Draw Line").GetComponent<TempDrawLine>();

        phaoHoa = GameObject.Find("Phao Hoa");
        phaoHoa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WinGame();
        CountTimeWin();
    }

    public void WinGame()
    {
        if (threeSecond == 1)
        {
            //Tắt vẽ Line
            drawLine.enabled = false;

            fireWork.Play();

            int a = PlayerPrefs.GetInt("SceneUnlockedBM");
            if (a < SceneManager.GetActiveScene().buildIndex + 1)
            {
                PlayerPrefs.SetInt("SceneUnlockedBM", SceneManager.GetActiveScene().buildIndex + 1);
            }

            StartCoroutine(DisAtiveCountTime());

            StartCoroutine(ActiveWinGame());

            StartCoroutine(AudioFireWork());

            StartCoroutine(EnableMusicIngame());
        }
    }

    //Đếm thời gian
    public void CountTimeWin()
    {
        if (target.beginCountTime == true)
        {
            if (Time.time > target.timeLine + tempSecond + 1)
            {
                if (tempSecond < 3)
                {
                    threeSecond--;
                    tempSecond++;
                    countTime.text = threeSecond.ToString();
                }
            }
            if (threeSecond > 1)
            {
                countTime.enabled = true;

                countTimeAudio.enabled = true;
            }
        }

        if (target.beginCountTime == false)
        {
            countTime.text = 3.ToString();
            threeSecond = 3;
            tempSecond = 0;
            countTime.enabled = false;

            countTimeAudio.enabled = false;
        }
    }

    IEnumerator DisAtiveCountTime()
    {
        yield return new WaitForSeconds(0.5f);

        countTime.enabled = false;
        phaoHoa.SetActive(true);
        
        countTimeAudio.enabled = false;

        truckIdling.Stop();
    }

    IEnumerator ActiveWinGame()
    {
        yield return new WaitForSeconds(1.5f);

        winGame.SetActive(true);

        musicWin.Play();
        musicIngame.enabled = false;
    }

    IEnumerator AudioFireWork()
    {
        yield return new WaitForSeconds(4.8f);

        fireWork.Stop();
    }

    IEnumerator EnableMusicIngame()
    {
        yield return new WaitForSeconds(7f);

        musicIngame.enabled = true;
    }

    //Điều khiển nâng
    public void ElevateUp()
    {
        up = true;
    }

    public void ElevateDown()
    {
        down = true;
    }

    public void NotElevate()
    {
        up = false;
        down = false;
    }
}
