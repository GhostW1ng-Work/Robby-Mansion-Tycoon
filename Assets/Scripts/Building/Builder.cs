using UnityEngine;
using System;

public class Builder : MonoBehaviour
{
    [SerializeField] private Building _building;
    [SerializeField] private int _price;

    public static event Action BuildCreated;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerWallet wallet))
        {
            if(wallet.CurrentMoney >= _price)
            {
                BuildCreated?.Invoke();
                wallet.SpendMoney(_price);
                Instantiate(_building, _building.Position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
