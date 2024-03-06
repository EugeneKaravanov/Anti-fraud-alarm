using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AlarmTrigger))]
public class Signaling : MonoBehaviour
{
    private AudioSource _audioSource;
    private AlarmTrigger _alarmTrigger;
    private float _changeVolumeSpeed = 0.05f;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _alarmTrigger = GetComponent<AlarmTrigger>();
        _alarmTrigger.ThiefEntered += ActivateSignlling;
        _alarmTrigger.ThiefExited += SwitchOffSignlling;
    }

    private void OnDisable()
    {
        _alarmTrigger.ThiefEntered -= ActivateSignlling;
        _alarmTrigger.ThiefExited -= SwitchOffSignlling;
    }

    private void ActivateSignlling()
    {
        StopAllCoroutines();
        StartCoroutine(UpVolume());
    }

    private void SwitchOffSignlling()
    {
        StopAllCoroutines();
        StartCoroutine(DownVolume());
    }

    private IEnumerator UpVolume()
    {
        while (_audioSource.volume < 1) 
        {
            _audioSource.volume += _changeVolumeSpeed * Time.deltaTime;
            yield return null;
        }

        yield break;
    }

    private IEnumerator DownVolume()
    {
        while (_audioSource.volume > 0)
        {
            _audioSource.volume -= _changeVolumeSpeed * Time.deltaTime;
            yield return null;
        }

        yield break;
    }
}
