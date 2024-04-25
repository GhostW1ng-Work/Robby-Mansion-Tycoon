using UnityEngine;
using YG.Utils.Pay;
using YG;
using UnityEngine.UI;
using GameAnalyticsSDK;
using TMPro;

public class PurchaseUIButton : MonoBehaviour
{
    [SerializeField] private string _id;
    [SerializeField] private TMP_Text _yanText;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void Start()
    {
        Purchase purchase =  YandexGame.PurchaseByID(_id);
        _yanText.text = purchase.priceValue;
    }

    private void OnClick()
    {
        Purchase purchase = YandexGame.PurchaseByID(_id);
        YandexGame.BuyPayments(purchase.id);
        GameAnalytics.NewDesignEvent("Click to " + purchase.id);
    }
}
