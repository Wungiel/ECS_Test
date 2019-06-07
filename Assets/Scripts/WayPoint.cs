using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


[Serializable]
public enum Direction
{
    left, right, up, down
}

public class WayPoint : MonoBehaviour
{
    public Direction direction;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(StringList.layerEnemy))
        {
            DirectionChangeComponent tmpComp = collision.gameObject.AddComponent<DirectionChangeComponent>();
            tmpComp.changedDirection = direction;
            Entity tmp = collision.gameObject.GetComponent<GameObjectEntity>().Entity;
            World.Active.GetExistingManager<EntityManager>().AddComponentObject(tmp, tmpComp);

        }
    }
}
