using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    [SerializeField] private Interactor _interactor;

    private Button _button;
    private Interactable _target;

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
        _target.Interact();
    }

    public void SetTarget(Interactable target)
    {
        _target = target;
    }
}
