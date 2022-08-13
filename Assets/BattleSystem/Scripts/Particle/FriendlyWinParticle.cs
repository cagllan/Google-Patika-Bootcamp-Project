using UnityEngine;

public class FriendlyWinParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem _friendlyWinParticle = null;


    private void Awake() 
    {
        TeamVictoryControl.Instance.OnSoldierTeamWon += OnSoldierTeamWon;
    }

    private void Start() {
        gameObject.SetActive(false);
    }

    private void OnDestroy() 
    {
        gameObject.SetActive(false);
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
        gameObject.SetActive(true);
        _friendlyWinParticle.Play();        
    }
}
