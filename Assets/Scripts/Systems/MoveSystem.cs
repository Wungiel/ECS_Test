using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class MoveSystem : ComponentSystem
{
    Vector3 directionMove = new Vector3();

    struct Components
    {
        public Transform transform;
        readonly public MoveData move;           
    }

    protected override void OnUpdate()
    {
        foreach(var e in GetEntities<Components>())
        {
            switch (e.move.direction)
            {
                case (Direction.down):
                    directionMove = new Vector3(0, -1, 0);
                    break;
                case (Direction.up):
                    directionMove = new Vector3(0, 1, 0);
                    break;
                case (Direction.left):
                    directionMove = new Vector3(-1, 0, 0);
                    break;
                case (Direction.right):
                    directionMove = new Vector3(1, 0, 0);
                    break;
            }

            e.transform.position += directionMove*e.move.speed;
        }
    }
}
