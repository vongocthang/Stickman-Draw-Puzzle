using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupAudio : MonoBehaviour
{
    public GameObject music;
    public GameObject audioEffects;

    public GameObject musicON;
    public GameObject audioEffectsON;
    public GameObject musicOFF;
    public GameObject audioEffectsOFF;

    // Start is called before the first frame update
    void Start()
    {
        SetupAmThanh();
    }

    public void SetupAmThanh()
    {
        //Mặc định 0 mở 1 tắt
        if (PlayerPrefs.GetInt("AudioEffects") == 0)
        {
            audioEffects.SetActive(true);
            audioEffectsON.SetActive(true);
            audioEffectsOFF.SetActive(false);
        }
        else
        {
            audioEffects.SetActive(false);
            audioEffectsON.SetActive(false);
            audioEffectsOFF.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Music") == 0)
        {
            music.SetActive(true);
            musicON.SetActive(true);
            musicOFF.SetActive(false);
        }
        else
        {
            music.SetActive(false);
            musicON.SetActive(false);
            musicOFF.SetActive(true);
        }
    }

    public void MusicON()
    {
        PlayerPrefs.SetInt("Music", 0);
        music.SetActive(true);
    }

    public void MusicOFF()
    {
        PlayerPrefs.SetInt("Music", 1);
        music.SetActive(false);
    }

    public void AudioEffectsON()
    {
        PlayerPrefs.SetInt("AudioEffects", 0);
        audioEffects.SetActive(true);
    }

    public void AudioEffectsOFF()
    {
        PlayerPrefs.SetInt("AudioEffects", 1);
        audioEffects.SetActive(false);
    }
}
