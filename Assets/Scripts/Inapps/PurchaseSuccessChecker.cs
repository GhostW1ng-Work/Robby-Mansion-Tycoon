using UnityEngine;
using YG;

public class PurchaseSuccessChecker : MonoBehaviour
{
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
            case "test":
                Debug.Log(id);
                break;
        }
    }
}
