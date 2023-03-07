using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public Transform PlayerPositionNow { get; }

    private void Update()
    {
        PlayerPositionNow.position = transform.position;
    }
}
