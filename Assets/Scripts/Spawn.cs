using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _pointSpawn;
    [SerializeField] private float _timeSpawn;

    private void Start()
    {
        _pointSpawn.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(_timeSpawn);
        Instantiate(_enemy, _pointSpawn.transform.position, transform.rotation);

        StartCoroutine(SpawnEnemies());
    }
}
