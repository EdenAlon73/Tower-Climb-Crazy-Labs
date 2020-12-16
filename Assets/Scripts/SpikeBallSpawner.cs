using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpikeBallSpawner : MonoBehaviour
{
    private bool spawn = true;
    [SerializeField] GameObject fallingObstaclePrefab;
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private float spawnTimeDelay = 2f;
    [SerializeField] private float timeIncrement = .25f;
    [SerializeField] private bool doISpawnOverTime;



    IEnumerator Start()
    {

        while (spawn && !doISpawnOverTime)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if (spawn)
            {
                SpwanObstacle();
            }

        }

        while (spawn && doISpawnOverTime)
        {
            yield return new WaitForSeconds(spawnTimeDelay);
            spawnTimeDelay -= timeIncrement;
            if (spawn)
            {
                SpwanObstacle();
            }

        }

    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpwanObstacle()
    {
        Instantiate(fallingObstaclePrefab, transform.position, Quaternion.identity);
    }
   
}
