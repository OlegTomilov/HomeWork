using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Triger : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _fireLeft;
    [SerializeField] private GameObject _fireRight;
    [SerializeField] private GameObject _alarmBox;
    [SerializeField] private UnityEvent _alarmSound;
    [SerializeField] private AudioSource _audioSource;
    private bool isStay = false;

    private void Update()
    {
        InvokeAlarmSound();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _door.SetActive(true);
        _fireLeft.SetActive(true);
        _fireRight.SetActive(true);
        _alarmBox.SetActive(true);
        _alarmSound.Invoke();
        isStay = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _door.SetActive(false);
        _fireLeft.SetActive(false);
        _fireRight.SetActive(false);
        _alarmBox.SetActive(false);
        isStay = false;
    }

    private void InvokeAlarmSound()
    {
        if(isStay)
        {
            _audioSource.volume += Time.deltaTime;
        }
        else
        {
            _audioSource.volume -= Time.deltaTime;
        }
    }

}
