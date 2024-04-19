using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketButtons : MonoBehaviour
{
    [SerializeField] private CanvasGroup _notActivePanel;
    [SerializeField] private CanvasGroup _activePanel;

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
        OpenMarket();
    }

    private void OpenMarket()
    {
        _activePanel.alpha = 1;
        _activePanel.interactable = true;
        _activePanel.blocksRaycasts = true;

        _notActivePanel.alpha = 0;
        _notActivePanel.interactable = false;
        _notActivePanel.blocksRaycasts = false;
    }

    private void CloseMarket()
    {
        _activePanel.transform.DOScale(0, 0.1f).OnComplete(Close);
    }

    public void Close()
    {
        _activePanel.alpha = 0;
        _activePanel.interactable = false;
        _activePanel.blocksRaycasts = false;
    }
}
