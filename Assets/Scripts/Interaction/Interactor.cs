using UnityEngine;
using UnityEngine.UI;
using YG;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private CanvasGroup _button;
    [SerializeField] private InteractButton _interactButton;

    public Interactable Target { get; private set; }

    private void Start()
    {
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
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactable.Interact();
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
        }

        if(Target != null)
        {
            if(Vector3.Distance(transform.position, Target.transform.position) > _range)
            {
                if (YandexGame.EnvironmentData.isMobile)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        _button.alpha = 0;
                        _button.interactable = false;
                        _button.blocksRaycasts = false;
                        _interactButton.SetTarget(null);
                    }
                }
                Target = null;
            }
        }
    }
}
