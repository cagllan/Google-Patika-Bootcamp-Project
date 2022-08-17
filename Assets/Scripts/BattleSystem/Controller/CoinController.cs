using UnityEngine;
using TMPro;

public class CoinController : MonoBehaviour
{
    public static CoinController _instance;

    public static CoinController Instance 
    { 
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<CoinController>();
            }

            return _instance;
        }
    }

    [SerializeField] private TMP_Text _coinAmountText = null;
    [SerializeField] private int _baseCoinAmount;
    [SerializeField] private int _enemyWinCoinAmount;
    [SerializeField] private int _friendlyWinCoinAmount;

    [SerializeField] private TMP_Text _enemyWinCoinText;
    [SerializeField] private TMP_Text _friendlyWinCoinText;
    

    private const string _coinKey = "Coin";

    private void Awake() {
        TeamVictoryControl.Instance.OnSoldierTeamWon += OnSoldierTeamWon;
    }

    private void Start() 
    {
        if(!PlayerPrefs.HasKey(_coinKey))
        {
            PlayerPrefs.SetInt(_coinKey, _baseCoinAmount);
            _coinAmountText.text = PlayerPrefs.GetInt(_coinKey).ToString();
        }
        else
        {
            _coinAmountText.text = GetCoinAmount().ToString();
        }

        GetEnemyWinCoinAmountAsAString();
        GetFriendlyWinCoinAmountAsAString();

    }

    private void OnDestroy() 
    {
        if(TeamVictoryControl.Instance != null) TeamVictoryControl.Instance.OnSoldierTeamWon -= OnSoldierTeamWon;      
    }


    private void OnSoldierTeamWon(ESoldierTeam soldierTeam)
    {
        if(soldierTeam == ESoldierTeam.Friendly )
        {
            IncreaseAmountOfCoin(_friendlyWinCoinAmount);
        }
        else if(soldierTeam == ESoldierTeam.Enemy)
        {
           IncreaseAmountOfCoin(_enemyWinCoinAmount); 
        }
    }

    private int GetCoinAmount()
    {
        int coinAmount = PlayerPrefs.GetInt(_coinKey);
        return coinAmount;
    }

    private void SetCoinAmount(int coinAmount)
    {
        PlayerPrefs.SetInt(_coinKey, coinAmount);
    }
  
    public void IncreaseAmountOfCoin(int increaseAmount)
    {
        int coinAmount = PlayerPrefs.GetInt(_coinKey) + increaseAmount;
        _coinAmountText.text = coinAmount.ToString();
        SetCoinAmount(coinAmount);
    }

    public void DecreaseAmountOfCoin(int decreaseAmount)
    {
        int coinAmount = PlayerPrefs.GetInt(_coinKey) - decreaseAmount;

        if (coinAmount <= 0)
        {
            coinAmount = 0;
            _coinAmountText.text = coinAmount.ToString();
            SetCoinAmount(coinAmount);
            Debug.Log("Satın alamazsın. - " + PlayerPrefs.GetInt(_coinKey));
            return;
        }
        
         _coinAmountText.text = coinAmount.ToString();
        SetCoinAmount(coinAmount);
    }

    private void GetEnemyWinCoinAmountAsAString()
    {
       _enemyWinCoinText.SetText(_enemyWinCoinAmount.ToString());
    }

    private void GetFriendlyWinCoinAmountAsAString()
    {
       _friendlyWinCoinText.SetText(_friendlyWinCoinAmount.ToString());
    }
}











