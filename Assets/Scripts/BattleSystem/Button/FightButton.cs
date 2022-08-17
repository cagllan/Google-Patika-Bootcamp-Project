using UnityEngine;
using UnityEngine.UI;
public class FightButton : MonoBehaviour
{
    [SerializeField] private GameObject  _fightPanel;
    [SerializeField] private Button _fightButton;
    [SerializeField] Transform[] slots;
    
    private void Awake()
    {
        _fightButton.onClick.AddListener(OnFightButtonClicked);
    }

    private void OnFightButtonClicked()
    {
        SetFightPanelVisibilty(false);
        BattleStartController.Instance.StartBattle();
        foreach (var slot in slots)
        {
            if (slot.childCount > 0)
            {
                Destroy(slot.GetChild(0).GetComponent<Drag>());
            }
        }
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
