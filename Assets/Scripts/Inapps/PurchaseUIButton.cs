using UnityEngine;
using YG.Utils.Pay;
using YG;
using UnityEngine.UI;

public class PurchaseUIButton : MonoBehaviour
{
    [SerializeField] private string _id;

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

    private void OnClick()
    {
        Purchase purchase = YandexGame.PurchaseByID(_id);
        YandexGame.BuyPayments(purchase.id);
    }
}
