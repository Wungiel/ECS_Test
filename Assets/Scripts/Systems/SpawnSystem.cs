using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SpawnSystem : ComponentSystem
{
    struct Components
    {
        public SpawnData spawnData;
    }

    protected override void OnUpdate()
    {
        foreach(var e in GetEntities<Components>())
        {
            if (e.spawnData.currentWaveCount == e.spawnData.waveLenght)
            {
                if (e.spawnData.timePassed > e.spawnData.timeBetweenWaves)
                {
                    e.spawnData.currentWaveCount = 0;
                    e.spawnData.timePassed = 0;
                }
            }
            else if (e.spawnData.timePassed > e.spawnData.timeBetweenSpawns)
            {
                e.spawnData.spawn();
                e.spawnData.currentWaveCount++;
                e.spawnData.timePassed = 0;
            }
            e.spawnData.timePassed += Time.deltaTime;
        }
    }
}
