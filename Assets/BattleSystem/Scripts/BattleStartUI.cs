using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleStartUI : MonoBehaviour
{
   
    [SerializeField] private Button _battleStartButton;

    private void Awake()
    {
        _battleStartButton.onClick.AddListener(OnBattleStartButtonClicked);
    }

    private void OnBattleStartButtonClicked()
    {
        SetBattleStartUIVisibilty(false);
        BattleStartController.Instance.StartBattle();
    }

    private void OnDestroy()
    {
        _battleStartButton.onClick.RemoveListener(OnBattleStartButtonClicked);
    }

    private void SetBattleStartUIVisibilty(bool setVisibility)
    {
            gameObject.SetActive(setVisibility);

            
    }
}
