using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnData : MonoBehaviour
{
    public GameObject spawnedObject;
    public float timeBetweenSpawns;
    public float timeBetweenWaves;
    public float timePassed;
    public Direction initialDirection;
    [Range(1,10)] public int waveLenght;
    public int currentWaveCount;

    public void OnValidate()
    {
        if (timeBetweenSpawns < 0)
            timeBetweenSpawns = 1.0f;
        if (timeBetweenWaves < 0)
            timeBetweenWaves = 1.0f;
        timePassed = 0;
        currentWaveCount = 0;
    }

    public void spawn()
    {
        GameObject tmp = Instantiate(spawnedObject, this.transform.position, this.transform.rotation, this.transform);
        tmp.GetComponent<MoveData>().direction = initialDirection;
    }
}
