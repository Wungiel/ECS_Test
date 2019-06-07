using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class DestructionSystem : ComponentSystem
{
    struct Components
    {
        public DestroyComponent destroyComponent;
    }

    protected override void OnUpdate()
    {
        foreach (var e in GetEntities<Components>())
        {
            World.GetExistingManager<EntityManager>().RemoveComponent<DestroyComponent>(e.destroyComponent.gameObject.GetComponent<GameObjectEntity>().Entity);
            GameObjectEntity.Destroy(e.destroyComponent.gameObject);
        }
    }
}
