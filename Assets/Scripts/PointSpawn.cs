using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawn : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _pointSpawn;
    [SerializeField] private float _timeSpawn;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var timeSpawn = new WaitForSeconds(_timeSpawn);

        for (int i = 0; i < _timeSpawn; i++)
        {
            Instantiate(_enemy, _pointSpawn.transform.position, transform.rotation);
            yield return timeSpawn;
        }

        StartCoroutine(SpawnEnemies());
    }
}
