using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CollectWoodGC : MonoBehaviour
{
    public GameObject winGame;
    public TMP_Text countTime;

    public int countWood;
    public bool beginCountTime;


    public float timeLine;
    float threeSecond = 3;
    float tempSecond = 0;


    public TempDrawLine drawLine;

    GameObject phaoHoa;

    public AudioSource countTimeAudio;
    public AudioSource fireWork;
    public AudioSource musicWin;
    public AudioSource musicIngame;

    public AudioSource truckIdling;

    // Start is called before the first frame update
    void Start()
    {
        drawLine = GameObject.Find("Draw Line").GetComponent<TempDrawLine>();

        phaoHoa = GameObject.Find("Phao Hoa");
        phaoHoa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WinGame();
        //BeginCountTime();
        CountTimeWin();
    }

    public void WinGame()
    {
        if (threeSecond == 1)
        {
            drawLine.enabled = false;

            fireWork.Play();

            int a = PlayerPrefs.GetInt("SceneUnlockedCW");
            if (a < SceneManager.GetActiveScene().buildIndex + 1)
            {
                PlayerPrefs.SetInt("SceneUnlockedCW", SceneManager.GetActiveScene().buildIndex + 1);
            }

            //phaoHoa.SetActive(true);
            //countTime.enabled = false;

            StartCoroutine(DisAtiveCountTime());

            StartCoroutine(ActiveWinGame());

            StartCoroutine(EnableMusicIngame());
        }
    }


    //Đếm thời gian
    public void CountTimeWin()
    {
        //Điều kiện thỏa mãn để bắt đầu đếm
        if (beginCountTime == true)
        {
            if (Time.time > timeLine + tempSecond + 1)
            {
                if (tempSecond < 3)
                {
                    threeSecond--;
                    tempSecond++;
                    countTime.text = threeSecond.ToString();
                }
            }
            if (threeSecond > 0)
            {
                countTime.enabled = true;

                countTimeAudio.enabled = true;
            }
        }

        //Nếu đang đếm mà điều kiện không thỏa mãn nữa thì
        if (beginCountTime == false)
        {
            countTime.enabled = false;
            threeSecond = 3;
            tempSecond = 0;
            countTime.text = 3.ToString();

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
        yield return new WaitForSeconds(4.8f);

        winGame.SetActive(true);

        musicWin.Play();
        fireWork.Stop();
        musicIngame.enabled = false;
    }

    IEnumerator EnableMusicIngame()
    {
        yield return new WaitForSeconds(10f);

        musicIngame.enabled = true;
    }
}
