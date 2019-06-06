using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public enum Direction
{
    left, right, up, down
}

public class WaypointComponent : MonoBehaviour
{
    public Direction direction;
}
