using UnityEngine;
using YG.Utils.Pay;
using YG;
using UnityEngine.UI;

public class PurchaseSkin : MonoBehaviour
{
    [SerializeField] private string _id;
    [SerializeField] private int _price;
    [SerializeField] private Material _material;
    [SerializeField] private SkinnedMeshRenderer[] _renderer;

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
        foreach (var renderer in _renderer)
        {
            renderer.material = _material;
        }
    }
}
