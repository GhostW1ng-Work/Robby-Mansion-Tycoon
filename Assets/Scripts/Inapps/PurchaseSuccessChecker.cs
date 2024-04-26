using StarterAssets;
using UnityEngine;
using YG;

public class PurchaseSuccessChecker : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private RewardBoosters _rewardBoosters;
    [SerializeField] private MoneyEarner _moneyEarner;
    [SerializeField] private StarterAssetsInputs _input;

    private void OnEnable()
    {
        YandexGame.PurchaseSuccessEvent += OnPurchaseSuccess;
    }

    private void OnDisable()
    {
        YandexGame.PurchaseSuccessEvent -= OnPurchaseSuccess;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            _rewardBoosters.DeleteBooster(0);
        }
    }

    private void OnPurchaseSuccess(string id)
    {
        switch (id)
        {
            case "buy250k":
                _wallet.AddMoney(250000);
                break;
            case "buy633k":
                _wallet.AddMoney(633000);
                break;
            case "buy1dot9M":
                _wallet.AddMoney(1900000);
                break;
            case "buy2dot5M":
                _wallet.AddMoney(2500000);
                break;
            case "buy6dot3M":
                _wallet.AddMoney(6300000);
                break;
            case "buy12dot6M":
                _wallet.AddMoney(12600000);
                break;
            case "buy25dot3M":
                _wallet.AddMoney(25300000);
                break;
            case "buy54dot3M":
                _wallet.AddMoney(54300000);
                break;
            case "magnet":
                _moneyEarner.SetHasMagnet();
                _rewardBoosters.DeleteBooster(1);
                break;
            case "x2money":
                _moneyEarner.DoubleMultiplier();
                _rewardBoosters.DeleteBooster(2);
                break;
            case "speedBoost":
                _input.SetSprint();
                _rewardBoosters.DeleteBooster(0);
                break;
            case "superman":
                YandexGame.savesData.supermanSkinIsBuyed = true;
                YandexGame.SaveProgress();
                break;
            case "robot":
                YandexGame.savesData.robotSkinIsBuyed = true;
                YandexGame.SaveProgress();
                break;
        }
    }
}
