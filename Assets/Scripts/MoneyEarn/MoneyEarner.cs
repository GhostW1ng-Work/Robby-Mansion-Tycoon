using UnityEngine;
using System;

public class MoneyEarner : MonoBehaviour
{
    [SerializeField] private int _currentEarnPerSecond = 10;

    private int _currentMultiplayer = 1;
    private float _timeLeft = 1;

    public Action<int> MoneyEarned;
    private void Update()
    {
        _timeLeft -= Time.deltaTime;

        if(_timeLeft < 0)
        {
            _timeLeft = 1;
            MoneyEarned?.Invoke(_currentEarnPerSecond * _currentMultiplayer);
        }
    }

    public void IncreaseEarnPerSecond()
    {
        _currentEarnPerSecond++;
    }
}
