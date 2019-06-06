using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class MoveSystem : ComponentSystem
{
    Vector3 directionMove = new Vector3();
    Quaternion directionRotation = new Quaternion();
    Dictionary<Direction, Vector3> directionVectors = new Dictionary<Direction, Vector3>();
    Dictionary<Direction, Quaternion> directionRotations = new Dictionary<Direction, Quaternion>();

    struct Components
    {
        public Transform transform;
        readonly public MoveData move;           
    }

    protected override void OnCreateManager()
    {
        base.OnCreateManager();
        directionVectors.Add(Direction.down, new Vector3(0, -1, 0));
        directionVectors.Add(Direction.up, new Vector3(0, 1, 0));
        directionVectors.Add(Direction.left, new Vector3(-1, 0, 0));
        directionVectors.Add(Direction.right, new Vector3(1, 0, 0));

        directionRotations.Add(Direction.down, Quaternion.Euler(0,0,270));
        directionRotations.Add(Direction.up, Quaternion.Euler(0, 0, 90));
        directionRotations.Add(Direction.left, Quaternion.Euler(0, 0, 180));
        directionRotations.Add(Direction.right, Quaternion.Euler(0, 0, 0));

    }

    protected override void OnUpdate()
    {
        foreach(var e in GetEntities<Components>())
        {
            directionVectors.TryGetValue(e.move.direction, out directionMove);
            directionRotations.TryGetValue(e.move.direction, out directionRotation);

            e.transform.position += directionMove*e.move.speed;
            e.transform.rotation = directionRotation;
        }
    }
}
