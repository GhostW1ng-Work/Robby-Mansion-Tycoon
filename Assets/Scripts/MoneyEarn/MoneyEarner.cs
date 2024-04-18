using UnityEngine;
using System;
using YG;

public class MoneyEarner : MonoBehaviour
{
    [SerializeField] private int _currentEarnPerSecond = 10;

    private int _currentMultiplier = 1;
    private float _timeLeft = 1;
    private bool _hasMagnet = false;

    public int CurrentEarnPerSecond => _currentEarnPerSecond;
    public int CurrentMultiplier => _currentMultiplier;

    public Action<int,bool> MoneyEarned;
    public Action LevelIncreased;
    public Action MultiplierChanged;

    private void OnEnable()
    {
        Builder.BuildCreated += OnBuildCreated;
    }

    private void OnDisable()
    {
        Builder.BuildCreated -= OnBuildCreated;
    }

    private void Start()
    {
        _currentMultiplier = YandexGame.savesData.currentMultiplier;
        _hasMagnet = YandexGame.savesData.hasMagnet;
        _currentEarnPerSecond = YandexGame.savesData.earnPerSecond;
    }

    private void Update()
    {
            _timeLeft -= Time.deltaTime;

            if (_timeLeft < 0)
            {
                _timeLeft = 1;
                MoneyEarned?.Invoke(_currentEarnPerSecond * _currentMultiplier,_hasMagnet );
            }
    }

    public void IncreaseLevel()
    {
        _currentEarnPerSecond++;
        LevelIncreased?.Invoke();
        YandexGame.savesData.earnPerSecond = _currentEarnPerSecond;
        YandexGame.SaveProgress();
    }

    private void OnBuildCreated()
    {
        IncreaseLevel();
    }

    public void DoubleMultiplier()
    {
        _currentMultiplier = 2;
        MultiplierChanged?.Invoke();
        YandexGame.savesData.currentMultiplier = _currentMultiplier;
        YandexGame.SaveProgress();
    }

    public void SetHasMagnet()
    {
        _hasMagnet = true;
        YandexGame.savesData.hasMagnet = _hasMagnet;
        YandexGame.SaveProgress();
    }
}
