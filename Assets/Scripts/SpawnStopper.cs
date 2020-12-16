using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStopper : MonoBehaviour
{
    [SerializeField] private GameObject obstacleSpawnerParent;

    private void Awake()
    {
        obstacleSpawnerParent = GameObject.FindGameObjectWithTag("SpawnerParent");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            obstacleSpawnerParent.SetActive(false);
        }
    }
}
