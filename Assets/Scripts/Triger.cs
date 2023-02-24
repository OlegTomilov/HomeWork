using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triger : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _fireLeft;
    [SerializeField] private GameObject _fireRight;
    [SerializeField] private GameObject _alarmBox;
    private Alarm _alarmSound;

    private void Start()
    {
        _alarmSound = GetComponent<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _door.SetActive(true);
        _fireLeft.SetActive(true);
        _fireRight.SetActive(true);
        _alarmBox.SetActive(true);
        Alarm.AlarmAction.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _door.SetActive(false);
        _fireLeft.SetActive(false);
        _fireRight.SetActive(false);
        _alarmBox.SetActive(false);
        Alarm.AlarmStop.Invoke();
    }
}
