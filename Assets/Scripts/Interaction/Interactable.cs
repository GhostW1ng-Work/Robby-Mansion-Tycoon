using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected bool _changePosition = false;
    protected PlayerWallet Player;

    public bool ChangePosition => _changePosition;
    public virtual void Interact()
    {

    }

    public void Initialize(PlayerWallet player)
    {
        Player = player;
    }
}
