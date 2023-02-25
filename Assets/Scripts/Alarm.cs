using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    public static UnityAction AlarmAction;
    public static UnityAction AlarmStop;

    private AudioSource _audioSource;
    private Coroutine _changeVolumeCoroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
        AlarmAction += StartAudio;
        AlarmStop += StopAudio;
    }

    public void StartAudio()
    {
        _audioSource.Play();

        if (_changeVolumeCoroutine != null)
        {
            StopCoroutine(_changeVolumeCoroutine);
            _changeVolumeCoroutine = StartCoroutine(ChangeVolume(1));
        }
        else
        {
            _changeVolumeCoroutine = StartCoroutine(ChangeVolume(1));
        }
    }

    public void StopAudio()
    {
        if(_changeVolumeCoroutine != null)
        {
            StopCoroutine(_changeVolumeCoroutine);
            _changeVolumeCoroutine = StartCoroutine(ChangeVolume(0));
        }
    }

    private IEnumerator ChangeVolume(float maxVolume)
    {
        float step = 1f;

        while (true)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, maxVolume, step * Time.deltaTime);
            yield return null;
        }
    }

}
