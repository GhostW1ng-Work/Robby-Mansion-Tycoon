using UnityEngine;
using System;
using YG;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private MoneyEarner _earner;

    private int _currentMoney;

    public int CurrentMoney => _currentMoney;

    public event Action<int> MoneyChanged;

    private void Start()
    {
        _currentMoney = YandexGame.savesData.playerMoney;
        MoneyChanged?.Invoke(_currentMoney);
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
        MoneyChanged?.Invoke(_currentMoney);
        YandexGame.savesData.playerMoney = _currentMoney;
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
