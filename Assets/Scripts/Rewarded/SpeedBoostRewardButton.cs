using StarterAssets;
using UnityEngine;
using YG;

public class SpeedBoostRewardButton : RewardButton
{
    [SerializeField] private StarterAssetsInputs _inputs;

    private void Start()
    {
        HasBuyed = YandexGame.savesData.speedBoostBuyed;
    }

    public override void Boost(float seconds)
    {
        base.Boost(seconds);
        _inputs.TemporarySetSprint(true);
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
        if(BoostActive)
            _inputs.TemporarySetSprint(false);
    }
}