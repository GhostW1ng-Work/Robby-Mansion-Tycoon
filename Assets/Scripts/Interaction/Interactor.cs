using Cinemachine;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using YG;

public class Interactor : MonoBehaviour
{
    [SerializeField] private StarterAssets.ThirdPersonController _personController;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private TMP_Text _interactionText;
    [SerializeField] private CinemachineBrain _brains;
    [SerializeField] private float _range;
    [SerializeField] private CanvasGroup _button;
    [SerializeField] private InteractButton _interactButton;

    private float _interactHeight = 0f;

    public Interactable Target { get; private set; }

    public static event Action TargetLost;

    private void Start()
    {
        _interactionText.alpha = 0;
        _button.alpha = 0;
        _button.interactable = false;
        _button.blocksRaycasts = false;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, _range))
        {
            if (hit.collider.TryGetComponent(out Interactable interactable))
            {
                Target = interactable;
                if (YandexGame.EnvironmentData.isDesktop)
                {
                    _interactionText.alpha = 1;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactable.Interact();
                        if (interactable.ChangePosition)
                        {
                            _characterController.height = _interactHeight;
                            _brains.enabled = false;
                            _personController.enabled = false;
                            StartCoroutine(WaitBeforeEnable());
                        }
                    }
                }
                else
                {
                    _interactButton.SetTarget(Target);
                    _button.alpha = 1;
                    _button.interactable = true;
                    _button.blocksRaycasts = true;
                }
            }
            else
            {
                if (YandexGame.EnvironmentData.isMobile)
                {
                    _button.alpha = 0;
                    _button.interactable = false;
                    _button.blocksRaycasts = false;
                    _interactButton.SetTarget(null);

                }
                else if(YandexGame.EnvironmentData.isDesktop)
                {
                    _interactionText.alpha = 0;
                }
                Target = null;
                TargetLost?.Invoke();

            }
        }
    }

    private IEnumerator WaitBeforeEnable()
    {
        yield return new WaitForSeconds(0.1f);
        _brains.enabled = !_brains.enabled;
        _personController.enabled = !_personController.enabled;
    }
}
