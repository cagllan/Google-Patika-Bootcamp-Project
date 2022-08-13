using UnityEngine;
using UnityEngine.UI;
public class FightButton : MonoBehaviour
{
    [SerializeField] private GameObject  _fightPanel;
    [SerializeField] private Button _fightButton;
    
    private void Awake()
    {
        _fightButton.onClick.AddListener(OnFightButtonClicked);
    }

    private void OnFightButtonClicked()
    {
        SetFightPanelVisibilty(false);
        BattleStartController.Instance.StartBattle();
    }

    private void OnDestroy()
    {
        _fightButton.onClick.RemoveListener(OnFightButtonClicked);
    }

    private void SetFightPanelVisibilty(bool setVisibility)
    {
            _fightPanel.SetActive(setVisibility);     
    }
}
