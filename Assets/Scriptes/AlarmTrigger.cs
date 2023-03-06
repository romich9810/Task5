using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _MovedInTrigger;
    [SerializeField] private UnityEvent _MovedOutTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FirstPersonController firstPersonController))
            _MovedInTrigger?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out FirstPersonController firstPersonController))
            _MovedOutTrigger?.Invoke();
    }
}
