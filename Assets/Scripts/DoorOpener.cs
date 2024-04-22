using UnityEngine;
using DG.Tweening;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private Transform _door;
    [SerializeField] private float _duration;
    [SerializeField] private Quaternion _rotation;

    private Quaternion _startRotation;

    private void Start()
    {
        _startRotation = transform.localRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet player))
        {
            AudioSource.PlayClipAtPoint(_sound, transform.position);
            _door.DOLocalRotateQuaternion(_rotation, _duration);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerWallet player))
        {
            AudioSource.PlayClipAtPoint(_sound, transform.position);
            _door.DOLocalRotateQuaternion(_startRotation, _duration);
        }
    }
}
