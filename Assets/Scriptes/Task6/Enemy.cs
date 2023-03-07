using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    private Coroutine corotune;
    private FirstPersonController _player;

    private void Start()
    {
        _player = FindObjectOfType<FirstPersonController>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speedMove * Time.deltaTime);
        transform.LookAt(_player.transform);
    }
}
