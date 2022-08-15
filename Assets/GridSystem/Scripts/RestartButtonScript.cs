using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonScript : MonoBehaviour
{
    private GameObject sceneManagerGO;
    public void FindSceneManager()
    {
        sceneManagerGO = GameObject.Find("SceneManager");
        sceneManagerGO.GetComponent<SceneManagerScript>().RestartLevel();
    }
}
