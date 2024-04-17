using UnityEngine;
using YG;

public class PurchaseSuccessChecker : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
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
        }
    }
}
