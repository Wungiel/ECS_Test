using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class EndPoint : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(StringList.layerEnemy))
        {
            DestroyComponent tmpComp = collision.gameObject.AddComponent<DestroyComponent>();
            Entity tmp = collision.gameObject.GetComponent<GameObjectEntity>().Entity;
            World.Active.GetExistingManager<EntityManager>().AddComponentObject(tmp, tmpComp);

        }
    }
}
