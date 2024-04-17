using UnityEngine;
using System;

public class PlayerWallet : MonoBehaviour
{
    private int _currentMoney = 100;

    public event Action<int> MoneyChanged;

    private void Start()
    {
        MoneyChanged?.Invoke(_currentMoney);
    }

    public void AddMoney(int money)
    {
        _currentMoney += money;
        MoneyChanged?.Invoke(_currentMoney);
    }
}
