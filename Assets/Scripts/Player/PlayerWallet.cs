using UnityEngine;
using System;
using YG;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private MoneyEarner _earner;

    private int _currentMoney;
    private int _earnedMoney;

    public int CurrentMoney => _currentMoney;

    public event Action<int> MoneyChanged;

    private void Start()
    {
        _earnedMoney = YandexGame.savesData.earnedMoney;
        _currentMoney = YandexGame.savesData.playerMoney;
        MoneyChanged?.Invoke(_currentMoney);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            AddMoney(200000);
        }
    }
    private void OnEnable()
    {
        _earner.MoneyEarned += OnMoneyEarned;
    }

    private void OnDisable()
    {
        _earner.MoneyEarned -= OnMoneyEarned;
    }

    public void AddMoney(int money)
    {
        _currentMoney += money;
        _earnedMoney += money;
        MoneyChanged?.Invoke(_currentMoney);
        YandexGame.savesData.earnedMoney = _earnedMoney;
        YandexGame.savesData.playerMoney = _currentMoney;
        YandexGame.NewLeaderboardScores("earnedMoney", _earnedMoney);
        YandexGame.SaveProgress();
    }

    public void SpendMoney(int money)
    {
        _currentMoney -= money;
        MoneyChanged?.Invoke(_currentMoney);
        YandexGame.savesData.playerMoney = _currentMoney;
        YandexGame.SaveProgress();
    }

    private void OnMoneyEarned(int money, bool hasMagnet)
    {
        if (hasMagnet) 
        { 
            AddMoney(money);
        }
    }
}
