using UnityEngine;
using TMPro;

public class MoneyReceiver : MonoBehaviour
{
    [SerializeField] private MoneyEarner _moneyEarner;
    [SerializeField] private TMP_Text _moneyText;

    private int _moneyCount = 0;

    private void Start()
    {
        _moneyText.text = _moneyCount.ToString();
    }

    private void OnEnable()
    {
        _moneyEarner.MoneyEarned += OnMoneyEarned;
    }

    private void OnDisable()
    {
        _moneyEarner.MoneyEarned -= OnMoneyEarned;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerWallet wallet))
        {
            wallet.AddMoney(_moneyCount);
            _moneyCount = 0;
            _moneyText.text = _moneyCount.ToString();
        }
    }

    private void OnMoneyEarned(int earnedMoney, bool hasMagnet)
    {
        if(!hasMagnet)
        {
            _moneyCount += earnedMoney;
            _moneyText.text = _moneyCount.ToString();
        }
    }
}
