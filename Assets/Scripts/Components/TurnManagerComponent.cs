using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManagerComponent : MonoBehaviour
{
    public bool newTurn = false;

    public void switchTurn()
    {
        newTurn = !newTurn;
    }
}
