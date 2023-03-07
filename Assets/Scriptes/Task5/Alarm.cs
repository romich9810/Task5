using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourse;
    [SerializeField] private GameObject _ricardos;

    private float _maxVolume = 1f;
    private float _minVolume = 0;
    private float _speedExhangeVolume = 0.01f;

    private bool _isObjectInTrigger = false;

    private Coroutine _corotune;

    public void SetAlarm()
    {
        _isObjectInTrigger = !_isObjectInTrigger;

        if (_corotune != null)
            StopCoroutine(_corotune);

        if (_isObjectInTrigger)
        {
            _audioSourse.Play();
            StartSwitchAlarm(_maxVolume);

            return;
        }

        StartSwitchAlarm(_minVolume);
    }

    private void StartSwitchAlarm(float value)
    {
        _corotune = StartCoroutine(SwitchAlarm(value));
    }

    private IEnumerator SwitchAlarm(float valueNoise)
    {
        while(_audioSourse.volume != valueNoise)
        {
            _audioSourse.volume = Mathf.MoveTowards(_audioSourse.volume, valueNoise, _speedExhangeVolume);

            yield return null; 
        }

        if (_audioSourse.volume == _maxVolume)
            _ricardos.SetActive(true);

        if (_audioSourse.volume == _minVolume)
        {
            _ricardos.SetActive(false);
            _audioSourse.Pause();
        }
    }
}
