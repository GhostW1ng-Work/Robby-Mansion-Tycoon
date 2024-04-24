using UnityEngine;
using System;
using YG;
using TMPro;
using DG.Tweening;

public class Builder : MonoBehaviour
{
    [SerializeField] private PlayerWallet _player;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private AudioClip _sound;
    [SerializeField] private AudioSource _target;
    [SerializeField] private Building[] _buildings;
    [SerializeField] private Vector3[] _nextBuilderPositions;
    [SerializeField] private CanvasGroup _market;
    [SerializeField] private CanvasGroup _activePanel;
    [SerializeField] private CanvasGroup _nonActivePanel;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private int[] _price;

    public event Action MarketOpened;
    public event Action MarketClosed;

    public static event Action BuildCreated;

    private void Start()
    {
        if(YandexGame.savesData.buildingLevel < _price.Length)
            _priceText.text = _price[YandexGame.savesData.buildingLevel].ToString();

        if (YandexGame.savesData.buildingLevel == 0)
        {
            transform.position = _nextBuilderPositions[0];
        }

        for (int i = 0; i < YandexGame.savesData.buildingLevel; i++)
        {
            Building building = _buildings[i];

            Building creation = Instantiate(building, building.Position, building.Rotation);
            if (creation.IsInteractable)
            {
                Interactable interactable = creation.GetComponent<Interactable>();

                interactable.Initialize(_player);
            }

            if(i < _nextBuilderPositions.Length - 1)
            {

                transform.position = _nextBuilderPositions[i + 1];
            }
            else
            {

                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet wallet))
        {
            if (wallet.CurrentMoney >= _price[YandexGame.savesData.buildingLevel])
            {
                Instantiate(_effect, transform.position, Quaternion.identity);
                BuildCreated?.Invoke();
                wallet.SpendMoney(_price[YandexGame.savesData.buildingLevel]);
                YandexGame.savesData.buildingLevel++;
                YandexGame.SaveProgress();
                Build(YandexGame.savesData.buildingLevel);
                if(YandexGame.savesData.buildingLevel < _price.Length)
                    _priceText.text = _price[YandexGame.savesData.buildingLevel].ToString();
            }
            else
            {
                MarketOpened?.Invoke();
                _market.transform.DOScale(1, 0.1f);
                _market.alpha = 1;
                _market.blocksRaycasts = true;
                _market.interactable = true;

                _activePanel.alpha = 1;
                _activePanel.blocksRaycasts = true;
                _activePanel.interactable = true;

                _nonActivePanel.alpha = 0;
                _nonActivePanel.blocksRaycasts = false;
                _nonActivePanel.interactable = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _market.transform.DOScale(0, 0.1f).OnComplete(Close);

    }

    private void Close()
    {
        MarketClosed?.Invoke();
        _market.alpha = 0;
        _market.blocksRaycasts = false;
        _market.interactable = false;
    }

    private void Build(int index)
    {
        _target.PlayOneShot(_sound);
        Building building = _buildings[index - 1];


        Building creation = Instantiate(building, building.Position, building.Rotation);
        if (creation.IsInteractable)
        {
            Interactable interactable = creation.GetComponent<Interactable>();

            interactable.Initialize(_player);
        }
 

        if (index < _nextBuilderPositions.Length)
            transform.position = _nextBuilderPositions[index];
        else
            Destroy(gameObject);

    }
}
