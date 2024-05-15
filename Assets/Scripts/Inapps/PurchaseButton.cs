using GameAnalyticsSDK;
using TMPro;
using UnityEngine;
using YG;
using YG.Utils.Pay;

public class PurchaseButton : MonoBehaviour
{
    [SerializeField] private string _id;
    [SerializeField] private TMP_Text _priceText;

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
        if (YandexGame.SDKEnabled)
        {
            switch (_id)
            {
                case "magnet":
                    if (YandexGame.savesData.magnetBoostBuyed)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        Purchase purchase = YandexGame.PurchaseByID(_id);
                        switch (YandexGame.lang)
                        {
                            case "ru":
                                _priceText.text = purchase.priceValue + " ян";
                                break;
                            default:
                                _priceText.text = purchase.priceValue + " yan";
                                break;
                        }
                    }
                    break;
                case "x2money":
                    if (YandexGame.savesData.doubleMoneyBoostBuyed)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        Purchase purchase = YandexGame.PurchaseByID(_id);
                        switch (YandexGame.lang)
                        {
                            case "ru":
                                _priceText.text = purchase.priceValue + " ян";
                                break;
                            default:
                                _priceText.text = purchase.priceValue + " yan";
                                break;
                        }
                    }
                    break;
                case "speedBoost":
                    if (YandexGame.savesData.speedBoostBuyed)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        Purchase purchase = YandexGame.PurchaseByID(_id);
                        switch (YandexGame.lang)
                        {
                            case "ru":
                                _priceText.text = purchase.priceValue + " ян";
                                break;
                            default:
                                _priceText.text = purchase.priceValue + " yan";
                                break;
                        }
                    }
                    break;
            }
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
        if (_id == id)
            Destroy(gameObject);
    }
}
