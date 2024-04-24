using UnityEngine;

public class TV : Interactable
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private MeshRenderer _screen;
    [SerializeField] private Material _enableMaterial;
    [SerializeField] private Material _disableMaterial;

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
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
            _screen.material = _disableMaterial;
        }
    }
}
