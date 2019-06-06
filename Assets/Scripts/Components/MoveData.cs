using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveData : MonoBehaviour
{
    public Direction direction;
    public float speed;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(StringList.layerWaypoint))
        {
            direction = collision.GetComponent<WaypointData>().direction;
        }
    }
}
