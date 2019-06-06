using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointData : MonoBehaviour
{
    [Serializable]
    public enum Direction
    {
        left, right, up, down
    }

    public Direction direction;
}
