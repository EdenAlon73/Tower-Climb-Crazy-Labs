using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerParent : MonoBehaviour
{
    public float fallingObstacleSpeed = 2f;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 5f;
    public float spawnTimeDelay = 2f;
    public float timeIncrement = .25f;
    public bool doISpawnOverTime;
    public bool spawn;

    private void Awake()
    {
        spawn = true;
        doISpawnOverTime = false;
    }
  

    public void StopSpawning()
    {
        spawn = false;
    }

}

