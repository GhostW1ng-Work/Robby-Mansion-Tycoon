using UnityEngine;
using System;
using YG;
using TMPro;

public class Builder : MonoBehaviour
{
    [SerializeField] private Building[] _buildings;
    [SerializeField] private Vector3[] _nextBuilderPositions;
    [SerializeField] private CanvasGroup _market;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private int[] _price;

    public static event Action BuildCreated;

    private void Start()
    {
        _priceText.text = _price[YandexGame.savesData.buildingLevel].ToString();
        if (YandexGame.savesData.buildingLevel == 0)
        {
            transform.position = _nextBuilderPositions[0];
        }

        for (int i = 0; i < YandexGame.savesData.buildingLevel; i++)
        {
            Building building = _buildings[i];

            Instantiate(building, building.Position, Quaternion.identity);

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
                _market.alpha = 1;
                _market.blocksRaycasts = true;
                _market.interactable = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _market.alpha = 0;
        _market.blocksRaycasts = false;
        _market.interactable = false;
    }

    private void Build(int index)
    {
        Building building = _buildings[index - 1];

        Instantiate(building, building.Position, Quaternion.identity);
        if (index < _nextBuilderPositions.Length)
            transform.position = _nextBuilderPositions[index];
        else
            Destroy(gameObject);

    }
}
