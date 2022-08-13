using UnityEngine;

public class FriendlyWinParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _friendlyWinParticle = null;

    private void Awake() 
    {
        TeamVictoryControl.Instance.OnSoldierTeamWon += OnSoldierTeamWon;
    }

    private void OnDestroy() 
    {
        if(TeamVictoryControl.Instance != null) TeamVictoryControl.Instance.OnSoldierTeamWon -= OnSoldierTeamWon;
    }

    private void OnSoldierTeamWon(ESoldierTeam soldierTeam)
    {
        if(soldierTeam == ESoldierTeam.Friendly)
        {
            StartParticle();
        }
    }

    private void StartParticle()
    {
        _friendlyWinParticle.Play();        
    }
}
