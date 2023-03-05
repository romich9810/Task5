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

    private Coroutine _corotune;

    public void OnAlarm()
    {
        if (_corotune != null)
            StopCoroutine(_corotune);

        _audioSourse.Play();
        _corotune = StartCoroutine(SwitchAlarm(_maxVolume));
    }

    public void OffAlarm()
    {
        if (_corotune != null)
            StopCoroutine(_corotune);

        _corotune = StartCoroutine(SwitchAlarm(_minVolume));
    }

    private IEnumerator SwitchAlarm(float valueNoise)
    {
        while(_audioSourse.volume != valueNoise)
        {
            _audioSourse.volume = Mathf.MoveTowards(_audioSourse.volume, valueNoise, _speedExhangeVolume);

            if (_audioSourse.volume == _maxVolume)
                _ricardos.SetActive(true);

            if (_audioSourse.volume == _minVolume)
            {
                _ricardos.SetActive(false);
                _audioSourse.Pause();
            }

            yield return null; 
        }
    }
}
