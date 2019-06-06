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
            GameObjectEntity.Destroy(e.destroyComponent.gameObject);
        }
    }
}
