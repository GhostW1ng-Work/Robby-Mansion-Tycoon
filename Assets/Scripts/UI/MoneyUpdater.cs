using UnityEngine;
using TMPro;

public class MoneyUpdater : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _wallet.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _wallet.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _text.text = money.ToString();
    }
}
