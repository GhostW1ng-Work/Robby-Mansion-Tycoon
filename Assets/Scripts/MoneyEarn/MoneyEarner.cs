using UnityEngine;
using System;

public class MoneyEarner : MonoBehaviour
{
    [SerializeField] private int _currentEarnPerSecond = 10;

    private int _currentMultiplayer = 1;
    private int _currentLevel = 1;
    private float _timeLeft = 1;
    private bool _hasMagnet = false;

    public int CurrentEarnPerSecond => _currentEarnPerSecond;

    public Action<int,bool> MoneyEarned;
    public Action LevelIncreased;

    private void Update()
    {
            _timeLeft -= Time.deltaTime;

            if (_timeLeft < 0)
            {
                _timeLeft = 1;
                MoneyEarned?.Invoke(_currentEarnPerSecond * _currentMultiplayer,_hasMagnet );
            }


        if (Input.GetKeyDown(KeyCode.K))
        {
            IncreaseLevel();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            _hasMagnet = !_hasMagnet;
        }
    }

    public void IncreaseEarnPerSecond()
    {
        _currentEarnPerSecond++;
    }

    public void IncreaseLevel()
    {
        _currentLevel++;
        _currentEarnPerSecond++;
        LevelIncreased?.Invoke();
    }
}
