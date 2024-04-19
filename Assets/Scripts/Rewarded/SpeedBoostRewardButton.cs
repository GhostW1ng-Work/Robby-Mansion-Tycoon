using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBoostRewardButton : RewardButton
{
    [SerializeField] private StarterAssetsInputs _inputs;
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

    private void OnBoostEnded()
    {
        if(BoostActive)
            _inputs.TemporarySetSprint(false);
    }
}
