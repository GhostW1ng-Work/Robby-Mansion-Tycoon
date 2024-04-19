using System.Collections.Generic;
using UnityEngine;
using YG;

public class RewardBoosters : MonoBehaviour
{
    [SerializeField] private List<RewardButton> _rewardedBoosters;
    [SerializeField] private float _minTime = 20;
    [SerializeField] private float _maxTime = 40;

    private float _currentTime = 0;
    private int _currentIndex = 0;
    private bool _isActive = true;

    private void OnEnable()
    {
        RewardButton.TimedUp += OnTimedUp;
        RewardButton.BoostEnded += OnTimedUp;
    }

    private void OnDisable()
    {
        RewardButton.TimedUp -= OnTimedUp;
        RewardButton.BoostEnded -= OnTimedUp;
    }

    private void Start()
    {
        _currentTime = Random.Range(_minTime, _maxTime);

        for (int i = 0; i < _rewardedBoosters.Count; i++)
        {
            _rewardedBoosters[i].GetComponent<CanvasGroup>().alpha = 0;
            _rewardedBoosters[i].GetComponent<CanvasGroup>().blocksRaycasts = false;
            _rewardedBoosters[i].GetComponent<CanvasGroup>().interactable = false;
            _rewardedBoosters[i].SetId(i);
        }
    }

    private void Update()
    {
        if (_currentTime > 0 && _isActive)
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                _currentIndex = Random.Range(0, _rewardedBoosters.Count);
                for (int i = 0; i < _rewardedBoosters.Count; i++)
                {
                    if (i == _currentIndex)
                    {
                        if (!_rewardedBoosters[i].GetHasBuyed())
                        {
                            _rewardedBoosters[i].SetIsActive(true);
                            _rewardedBoosters[i].GetComponent<CanvasGroup>().alpha = 1;
                            _rewardedBoosters[i].GetComponent<CanvasGroup>().blocksRaycasts = true;
                            _rewardedBoosters[i].GetComponent<CanvasGroup>().interactable = true;
                            _isActive = false;
                        }
                        else
                        {
                            _currentTime = Random.Range(_minTime, _maxTime);
                        }
                    }
                    else
                    {
                        _rewardedBoosters[i].GetComponent<CanvasGroup>().alpha = 0;
                        _rewardedBoosters[i].GetComponent<CanvasGroup>().blocksRaycasts = false;
                        _rewardedBoosters[i].GetComponent<CanvasGroup>().interactable = false;
                    }
                }
            }
        }
    }

    public void DeleteBooster(int index)
    {
        _rewardedBoosters[index].SetHasBuyed(true);
        switch (index)
        {
            case 0:
                YandexGame.savesData.speedBoostBuyed = true;
                YandexGame.SaveProgress();
                break;
            case 1:
                YandexGame.savesData.magnetBoostBuyed = true;
                YandexGame.SaveProgress();
                break;
            case 2:
                YandexGame.savesData.doubleMoneyBoostBuyed = true;
                YandexGame.SaveProgress();
                break;
        }
    }

    private void OnTimedUp()
    {
        _isActive = true;
        _currentTime = Random.Range(_minTime, _maxTime);
    }
}
