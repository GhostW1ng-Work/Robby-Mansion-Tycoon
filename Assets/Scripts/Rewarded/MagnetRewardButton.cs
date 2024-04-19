using UnityEngine;
using YG;

public class MagnetRewardButton : RewardButton
{
    [SerializeField] private MoneyEarner _earner;

    private void Start()
    {
        HasBuyed = YandexGame.savesData.magnetBoostBuyed;
    }


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

    protected override void OnDisable()
    {
        base.OnDisable();
        BoostEnded -= OnBoostEnded;
    }

    private void OnBoostEnded()
    {
        if (BoostActive)
            _earner.TemporarySetHasMagnet(false);
    }
}
