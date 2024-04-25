using GameAnalyticsSDK;
using UnityEngine;
using YG;
using YG.Utils.Pay;

public class PurchaseButton : MonoBehaviour
{
    [SerializeField] private string _id;

    private void OnEnable()
    {
        YandexGame.PurchaseSuccessEvent += OnSuccessPurchase;
    }

    private void OnDisable()
    {
        YandexGame.PurchaseSuccessEvent -= OnSuccessPurchase;
    }

    private void Start()
    {
        switch (_id)
        {
            case "magnet":
                if (YandexGame.savesData.magnetBoostBuyed)
                {
                    Destroy(gameObject);
                }
                break;
            case "x2money":
                if (YandexGame.savesData.doubleMoneyBoostBuyed)
                {
                    Destroy(gameObject);
                }
                break;
            case "speedBoost":
                if (YandexGame.savesData.speedBoostBuyed)
                {
                    Destroy(gameObject);
                }
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet player))
        {
            Purchase purchase = YandexGame.PurchaseByID(_id);
            YandexGame.BuyPayments(purchase.id);
            GameAnalytics.NewDesignEvent("Click to " + purchase.id);
        }
    }

    private void OnSuccessPurchase(string id)
    {
        if(_id == id)
            Destroy(gameObject);
    }
}
