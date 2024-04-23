using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected PlayerWallet Player;

    public virtual void Interact()
    {

    }

    public void Initialize(PlayerWallet player)
    {
        Player = player;
    }
}
