using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class RewardButton : MonoBehaviour
{
    [SerializeField] protected float TimeBeforeDisable = 10f;
    [SerializeField] protected float BoostTime = 10f;

    protected float CurrentTime;
    protected CanvasGroup CanvasGroup;
    protected bool IsActive = false;
    protected bool BoostActive = false;

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
    }

    protected virtual void OnDisable()
    {
        Button.onClick.RemoveListener(OnClick);
    }

    protected void OnClick()
    {
        Boost(BoostTime);
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

}
