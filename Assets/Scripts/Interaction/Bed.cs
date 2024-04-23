using UnityEngine;

public class Bed : Interactable
{
    [SerializeField] private Quaternion _playerRotation;

    public override void Interact()
    {
        print(Player.name);
    }
}
