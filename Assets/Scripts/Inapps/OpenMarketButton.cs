using UnityEngine;
using UnityEngine.UI;

public class OpenMarketButton : MonoBehaviour
{
    [SerializeField] private CanvasGroup _marketPanel;

    private bool _isOpen = false;
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

    private void Start()
    {
        if (_isOpen)
        {
            OpenMarket();
        }
        else
        {
            CloseMarket();
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
        _marketPanel.alpha = 1;
        _marketPanel.interactable = true;
        _marketPanel.blocksRaycasts = true;
    }

    private void CloseMarket()
    {
        _marketPanel.alpha = 0;
        _marketPanel.interactable = false;
        _marketPanel.blocksRaycasts = false;
    }

}
