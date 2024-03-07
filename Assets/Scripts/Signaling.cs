using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _changeVolumeSpeed = 0.05f;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private Coroutine _currentCoroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void UpSignalingVolume()
    {
        OffCurrentCoroutine();
        _currentCoroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void DownSignalingVolume()
    {
        OffCurrentCoroutine();
        _currentCoroutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        _audioSource.mute = false;

        while (_audioSource.volume != targetVolume) 
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _changeVolumeSpeed * Time.deltaTime);
            yield return null;
        }

        if(_audioSource.volume == 0)
            _audioSource.mute = true;

        yield break;
    }

    private void OffCurrentCoroutine()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
    }
}
