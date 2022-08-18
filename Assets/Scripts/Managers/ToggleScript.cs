using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public bool soundOn;
    public bool canVibrate;

    private int soundOnPlayerPrefs;
    private int vibrationOnPlayerPrefs;
    [SerializeField] Image audioImage;
    [SerializeField] Image vibrationImage;
    [SerializeField] Sprite on;
    [SerializeField] Sprite off;
    void Start()
    {
        soundOnPlayerPrefs = PlayerPrefs.GetInt("SoundOn", 1);
        vibrationOnPlayerPrefs = PlayerPrefs.GetInt("VibrationOn", 1);

        if (soundOnPlayerPrefs==1)
        {
            soundOn = true;            
            audioImage.sprite = on;                      
            AudioListener.pause = false;
        }
        else if (soundOnPlayerPrefs==0)
        {
            soundOn = false;            
            audioImage.sprite = off;                    
            AudioListener.pause = true;
        }

        if (vibrationOnPlayerPrefs == 1)
        {            
            canVibrate = true;            
            vibrationImage.sprite = on;            
        }
        else if (vibrationOnPlayerPrefs == 0)
        {            
            canVibrate = false;            
            vibrationImage.sprite = off;            
        }
    }

    public void ToggleSound()
    {
        if (soundOn)
        {
            AudioListener.pause = true;
            soundOn = false;
            audioImage.sprite = off;    
            PlayerPrefs.SetInt("SoundOn", soundOn ? 1 : 0);
        }
        else if (!soundOn)
        {            
            AudioListener.pause = false;
            soundOn = true;
            audioImage.sprite = on;            
            PlayerPrefs.SetInt("SoundOn", soundOn ? 1 : 0);
        }
    }

    public void ToggleVibration()
    {
        if (canVibrate)
        {
            canVibrate = false;
            vibrationImage.sprite = off;
            PlayerPrefs.SetInt("VibrationOn", canVibrate ? 1 : 0);
        }
        else if (!canVibrate)
        {
            canVibrate = true;
            vibrationImage.sprite = on;
            PlayerPrefs.SetInt("VibrationOn", canVibrate ? 1 : 0);
        }
    }
}
