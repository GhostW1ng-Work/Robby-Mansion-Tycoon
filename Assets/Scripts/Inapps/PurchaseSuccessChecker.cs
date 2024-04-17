using UnityEngine;
using YG;

public class PurchaseSuccessChecker : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private MoneyEarner _moneyEarner;

    private void OnEnable()
    {
        YandexGame.PurchaseSuccessEvent += OnPurchaseSuccess;
    }

    private void OnDisable()
    {
        YandexGame.PurchaseSuccessEvent -= OnPurchaseSuccess;
    }

    private void OnPurchaseSuccess(string id)
    {
        switch (id)
        {
            case "buy250k":
                _wallet.AddMoney(250);
                break;
            case "magnet":
                _moneyEarner.SetHasMagnet();
                break;
            case "x2money":
                _moneyEarner.DoubleMultiplier();
                break;
        }
    }
}
