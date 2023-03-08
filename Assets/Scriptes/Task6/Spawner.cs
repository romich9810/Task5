using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : PoolEnemy
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private Coroutine _coroutine;

    private void Start()
    {
        Initialize(_enemy);

        _coroutine = StartCoroutine(SpawnEnemy());
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private IEnumerator SpawnEnemy()
    {
        WaitForSeconds waitingSeconds =  new WaitForSeconds(_secondsBetweenSpawn);

        for (int i = 0; i < Capacity; i++)
        {
            if (TryGetEnemy(out GameObject enemy))
            {
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }

            yield return waitingSeconds;
        }
    }
}
