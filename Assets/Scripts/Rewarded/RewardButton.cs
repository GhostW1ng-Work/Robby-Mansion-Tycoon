using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

public abstract class RewardButton : MonoBehaviour
{
    [SerializeField] protected float TimeBeforeDisable = 10f;
    [SerializeField] protected float BoostTime = 10f;
    [SerializeField] protected int Id;

    protected float CurrentTime;
    protected CanvasGroup CanvasGroup;
    protected bool IsActive = false;
    protected bool BoostActive = false;
    protected bool HasBuyed = false;

    protected Button Button;

    public static event Action TimedUp;
    public static event Action BoostEnded;

    protected void Awake()
    {
        Button = GetComponent<Button>();
        CanvasGroup = GetComponent<CanvasGroup>();
    }

    protected virtual void OnEnable()
    {
        Button.onClick.AddListener(OnClick);
        YandexGame.RewardVideoEvent += OnRewardedVideoEvent;
    }

    protected virtual void OnDisable()
    {
        Button.onClick.RemoveListener(OnClick);
        YandexGame.RewardVideoEvent -= OnRewardedVideoEvent;
    }

    protected void OnClick()
    {
        YandexGame.RewVideoShow(Id);
    }

    public virtual void Boost(float seconds)
    {
        BoostActive = true;
        CurrentTime = seconds;
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
    }

    protected void Update()
    {
        if (IsActive)
        {
            CurrentTime -= Time.deltaTime;
            if (CurrentTime <= 0)
            {
                IsActive = false;
                CanvasGroup.alpha = 0;
                CanvasGroup.interactable = false;
                CanvasGroup.blocksRaycasts = false;
                TimedUp?.Invoke();
            }
        }
        else if (BoostActive)
        {
            BoostEnded?.Invoke();
            BoostActive = false;
        }
    }

    public void SetIsActive(bool isActive)
    {
        IsActive = isActive;
        CurrentTime = TimeBeforeDisable;
    }

    protected void OnRewardedVideoEvent(int id)
    {
        if (id == Id)
        {
            Boost(BoostTime);
        }
    }

    public void SetId(int id)
    {
        Id = id;
    }

    public void SetHasBuyed(bool hasBuyed)
    {
        HasBuyed = hasBuyed;
    }

    public bool GetHasBuyed()
    {
        return HasBuyed;
    }
}
