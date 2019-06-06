using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SpawnSystem : ComponentSystem
{

    GameObject tmp;
    SpawnComponent tmpSpawn;

    struct Components
    {
        public SpawnComponent spawnData;
    }

    protected override void OnUpdate()
    {
        foreach(var e in GetEntities<Components>())
        {
            tmp = e.spawnData.gameObject;
            tmpSpawn = e.spawnData;

            if (tmpSpawn.currentWaveCount == e.spawnData.waveLenght)
            {
                if (tmpSpawn.timePassed > e.spawnData.timeBetweenWaves)
                {
                    tmpSpawn.currentWaveCount = 0;
                    tmpSpawn.timePassed = 0;
                }
            }
            else if (e.spawnData.timePassed > e.spawnData.timeBetweenSpawns)
            {
                GameObjectEntity.Instantiate(tmpSpawn.spawnedObject, tmp.transform.position, Quaternion.identity, tmp.transform);
                tmpSpawn.currentWaveCount++;
                tmpSpawn.timePassed = 0;
            }
            tmpSpawn.timePassed += Time.deltaTime;
        }
    }
}
