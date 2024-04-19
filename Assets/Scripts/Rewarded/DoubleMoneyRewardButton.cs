using UnityEngine;

public class DoubleMoneyRewardButton : RewardButton
{
    [SerializeField] private MoneyEarner _earner;

    public override void Boost(float seconds)
    {
        base.Boost(seconds);
        _earner.TemporaryDoubleMultiplier(2);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        BoostEnded += OnBoostEnded;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        BoostEnded -= OnBoostEnded;
    }

    private void OnBoostEnded()
    {
        if (BoostActive)
            _earner.TemporaryDoubleMultiplier(1);
    }
}
