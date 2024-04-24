using UnityEngine;

public class Sink : Interactable
{
    [SerializeField] private GameObject _water;

    private void Start()
    {
        _water.SetActive(false);
    }

    public override void Interact()
    {
        _water.SetActive(!_water.activeSelf);
    }
}
