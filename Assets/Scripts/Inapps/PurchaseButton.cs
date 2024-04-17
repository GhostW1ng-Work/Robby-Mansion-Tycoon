using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using YG.Utils.Pay;

public class PurchaseButton : MonoBehaviour
{
    [SerializeField] private CanvasGroup _purchase;
    public static string langPayments = "ru";

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet player))
        {
            print("�����");
            _purchase.alpha = 1;
            _purchase.blocksRaycasts = true;
            _purchase.interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("�����");
        _purchase.alpha = 0;
        _purchase.blocksRaycasts = false;
        _purchase.interactable = false;
    }
}