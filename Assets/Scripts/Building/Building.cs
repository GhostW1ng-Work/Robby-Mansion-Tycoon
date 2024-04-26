using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;
    [SerializeField] private bool _isInteractable = false;

    public Vector3 TargetScale { get; private set; }
     
    public Vector3 Position => _position;
    public Quaternion Rotation => _rotation;
    public bool IsInteractable => _isInteractable;

    private void Awake()
    {
        TargetScale = transform.localScale;
    }
}
