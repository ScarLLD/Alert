using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlertVolumeController : MonoBehaviour
{
    [SerializeField] float _speed;

    private float _currentVolume;
    private float _targetVolume;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _currentVolume = Mathf.MoveTowards(_currentVolume, _targetVolume, _speed * Time.deltaTime);
        _audioSource.volume = _currentVolume;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        _targetVolume = 1f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _targetVolume = 0f;
    }
}
