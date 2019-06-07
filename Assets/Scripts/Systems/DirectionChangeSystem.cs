using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class DirectionChangeSystem : ComponentSystem
{
    struct Components
    {
        public DirectionChangeComponent directionChangeComponent;
        public MoveComponent moveComponent;
    }

        protected override void OnUpdate()
        {
            foreach (var e in GetEntities<Components>())
            {
            e.moveComponent.direction = e.directionChangeComponent.changedDirection;
            PostUpdateCommands.RemoveComponent<DirectionChangeComponent>(e.moveComponent.gameObject.GetComponent<GameObjectEntity>().Entity);
            GameObjectEntity.Destroy(e.directionChangeComponent);
        }
        }
}
