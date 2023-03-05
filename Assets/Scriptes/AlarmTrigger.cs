using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        _alarm.OnAlarm();
    }

    private void OnTriggerExit(Collider other)
    {
        _alarm.OffAlarm();
    }
}
