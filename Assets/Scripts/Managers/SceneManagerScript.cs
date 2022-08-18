using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public int level;
    void Start()
    {
        level = PlayerPrefs.GetInt("LVL", 0);
        if (level < SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("LVL", SceneManager.GetActiveScene().buildIndex);

        }
        level = PlayerPrefs.GetInt("LVL");
        if (level != SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(level);
        }
    }    

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
