using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class MoveComponent : MonoBehaviour
{
    public Direction direction;
    public float speed;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(StringList.layerWaypoint))
        {
            direction = collision.GetComponent<WaypointComponent>().direction;
        } else if (collision.CompareTag(StringList.layerFinish))
        {
            DestroyComponent tmpComp = gameObject.AddComponent<DestroyComponent>();
            Entity tmp = gameObject.GetComponent<GameObjectEntity>().Entity;
            World.Active.GetExistingManager<EntityManager>().AddComponentObject(tmp, tmpComp);

        }
    }
}
