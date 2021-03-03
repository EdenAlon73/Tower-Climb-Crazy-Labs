using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpikeBallSpawner : MonoBehaviour
{
    private SpawnerParent spawnerParent;

    [SerializeField] private GameObject[] fallingObstaclePrefab;


    private void Awake()
    {
        spawnerParent = GetComponentInParent<SpawnerParent>();
    }

    IEnumerator Start()
    {

        while (spawnerParent.spawn && !spawnerParent.doISpawnOverTime)
        {
            yield return new WaitForSeconds(Random.Range(spawnerParent.minSpawnDelay, spawnerParent.maxSpawnDelay));
            if (spawnerParent.spawn)
            {
                SpwanObstacle();
            }

        }

        while (spawnerParent.spawn && spawnerParent.doISpawnOverTime)
        {
            yield return new WaitForSeconds(spawnerParent.spawnTimeDelay);
            spawnerParent.spawnTimeDelay -= spawnerParent.timeIncrement;
            if (spawnerParent.spawn)
            {
                SpwanObstacle();
            }
        }
    }

    private void SpwanObstacle()
    {
        Instantiate(fallingObstaclePrefab[Random.Range(0, fallingObstaclePrefab.Length)], transform.position, Quaternion.identity, transform);
    }


}
