using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    //[SerializeField] GameObject checkmark;
    private bool soundOn;
    public bool canVibrate;

    private int soundOnPlayerPrefs;
    [SerializeField] Image toggleImage;
    [SerializeField] Sprite on;
    [SerializeField] Sprite off;
    void Start()
    {
        soundOnPlayerPrefs = PlayerPrefs.GetInt("SoundOn", 1);
        if (soundOnPlayerPrefs==1)
        {
            soundOn = true;
            canVibrate=true;
            toggleImage.sprite = on;
            //checkmark.SetActive(false);
            AudioListener.pause = false;
        }
        else if (soundOnPlayerPrefs==0)
        {
            soundOn = false;
            canVibrate=false;
            toggleImage.sprite = off;
            //checkmark.SetActive(true);
            AudioListener.pause = true;
        }
    }

    public void ToggleSound()
    {
        if (soundOn)
        {
            /*if (!gameMusic.audioSource.isPlaying)
            {
                gameMusic.audioSource.Play();
            }
            else
            {
                gameMusic.audioSource.Stop();
            }*/
            AudioListener.pause = true;
            soundOn = false;
            canVibrate=false;
            toggleImage.sprite = off;
            //checkmark.SetActive(true);
            PlayerPrefs.SetInt("SoundOn", soundOn ? 1 : 0);
        }
        else if (!soundOn)
        {
            /*if (!gameMusic.audioSource.isPlaying)
            {
                gameMusic.audioSource.Play();
            }
            else
            {
                gameMusic.audioSource.Stop();
            }*/
            AudioListener.pause = false;
            soundOn = true;
            canVibrate=true;
            toggleImage.sprite = on;
            //checkmark.SetActive(false);
            PlayerPrefs.SetInt("SoundOn", soundOn ? 1 : 0);
        }
    }
}
