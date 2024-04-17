using UnityEngine;
using System;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private MoneyEarner _earner;

    private int _currentMoney = 100;

    public event Action<int> MoneyChanged;

    private void Start()
    {
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
    }

    private void OnMoneyEarned(int money, bool hasMagnet)
    {
        if (hasMagnet) 
        { 
            AddMoney(money);
        }
    }
}
