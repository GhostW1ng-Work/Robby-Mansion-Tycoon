using UnityEngine;
using YG.Utils.Pay;
using YG;
using UnityEngine.UI;
using TMPro;
using GameAnalyticsSDK;

public enum Skins
{
    Standart,
    Robot,
    Superman
}

public class PurchaseSkin : MonoBehaviour
{
    [SerializeField] private string _id;
    [SerializeField] private Skins _skin;
    [SerializeField] private Image _yanIcon;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Material _material;
    [SerializeField] private SkinnedMeshRenderer[] _renderer;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        switch (_skin)
        {
            case Skins.Robot:
                if (YandexGame.savesData.robotSkinIsBuyed)
                {
                    Purchase purchase = YandexGame.PurchaseByID(_id);
                    _priceText.text = purchase.priceValue;

                }
                else
                {
                    switch (YandexGame.lang)
                    {
                        case "en":
                            _priceText.text = "Choose";
                            break;
                        case "ru":
                            _priceText.text = "Выбрать";
                            break;
                        case "tr":
                            _priceText.text = "Seçiniz";
                            break;
                        case "es":
                            _priceText.text = "Seleccione";
                            break;
                    }
                    Destroy(_yanIcon);
                }
                break;
            case Skins.Superman:
                if (YandexGame.savesData.supermanSkinIsBuyed)
                {
                    Purchase purchase = YandexGame.PurchaseByID(_id);
                    _priceText.text = purchase.priceValue;
                }
                else
                {
                    switch (YandexGame.lang)
                    {
                        case "en":
                            _priceText.text = "Choose";
                            break;
                        case "ru":
                            _priceText.text = "Выбрать";
                            break;
                        case "tr":
                            _priceText.text = "Seçiniz";
                            break;
                        case "es":
                            _priceText.text = "Seleccione";
                            break;
                    }
                    Destroy(_yanIcon);
                }
                break;
            default:
                switch (YandexGame.lang)
                {
                    case "en":
                        _priceText.text = "Choose";
                        break;
                    case "ru":
                        _priceText.text = "Выбрать";
                        break;
                    case "tr":
                        _priceText.text = "Seçiniz";
                        break;
                    case "es":
                        _priceText.text = "Seleccione";
                        break;
                }
                break;
        }

        if (_skin != YandexGame.savesData.skin)
            return;

        switch (YandexGame.savesData.skin)
        {
            case Skins.Standart:
                foreach (var renderer in _renderer)
                {
                    renderer.material = _material;
                }
                break;
            case Skins.Robot:
                foreach (var renderer in _renderer)
                {
                    renderer.material = _material;
                }
                break;
            case Skins.Superman:
                foreach (var renderer in _renderer)
                {
                    renderer.material = _material;
                }
                break;
        }

    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        YandexGame.PurchaseSuccessEvent += OnSuccess;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
        YandexGame.PurchaseSuccessEvent -= OnSuccess;
    }

    private void OnClick()
    {
        switch (_skin)
        {
            case Skins.Robot:
                if (YandexGame.savesData.robotSkinIsBuyed)
                {
                    foreach (var renderer in _renderer)
                    {
                        renderer.material = _material;
                        YandexGame.savesData.skin = Skins.Robot;
                        YandexGame.SaveProgress();
                    }
                }
                else
                {
                    YandexGame.BuyPayments(_id);
                    GameAnalytics.NewDesignEvent("Click to " + _id);
                }
                break;
            case Skins.Superman:
                if (YandexGame.savesData.supermanSkinIsBuyed)
                {
                    foreach (var renderer in _renderer)
                    {
                        renderer.material = _material;
                        YandexGame.savesData.skin = Skins.Superman;
                        YandexGame.SaveProgress();
                    }
                }
                else
                {
                    YandexGame.BuyPayments(_id);
                    GameAnalytics.NewDesignEvent("Click to " + _id);
                }
                break;
            default:
                foreach (var renderer in _renderer)
                {
                    renderer.material = _material;
                    YandexGame.savesData.skin = Skins.Standart;
                    YandexGame.SaveProgress();
                }
                break;
        }
    }

    public void OnSuccess(string id)
    {
        if (_id == id)
        {
            switch (YandexGame.lang)
            {
                case "en":
                    _priceText.text = "Choose";
                    break;
                case "ru":
                    _priceText.text = "Выбрать";
                    break;
                case "tr":
                    _priceText.text = "Seçiniz";
                    break;
                case "es":
                    _priceText.text = "Seleccione";
                    break;
            }

            Destroy(_yanIcon);
        }
    }
}
