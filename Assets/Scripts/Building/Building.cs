using System.Collections;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private int _buildMoney;
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;
    [SerializeField] private bool _isInteractable = false;
    [SerializeField] private Collider[] _colliders;

    public Vector3 TargetScale { get; private set; }
     
    public Vector3 Position => _position;
    public Quaternion Rotation => _rotation;
    public bool IsInteractable => _isInteractable;
    public int BuildMoney => _buildMoney;

    private void Awake()
    {
        TargetScale = transform.localScale;
    }

    private void OnEnable()
    {
        StartCoroutine(WaitBeforeEnableCollision());
    }

    private IEnumerator WaitBeforeEnableCollision()
    {
        foreach (var collider in _colliders)
        {
            collider.enabled = false;
        }
        yield return new WaitForSeconds(1);
        foreach (var collider in _colliders)
        {
            collider.enabled = true;
        }
    }
}
