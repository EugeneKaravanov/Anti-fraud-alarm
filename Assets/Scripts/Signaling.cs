using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _changeVolumeSpeed = 0.05f;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void UpSignalingVolume()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void DownSignalingVolume()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume) 
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _changeVolumeSpeed * Time.deltaTime);
            yield return null;
        }

        yield break;
    }
}
