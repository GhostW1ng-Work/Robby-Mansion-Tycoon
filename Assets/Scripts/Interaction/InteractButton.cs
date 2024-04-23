using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractButton : MonoBehaviour
{
    [SerializeField] private Interactor _interactor;
    [SerializeField] private StarterAssets.ThirdPersonController _personController;
    [SerializeField] private CinemachineBrain _brains;

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
        if (_target.ChangePosition)
        {
            _brains.enabled = false;
            _personController.enabled = false;
            StartCoroutine(WaitBeforeEnable());
        }
    }

    private IEnumerator WaitBeforeEnable()
    {
        yield return new WaitForSeconds(0.1f);
        _brains.enabled = !_brains.enabled;
        _personController.enabled = !_personController.enabled;
    }

    public void SetTarget(Interactable target)
    {
        _target = target;
    }
}
