using UnityEngine;

public class CursorShower : MonoBehaviour
{
    [SerializeField] private OpenMarketButton _openButton;
    [SerializeField] private Builder _builder;

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
            if (Cursor.lockState == CursorLockMode.None)
            {
                HideCursor();
            }
            else if(Cursor.lockState == CursorLockMode.Locked)
            {
                ShowCursor();
            }
        }
    }

    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
