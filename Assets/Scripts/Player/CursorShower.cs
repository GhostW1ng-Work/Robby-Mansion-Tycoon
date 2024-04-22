using UnityEngine;

public class CursorShower : MonoBehaviour
{
    [SerializeField] private OpenMarketButton _openButton;
    [SerializeField] private Builder _builder;

    private bool _isLocked = false;

    private void OnEnable()
    {
        _openButton.MarketOpened += ShowCursor;
        _openButton.MarketClosed += HideCursor;

        _builder.MarketOpened += ShowCursor;
        _builder.MarketClosed += HideCursor;
    }

    private void OnDisable()
    {
        _openButton.MarketOpened -= ShowCursor;
        _openButton.MarketClosed -= HideCursor;

        _builder.MarketOpened -= ShowCursor;
        _builder.MarketClosed -= HideCursor;
    }

    private void Start()
    {
        HideCursor();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) 
        {
            if (_isLocked)
            {
                HideCursor();
            }
            else
            {
                ShowCursor();
            }
        }
    }

    private void ShowCursor()
    {
        _isLocked = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void HideCursor()
    {
        _isLocked = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
