using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Alarm))]

public class Triger : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _fireLeft;
    [SerializeField] private GameObject _fireRight;
    [SerializeField] private GameObject _alarmBox;

    public static event UnityAction StartedSound;
    public static event UnityAction StopedSound;

    private Alarm _alarmSound;

    private void Start()
    {
        _alarmSound = GetComponent<Alarm>();
        StartedSound += _alarmSound.StartAudio;
        StopedSound += _alarmSound.StopAudio;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _door.SetActive(true);
        _fireLeft.SetActive(true);
        _fireRight.SetActive(true);
        _alarmBox.SetActive(true);
        StartedSound.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _door.SetActive(false);
        _fireLeft.SetActive(false);
        _fireRight.SetActive(false);
        _alarmBox.SetActive(false);
        StopedSound.Invoke();
    }
}
