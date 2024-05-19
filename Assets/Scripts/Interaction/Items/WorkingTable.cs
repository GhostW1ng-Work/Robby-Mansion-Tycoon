using UnityEngine;

public class WorkingTable : Interactable
{
    [SerializeField] private int _moneyCount = 30;
    private WorkingTablePanel _panel;
    private bool _isActive = false;

    private void OnEnable()
    {
        _panel = FindObjectOfType<WorkingTablePanel>();
        Interactor.TargetLost += OnTargetLost;

    }

    private void OnDisable()
    {
        Interactor.TargetLost -= OnTargetLost;
    }

    private void OnTargetLost()
    {
        _panel.DisableCanvas();
        _isActive = false;
    }

    public override void Interact()
    {
        if (_isActive)
        {
            _isActive = false;
            _panel.DisableCanvas();
        }
        else
        {
            _isActive = true;
            _panel.EnableCanvas();
        }
    }

    private void Update()
    {
        if(_isActive && Input.GetMouseButtonDown(0)) 
        {
            Player.AddMoney(_moneyCount);
        }
    }
}
