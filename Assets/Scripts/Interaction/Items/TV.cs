using UnityEngine;

public class TV : Interactable
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private MeshRenderer _screen;
    [SerializeField] private Material _enableMaterial;
    [SerializeField] private Material _disableMaterial;
    [SerializeField] private bool _hasSound = false;

    private bool _enabled = false;

    private void Start()
    {
        _screen.material = _disableMaterial;
    }

    public override void Interact()
    {
        _enabled = !_enabled;

        if(_enabled)
        {
            _screen.material = _enableMaterial;
            if(_hasSound)
                _audioSource.Play();
        }
        else
        {
            _screen.material = _disableMaterial;
            if (_hasSound)
                _audioSource.Stop();
        }
    }
}
