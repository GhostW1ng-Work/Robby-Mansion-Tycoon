using UnityEngine;

public class MagnetRewardButton : RewardButton
{
    [SerializeField] private MoneyEarner _earner;

    public override void Boost(float seconds)
    {
        base.Boost(seconds);
        _earner.TemporarySetHasMagnet(true);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        BoostEnded += OnBoostEnded;
    }

    private void OnBoostEnded()
    {
        if (BoostActive)
            _earner.TemporarySetHasMagnet(false);
    }
}
