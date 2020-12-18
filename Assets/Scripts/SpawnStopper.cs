using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStopper : MonoBehaviour
{
    [SerializeField] private SpawnerParent spawnerParent;

    private void Awake()
    {
        spawnerParent = FindObjectOfType<SpawnerParent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnerParent.StopSpawning();
        }
    }
}
