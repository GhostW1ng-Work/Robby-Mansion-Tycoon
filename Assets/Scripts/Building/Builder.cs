using UnityEngine;
using System;
using YG;
using TMPro;
using DG.Tweening;
using GameAnalyticsSDK;
using System.Globalization;

public enum Rooms
{
    LivingRoom,
    Bedroom,
    Arcade,
    Music,
    Library,
    GYM,
    Bathroom,
    Kitchen
}

public class Builder : MonoBehaviour
{
    [SerializeField] private PlayerWallet _player;
    [SerializeField] private Rooms _room;
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
        switch (_room)
        {
            case Rooms.LivingRoom:
                if (YandexGame.savesData.livingRoomLevel < _price.Length)
                {
                    if ((decimal)_price[YandexGame.savesData.livingRoomLevel] >= 100000)
                        _priceText.text = "$" + _price[YandexGame.savesData.livingRoomLevel].ToString("#,#", CultureInfo.InvariantCulture);
                    else
                        _priceText.text = "$" + _price[YandexGame.savesData.livingRoomLevel].ToString();

                }
  


                if (YandexGame.savesData.livingRoomLevel == 0)
                {
                    transform.position = _nextBuilderPositions[0];
                }

                for (int i = 0; i < YandexGame.savesData.livingRoomLevel; i++)
                {
                    Building building = _buildings[i];

                    Building creation = Instantiate(building, building.Position, building.Rotation);
                    if (creation.IsInteractable)
                    {
                        Interactable interactable = creation.GetComponent<Interactable>();

                        interactable.Initialize(_player);
                    }

                    if (i < _nextBuilderPositions.Length - 1)
                    {

                        transform.position = _nextBuilderPositions[i + 1];
                    }
                    else
                    {

                        Destroy(gameObject);
                    }
                }
                break;
            case Rooms.Bedroom:
                if (YandexGame.savesData.bedroomLevel < _price.Length)
                {
                    if ((decimal)_price[YandexGame.savesData.bedroomLevel] >= 100000)
                        _priceText.text = "$" + _price[YandexGame.savesData.bedroomLevel].ToString("#,#", CultureInfo.InvariantCulture);
                    else
                        _priceText.text = "$" + _price[YandexGame.savesData.bedroomLevel].ToString();

                }

                if (YandexGame.savesData.bedroomLevel == 0)
                {
                    transform.position = _nextBuilderPositions[0];
                }

                for (int i = 0; i < YandexGame.savesData.bedroomLevel; i++)
                {
                    Building building = _buildings[i];

                    Building creation = Instantiate(building, building.Position, building.Rotation);
                    if (creation.IsInteractable)
                    {
                        Interactable interactable = creation.GetComponent<Interactable>();

                        interactable.Initialize(_player);
                    }

                    if (i < _nextBuilderPositions.Length - 1)
                    {

                        transform.position = _nextBuilderPositions[i + 1];
                    }
                    else
                    {

                        Destroy(gameObject);
                    }
                }
                break;
            case Rooms.Arcade:
                if (YandexGame.savesData.arcadeLevel < _price.Length)
                {
                    if ((decimal)_price[YandexGame.savesData.arcadeLevel] >= 100000)
                        _priceText.text = "$" + _price[YandexGame.savesData.arcadeLevel].ToString("#,#", CultureInfo.InvariantCulture);
                    else
                        _priceText.text = "$" + _price[YandexGame.savesData.arcadeLevel].ToString();

                }

                if (YandexGame.savesData.arcadeLevel == 0)
                {
                    transform.position = _nextBuilderPositions[0];
                }

                for (int i = 0; i < YandexGame.savesData.arcadeLevel; i++)
                {
                    Building building = _buildings[i];

                    Building creation = Instantiate(building, building.Position, building.Rotation);
                    if (creation.IsInteractable)
                    {
                        Interactable interactable = creation.GetComponent<Interactable>();

                        interactable.Initialize(_player);
                    }

                    if (i < _nextBuilderPositions.Length - 1)
                    {

                        transform.position = _nextBuilderPositions[i + 1];
                    }
                    else
                    {

                        Destroy(gameObject);
                    }
                }
                break;
            case Rooms.Music:
                if (YandexGame.savesData.musicLevel < _price.Length)
                {
                    if ((decimal)_price[YandexGame.savesData.musicLevel] >= 100000)
                        _priceText.text = "$" + _price[YandexGame.savesData.musicLevel].ToString("#,#", CultureInfo.InvariantCulture);
                    else
                        _priceText.text = "$" + _price[YandexGame.savesData.musicLevel].ToString();

                }

                if (YandexGame.savesData.musicLevel == 0)
                {
                    transform.position = _nextBuilderPositions[0];
                }

                for (int i = 0; i < YandexGame.savesData.musicLevel; i++)
                {
                    Building building = _buildings[i];

                    Building creation = Instantiate(building, building.Position, building.Rotation);
                    if (creation.IsInteractable)
                    {
                        Interactable interactable = creation.GetComponent<Interactable>();

                        interactable.Initialize(_player);
                    }

                    if (i < _nextBuilderPositions.Length - 1)
                    {

                        transform.position = _nextBuilderPositions[i + 1];
                    }
                    else
                    {

                        Destroy(gameObject);
                    }
                }
                break;
            case Rooms.Library:
                if (YandexGame.savesData.libraryLevel < _price.Length)
                {
                    if ((decimal)_price[YandexGame.savesData.libraryLevel] >= 100000)
                        _priceText.text = "$" + _price[YandexGame.savesData.libraryLevel].ToString("#,#", CultureInfo.InvariantCulture);
                    else
                        _priceText.text = "$" + _price[YandexGame.savesData.libraryLevel].ToString();

                }

                if (YandexGame.savesData.libraryLevel == 0)
                {
                    transform.position = _nextBuilderPositions[0];
                }

                for (int i = 0; i < YandexGame.savesData.libraryLevel; i++)
                {
                    Building building = _buildings[i];

                    Building creation = Instantiate(building, building.Position, building.Rotation);
                    if (creation.IsInteractable)
                    {
                        Interactable interactable = creation.GetComponent<Interactable>();

                        interactable.Initialize(_player);
                    }

                    if (i < _nextBuilderPositions.Length - 1)
                    {

                        transform.position = _nextBuilderPositions[i + 1];
                    }
                    else
                    {

                        Destroy(gameObject);
                    }
                }
                break;
            case Rooms.Bathroom:
                if (YandexGame.savesData.bathroomLevel < _price.Length)
                {
                    if ((decimal)_price[YandexGame.savesData.bathroomLevel] >= 100000)
                        _priceText.text = "$" + _price[YandexGame.savesData.bathroomLevel].ToString("#,#", CultureInfo.InvariantCulture);
                    else
                        _priceText.text = "$" + _price[YandexGame.savesData.bathroomLevel].ToString();

                }

                if (YandexGame.savesData.bathroomLevel == 0)
                {
                    transform.position = _nextBuilderPositions[0];
                }

                for (int i = 0; i < YandexGame.savesData.bathroomLevel; i++)
                {
                    Building building = _buildings[i];

                    Building creation = Instantiate(building, building.Position, building.Rotation);
                    if (creation.IsInteractable)
                    {
                        Interactable interactable = creation.GetComponent<Interactable>();

                        interactable.Initialize(_player);
                    }

                    if (i < _nextBuilderPositions.Length - 1)
                    {

                        transform.position = _nextBuilderPositions[i + 1];
                    }
                    else
                    {

                        Destroy(gameObject);
                    }
                }
                break;
            case Rooms.GYM:
                if (YandexGame.savesData.gymLevel < _price.Length)
                {
                    if ((decimal)_price[YandexGame.savesData.gymLevel] >= 100000)
                        _priceText.text = "$" + _price[YandexGame.savesData.gymLevel].ToString("#,#", CultureInfo.InvariantCulture);
                    else
                        _priceText.text = "$" + _price[YandexGame.savesData.gymLevel].ToString();

                }

                if (YandexGame.savesData.gymLevel == 0)
                {
                    transform.position = _nextBuilderPositions[0];
                }

                for (int i = 0; i < YandexGame.savesData.gymLevel; i++)
                {
                    Building building = _buildings[i];

                    Building creation = Instantiate(building, building.Position, building.Rotation);
                    if (creation.IsInteractable)
                    {
                        Interactable interactable = creation.GetComponent<Interactable>();

                        interactable.Initialize(_player);
                    }

                    if (i < _nextBuilderPositions.Length - 1)
                    {

                        transform.position = _nextBuilderPositions[i + 1];
                    }
                    else
                    {

                        Destroy(gameObject);
                    }
                }
                break;
            case Rooms.Kitchen:
                if (YandexGame.savesData.kitchenLevel < _price.Length)
                {
                    if ((decimal)_price[YandexGame.savesData.kitchenLevel] >= 100000)
                        _priceText.text = "$" + _price[YandexGame.savesData.kitchenLevel].ToString("#,#", CultureInfo.InvariantCulture);
                    else
                        _priceText.text = "$" + _price[YandexGame.savesData.kitchenLevel].ToString();

                }

                if (YandexGame.savesData.kitchenLevel == 0)
                {
                    transform.position = _nextBuilderPositions[0];
                }

                for (int i = 0; i < YandexGame.savesData.kitchenLevel; i++)
                {
                    Building building = _buildings[i];

                    Building creation = Instantiate(building, building.Position, building.Rotation);
                    if (creation.IsInteractable)
                    {
                        Interactable interactable = creation.GetComponent<Interactable>();

                        interactable.Initialize(_player);
                    }

                    if (i < _nextBuilderPositions.Length - 1)
                    {

                        transform.position = _nextBuilderPositions[i + 1];
                    }
                    else
                    {

                        Destroy(gameObject);
                    }
                }
                break;

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet wallet))
        {
            switch (_room)
            {
                case Rooms.LivingRoom:
                    if (wallet.CurrentMoney >= _price[YandexGame.savesData.livingRoomLevel])
                    {
                        Instantiate(_effect, transform.position, Quaternion.identity);
                        BuildCreated?.Invoke();
                        YandexGame.savesData.livingRoomLevel++;
                        YandexGame.SaveProgress();
                        Build(YandexGame.savesData.livingRoomLevel);
                        if (YandexGame.savesData.livingRoomLevel < _price.Length)
                        {
                            if ((decimal)_price[YandexGame.savesData.livingRoomLevel] >= 100000)
                                _priceText.text = "$" + _price[YandexGame.savesData.livingRoomLevel].ToString("#,#", CultureInfo.InvariantCulture);
                            else
                                _priceText.text = "$" + _price[YandexGame.savesData.livingRoomLevel].ToString();

                        }
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
                    break;
                case Rooms.Arcade:
                    if (wallet.CurrentMoney >= _price[YandexGame.savesData.arcadeLevel])
                    {
                        Instantiate(_effect, transform.position, Quaternion.identity);
                        BuildCreated?.Invoke();
                        YandexGame.savesData.arcadeLevel++;
                        YandexGame.SaveProgress();
                        Build(YandexGame.savesData.arcadeLevel);
                        if (YandexGame.savesData.arcadeLevel < _price.Length)
                        {
                            if ((decimal)_price[YandexGame.savesData.arcadeLevel] >= 100000)
                                _priceText.text = "$" + _price[YandexGame.savesData.arcadeLevel].ToString("#,#", CultureInfo.InvariantCulture);
                            else
                                _priceText.text = "$" + _price[YandexGame.savesData.arcadeLevel].ToString();

                        }
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
                    break;
                case Rooms.Library:
                    if (wallet.CurrentMoney >= _price[YandexGame.savesData.libraryLevel])
                    {
                        Instantiate(_effect, transform.position, Quaternion.identity);
                        BuildCreated?.Invoke();
                        YandexGame.savesData.libraryLevel++;
                        YandexGame.SaveProgress();
                        Build(YandexGame.savesData.libraryLevel);
                        if (YandexGame.savesData.libraryLevel < _price.Length)
                        {
                            if ((decimal)_price[YandexGame.savesData.libraryLevel] >= 100000)
                                _priceText.text = "$" + _price[YandexGame.savesData.libraryLevel].ToString("#,#", CultureInfo.InvariantCulture);
                            else
                                _priceText.text = "$" + _price[YandexGame.savesData.libraryLevel].ToString();

                        }
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
                    break;
                case Rooms.Music:
                    if (wallet.CurrentMoney >= _price[YandexGame.savesData.musicLevel])
                    {
                        Instantiate(_effect, transform.position, Quaternion.identity);
                        BuildCreated?.Invoke();
                        YandexGame.savesData.musicLevel++;
                        YandexGame.SaveProgress();
                        Build(YandexGame.savesData.musicLevel);
                        if (YandexGame.savesData.musicLevel < _price.Length)
                        {
                            if ((decimal)_price[YandexGame.savesData.musicLevel] >= 100000)
                                _priceText.text = "$" + _price[YandexGame.savesData.musicLevel].ToString("#,#", CultureInfo.InvariantCulture);
                            else
                                _priceText.text = "$" + _price[YandexGame.savesData.musicLevel].ToString();

                        }
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
                    break;
                case Rooms.GYM:
                    if (wallet.CurrentMoney >= _price[YandexGame.savesData.gymLevel])
                    {
                        Instantiate(_effect, transform.position, Quaternion.identity);
                        BuildCreated?.Invoke();
                        YandexGame.savesData.gymLevel++;
                        YandexGame.SaveProgress();
                        Build(YandexGame.savesData.gymLevel);
                        if (YandexGame.savesData.gymLevel < _price.Length)
                        {
                            if ((decimal)_price[YandexGame.savesData.gymLevel] >= 100000)
                                _priceText.text = "$" + _price[YandexGame.savesData.gymLevel].ToString("#,#", CultureInfo.InvariantCulture);
                            else
                                _priceText.text = "$" + _price[YandexGame.savesData.gymLevel].ToString();

                        };
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
                    break;
                case Rooms.Kitchen:
                    if (wallet.CurrentMoney >= _price[YandexGame.savesData.kitchenLevel])
                    {
                        Instantiate(_effect, transform.position, Quaternion.identity);
                        BuildCreated?.Invoke();
                        YandexGame.savesData.kitchenLevel++;
                        YandexGame.SaveProgress();
                        Build(YandexGame.savesData.kitchenLevel);
                        if (YandexGame.savesData.kitchenLevel < _price.Length)
                        {
                            if ((decimal)_price[YandexGame.savesData.kitchenLevel] >= 100000)
                                _priceText.text = "$" + _price[YandexGame.savesData.kitchenLevel].ToString("#,#", CultureInfo.InvariantCulture);
                            else
                                _priceText.text = "$" + _price[YandexGame.savesData.kitchenLevel].ToString();

                        }
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
                    break;
                case Rooms.Bathroom:
                    if (wallet.CurrentMoney >= _price[YandexGame.savesData.bathroomLevel])
                    {
                        Instantiate(_effect, transform.position, Quaternion.identity);
                        BuildCreated?.Invoke();
                        YandexGame.savesData.bathroomLevel++;
                        YandexGame.SaveProgress();
                        Build(YandexGame.savesData.bathroomLevel);
                        if (YandexGame.savesData.bathroomLevel < _price.Length)
                        {
                            if ((decimal)_price[YandexGame.savesData.bathroomLevel] >= 100000)
                                _priceText.text = "$" + _price[YandexGame.savesData.bathroomLevel].ToString("#,#", CultureInfo.InvariantCulture);
                            else
                                _priceText.text = "$" + _price[YandexGame.savesData.bathroomLevel].ToString();

                        }
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
                    break;
                case Rooms.Bedroom:
                    if (wallet.CurrentMoney >= _price[YandexGame.savesData.bedroomLevel])
                    {
                        Instantiate(_effect, transform.position, Quaternion.identity);
                        BuildCreated?.Invoke();
                        YandexGame.savesData.bedroomLevel++;
                        YandexGame.SaveProgress();
                        Build(YandexGame.savesData.bedroomLevel);
                        if (YandexGame.savesData.bedroomLevel < _price.Length)
                        {
                            if ((decimal)_price[YandexGame.savesData.bedroomLevel] >= 100000)
                                _priceText.text = "$" + _price[YandexGame.savesData.bedroomLevel].ToString("#,#", CultureInfo.InvariantCulture);
                            else
                                _priceText.text = "$" + _price[YandexGame.savesData.bedroomLevel].ToString();

                        }
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
                    break;
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
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Room " + _room.ToString() + " with index " + index.ToString() + " builded");
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
        {
            Destroy(gameObject);
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Room " + _room.ToString() + " completed");
        }
    }
}

