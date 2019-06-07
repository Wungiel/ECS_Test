using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideMapObjectRemover : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(StringList.layerEnemy))
            Debug.Log("Enemy outside road, check waypoints");
        Destroy(collision.gameObject);
    }
}
