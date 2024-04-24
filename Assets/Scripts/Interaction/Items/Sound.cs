using UnityEngine;

public class Sound : Interactable
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _clips;
    [SerializeField] private bool _isRandom = true;
    [SerializeField] private bool _playOnce = true;

    private int _currentIndex = 0;
    private bool _isPlaying = false;

    private void Start()
    {
        _isPlaying = false;
    }

    public override void Interact()
    {
        if(_isRandom)
            _currentIndex = Random.Range(0, _clips.Length);
        else
        {
            if(_currentIndex < _clips.Length - 1)
                _currentIndex++;
            else
                _currentIndex = 0;
        }

        if(_playOnce)
            _audioSource.PlayOneShot(_clips[_currentIndex]);
        else
        {
            _audioSource.loop = true;
            _isPlaying = !_isPlaying;
            if (_isPlaying)
            {
                _audioSource.Stop();
            }
            else
            {
                _audioSource.clip = _clips[_currentIndex];
                _audioSource.Play();
            }
        }
    }
}
