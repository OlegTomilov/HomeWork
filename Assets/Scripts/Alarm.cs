using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarmEvent;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    public void StartAudio(int inversion)
    {
        _alarmEvent.Invoke();
        StartCoroutine(ChangeVolume(inversion));
    }

    private IEnumerator ChangeVolume(int inversion, float duration = 1000f)
    {
        var volume = _audioSource.volume;

        for (int i = 0; i < duration; i++)
        {
            volume += Time.deltaTime * inversion;
            _audioSource.volume = volume;
            yield return null;
        }

        StopCoroutine(ChangeVolume(0));
    }
}
