using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform prefab; // the prefab to spawn
    public Vector3 center; // the center of the spawning area
    public Vector3 size; // the size of the spawning area
    public int numberOfSpawns = 1;

    void Start()
    {
        // randomly spawn the prefab within the given area
        for (int i = 0; i < numberOfSpawns; i++)
        {
            Vector3 spawnPosition = center + new Vector3(Random.Range(-size.x / 2f, size.x / 2f), 0, Random.Range(-size.z / 2f, size.z / 2f));
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }
}
