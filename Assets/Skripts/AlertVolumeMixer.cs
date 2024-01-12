using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlertVolumeMixer : MonoBehaviour
{
    [SerializeField] float _speed;

    private float _currentVolume;
    private float _targetVolume;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        bool isChangingVolume = true;

        while (isChangingVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _targetVolume, _speed * Time.deltaTime);
            _audioSource.volume = _currentVolume;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<StealerMover>())
            _targetVolume = _maxVolume;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<StealerMover>())
            _targetVolume = _minVolume;
    }
}
