using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator canvasAnim;

    public void OpenShop()
    {
        canvasAnim.SetBool("isShopOpen", true);
    }

    public void CloseShop()
    {
        canvasAnim.SetBool("isShopOpen", false);
    }

    public void StartFight(){
        canvasAnim.SetBool("isFightStarted", true);
    }

    public void OpenSettings()
    {
        canvasAnim.SetBool("isSettingsOpen", true);
    }

    public void CloseSettings()
    {
        canvasAnim.SetBool("isSettingsOpen", false);
    }

    public void Checkmate(){
        canvasAnim.SetBool("isCheckMateOpen",true);
    }
}
