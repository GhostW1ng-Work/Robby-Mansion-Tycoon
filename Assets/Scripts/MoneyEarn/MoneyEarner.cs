using UnityEngine;
using System;

public class MoneyEarner : MonoBehaviour
{
    [SerializeField] private int _currentEarnPerSecond = 10;

    private int _currentMultiplier = 1;
    private int _currentLevel = 1;
    private float _timeLeft = 1;
    private bool _hasMagnet = false;

    public int CurrentEarnPerSecond => _currentEarnPerSecond;
    public int CurrentMultiplier => _currentMultiplier;

    public Action<int,bool> MoneyEarned;
    public Action LevelIncreased;
    public Action MultiplierChanged;

    private void Update()
    {
            _timeLeft -= Time.deltaTime;

            if (_timeLeft < 0)
            {
                _timeLeft = 1;
                MoneyEarned?.Invoke(_currentEarnPerSecond * _currentMultiplier,_hasMagnet );
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

    public void DoubleMultiplier()
    {
        _currentMultiplier = 2;
        MultiplierChanged?.Invoke();
    }

    public void SetHasMagnet()
    {
        _hasMagnet = true;
    }
}
