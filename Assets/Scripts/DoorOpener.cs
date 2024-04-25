using UnityEngine;
using DG.Tweening;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private DoorOpener _secondOpener;
    [SerializeField] private AudioClip _sound;
    [SerializeField] private Transform _door;
    [SerializeField] private float _duration;
    [SerializeField] private Quaternion _rotation;

    private Quaternion _startRotation;

    public bool IsOpened{ get; private set; }

    private void Start()
    {
        _startRotation = transform.localRotation;
        IsOpened = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet player) && !_secondOpener.IsOpened)
        {
            IsOpened = true;
            AudioSource.PlayClipAtPoint(_sound, transform.position);
            _door.DOLocalRotateQuaternion(_rotation, _duration);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet player))
        {
            IsOpened = false;
            AudioSource.PlayClipAtPoint(_sound, transform.position);
            _door.DOLocalRotateQuaternion(_startRotation, _duration);
        }
    }
}
