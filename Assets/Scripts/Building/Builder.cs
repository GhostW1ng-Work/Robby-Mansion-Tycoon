using UnityEngine;
using System;
using YG;

public class Builder : MonoBehaviour
{
    [SerializeField] private Building[] _buildings;
    [SerializeField] private Vector3[] _nextBuilderPositions;
    [SerializeField] private int _price;

    public static event Action BuildCreated;

    private void Start()
    {
        if(YandexGame.savesData.firstRoomLevel == 0)
        {
            transform.position = _nextBuilderPositions[0];
        }

        for (int i = 0; i < YandexGame.savesData.firstRoomLevel; i++)
        {
            Building building = _buildings[i];

            Instantiate(building, building.Position, Quaternion.identity);

            if(i < _nextBuilderPositions.Length - 1)
                transform.position = _nextBuilderPositions[i];
            else
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet wallet))
        {
            if (wallet.CurrentMoney >= _price)
            {
                BuildCreated?.Invoke();
                YandexGame.savesData.firstRoomLevel++;
                YandexGame.SaveProgress();
                wallet.SpendMoney(_price);
                Build(YandexGame.savesData.firstRoomLevel);
            }
        }
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
