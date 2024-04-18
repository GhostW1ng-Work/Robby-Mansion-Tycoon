using UnityEngine;
using TMPro;
using System.Globalization;

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
        if ((decimal)money >= 100000)
        {
            _text.text = "$" + money.ToString("#,#", CultureInfo.InvariantCulture);
        }


/*        else if (money >= 100000)
            _text.text = $"${(money / 100000):F4}";*/
        else
            _text.text = $"${(decimal)money}";
    }
}
