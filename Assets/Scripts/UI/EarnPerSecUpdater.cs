using UnityEngine;
using TMPro;

public class EarnPerSecUpdater : MonoBehaviour
{
    [SerializeField] private MoneyEarner _earner;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        _text.text = $"${_earner.CurrentEarnPerSecond * _earner.CurrentMultiplier}/sec";
    }

    private void OnEnable()
    {
        _earner.LevelIncreased += OnLevelIncreased;
        _earner.MultiplierChanged += OnMultiplierChanged;
    }

    private void OnDisable()
    {
        _earner.LevelIncreased -= OnLevelIncreased;
        _earner.MultiplierChanged -= OnMultiplierChanged;
    }

    private void OnLevelIncreased()
    {
        _text.text = $"${_earner.CurrentEarnPerSecond * _earner.CurrentMultiplier}/sec";
    }

    private void OnMultiplierChanged()
    {
        _text.text = $"${_earner.CurrentEarnPerSecond * _earner.CurrentMultiplier}/sec";
    }
}
