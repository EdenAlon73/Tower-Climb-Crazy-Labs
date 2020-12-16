using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacles : MonoBehaviour
{
    private SpawnerParent spawnerScript;
    private float directionOfMovement = -1;

    private void Awake()
    {
        spawnerScript = GetComponentInParent<SpawnerParent>();
    }
    void Update()
    {
        ForwardMovement();
    }

    private void ForwardMovement()
    {
        transform.position = transform.position + new Vector3(0, 0, directionOfMovement * spawnerScript.fallingObstacleSpeed * Time.deltaTime);
    }

  
}
    
