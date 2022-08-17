using System;
using System.Collections;
using UnityEngine;

public class VictoryPanelController : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel = null;
    [SerializeField] private GameObject _losePanel = null;

    private IEnumerator _winPanelRoutine;
    private IEnumerator _losePanelRoutine;


    private void Awake() 
    {
        TeamVictoryControl.Instance.OnSoldierTeamWon += OnSoldierTeamWon;
    }

    private void OnDestroy()
    {
        StopWinPanelRoutine();
        StopLosePanelRoutine();
        if(TeamVictoryControl.Instance != null) TeamVictoryControl.Instance.OnSoldierTeamWon += OnSoldierTeamWon;
    }

    private void OnSoldierTeamWon(ESoldierTeam soldierTeam)
    {
        if(soldierTeam == ESoldierTeam.Friendly)
        {
            StartWinPanelRoutine();
        }
        else if(soldierTeam == ESoldierTeam.Enemy)
        {
            StartLosePanelRoutine();
        }
    }

    private void WinPanelVisibility()
    {
        _winPanel.SetActive(true);
    }

    private void LosePanelVisibility()
    {
        _losePanel.SetActive(true);
    }


    // win panel routine
    private void StartWinPanelRoutine()
    {
        StopWinPanelRoutine();

        _winPanelRoutine = WinPanelProgress();
        StartCoroutine(_winPanelRoutine);
    }

    private void StopWinPanelRoutine()
    {
        if(_winPanelRoutine != null)
        {
            StopCoroutine(_winPanelRoutine);
        }
    }

    private IEnumerator WinPanelProgress()
    {
        yield return new WaitForSeconds(3);
        WinPanelVisibility();
    }


    // lose panel routine 
    private void StartLosePanelRoutine()
    {
        StopLosePanelRoutine();

        _losePanelRoutine = LosePanelProgress();
        StartCoroutine(_losePanelRoutine);
    }

    private void StopLosePanelRoutine()
    {
        if(_losePanelRoutine != null)
        {
            StopCoroutine(_losePanelRoutine);
        }
    }

        private IEnumerator LosePanelProgress()
    {
        yield return new WaitForSeconds(3);
        LosePanelVisibility();
    }
    
}
