using UnityEngine;
using YG;
using YG.Utils.Pay;

public class PurchaseButton : MonoBehaviour
{
    [SerializeField] private string _id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet player))
        {
            Purchase purchase = YandexGame.PurchaseByID(_id);
            YandexGame.BuyPayments(purchase.id);
        }
    }
}
