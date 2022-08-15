using System.Collections;
using UnityEngine;

public class FriendlyWinParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _friendlyWinParticle = null;
    private IEnumerator _winParticleRoutine;

    

    private void Awake() 
    {
        TeamVictoryControl.Instance.OnSoldierTeamWon += OnSoldierTeamWon;
    }

    private void OnDestroy() 
    {
        StopWinParticleRoutine();
        if(TeamVictoryControl.Instance != null) TeamVictoryControl.Instance.OnSoldierTeamWon -= OnSoldierTeamWon;
    }

    private void OnSoldierTeamWon(ESoldierTeam soldierTeam)
    {
        if(soldierTeam == ESoldierTeam.Friendly)
        {
            StartWinParticleRoutine();
        }
    }

    private void StartParticle()
    {
        _friendlyWinParticle.Play();        
    }

    private IEnumerator WinParticleProgress()
    {
        yield return new WaitForSeconds(1);
        StartParticle();
    }


    private void StartWinParticleRoutine()
    {
        StopWinParticleRoutine();

        _winParticleRoutine = WinParticleProgress();
        StartCoroutine(_winParticleRoutine);
    }

    private void StopWinParticleRoutine()
    {
        if(_winParticleRoutine != null)
        {
            StopCoroutine(_winParticleRoutine);
        }
    }

    
}
