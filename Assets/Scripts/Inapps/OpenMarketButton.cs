using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class OpenMarketButton : MonoBehaviour
{
    [SerializeField] private CanvasGroup _marketPanel;

    private bool _isOpen = false;
    private Button _button;

    public event Action MarketOpened;
    public event Action MarketClosed;

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
        if (_isOpen)
        {
            OpenMarket();
        }
        else
        {
            Close();
        }
    }

    private void OnClick()
    {
        if (_isOpen)
        {
            _isOpen = false;
            CloseMarket();
        }
        else
        {
            _isOpen = true;
            OpenMarket();
        }
    }

    private void OpenMarket()
    {
        MarketOpened?.Invoke();
        _marketPanel.transform.DOScale(1, 0.1f);
        _marketPanel.alpha = 1;
        _marketPanel.interactable = true;
        _marketPanel.blocksRaycasts = true;
    }

    private void CloseMarket()
    {
        _marketPanel.transform.DOScale(0, 0.1f).OnComplete(Close);
    }

    private void Close()
    {
        MarketClosed?.Invoke();
        _marketPanel.alpha = 0;
        _marketPanel.interactable = false;
        _marketPanel.blocksRaycasts = false;
    }
}
