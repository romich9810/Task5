using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    public int Capacity
    {
        get { return _capacity; }
    }

    protected void Initialize(GameObject enemy)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(enemy, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetEnemy(out GameObject enemy) 
    {
        enemy = _pool.FirstOrDefault(p => p.active == false);
        enemy.SetActive(true);

        return enemy != null;
    }
}
