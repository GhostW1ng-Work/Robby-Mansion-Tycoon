using UnityEngine;

public class Bed : Interactable
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Quaternion _playerRotation;

    private bool _isInteracted;

    public override void Interact()
    {
        Player.transform.position = _playerPosition.position;
        Player.transform.rotation = _playerRotation;
    }
}
