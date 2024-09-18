using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public float generationInterval = 3.5f;

    private float nextSpawn;

    void Start()
    {
        nextSpawn = generationInterval;
    }

    void Update()
    {
        nextSpawn -= Time.deltaTime;

        if (nextSpawn <= 0f)
        {
            GenerarObstaculo();
            nextSpawn = generationInterval;
        }
    }

    void GenerarObstaculo()
    {
        int ObstacleType = Random.Range(0, ObjectPooling.instance.objectPrefabs.Length);
        GameObject obstacle = ObjectPooling.instance.GetObject(ObstacleType);
        obstacle.transform.position = spawnPoint.position;
    }
}
