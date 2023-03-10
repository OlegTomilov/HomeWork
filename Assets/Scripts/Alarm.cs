using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _changeVolumeCoroutine;
    private int _increaseTheVolume = 1;
    private int _decreaseTheVolume = 0;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
    }

    public void StartAudio()
    {
        _audioSource.Play();
        ChangeDerectionOfVolume(_increaseTheVolume);
    }

    public void StopAudio()
    {
        ChangeDerectionOfVolume(_decreaseTheVolume);
    }

    private void ChangeDerectionOfVolume(int inversion)
    {
        if(_changeVolumeCoroutine != null)
        {
            StopCoroutine(_changeVolumeCoroutine);
        }

        _changeVolumeCoroutine = StartCoroutine(ChangeVolume(inversion));
    }

    private IEnumerator ChangeVolume(float maxVolume)
    {
        float step = 1f;

        while (_audioSource.volume != _decreaseTheVolume || _audioSource.volume != _increaseTheVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, maxVolume, step * Time.deltaTime);
            yield return null;
        }
    }
}
